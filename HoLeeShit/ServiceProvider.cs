// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceProvider.cs" company="ChewyMoon">
//   Copyright (C) 2015 ChewyMoon
//   
//   This program is free software: you can redistribute it and/or modify
//   it under the terms of the GNU General Public License as published by
//   the Free Software Foundation, either version 3 of the License, or
//   (at your option) any later version.
//   
//   This program is distributed in the hope that it will be useful,
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//   GNU General Public License for more details.
//   
//   You should have received a copy of the GNU General Public License
//   along with this program.  If not, see <http://www.gnu.org/licenses/>.
// </copyright>
// <summary>
//   The service provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HoLeeShit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Security;
    using System.Security.Permissions;

    using HoLeeShit.Interfaces;

    using IServiceProvider = HoLeeShit.Interfaces.IServiceProvider;

    /// <summary>
    ///     The service provider.
    /// </summary>
    public class ServiceProvider : IServiceProvider
    {
        #region Fields

        /// <summary>
        ///     The services
        /// </summary>
        private readonly Dictionary<Type, Service> services = new Dictionary<Type, Service>(10);

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Initializes the services.
        /// </summary>
        public void InitializeServices()
        {
            this.services.Values.ToList().ForEach(x => x.Initialize());
        }

        /// <summary>
        ///     Registers the service.
        /// </summary>
        /// <typeparam name="T">The typeof service.</typeparam>
        [PermissionSet(SecurityAction.Assert, Unrestricted = true)]
        public void RegisterService<T>() where T : Service
        {
            try
            {
                var instance = (Service) Activator.CreateInstance(typeof(T), this);
                instance.Initialize();

                services.Add(typeof(T), instance);

                Console.WriteLine("[HoLeeShit]: Registered {0}", typeof(T).Name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }

        /// <summary>
        ///     Resolves the service.
        /// </summary>
        /// <typeparam name="T">The type of service.</typeparam>
        /// <returns>The service.</returns>
        public T Resolve<T>() where T : Service
        {
            Service service;
            if (this.services.TryGetValue(typeof(T), out service))
            {
                return (T)service;
            }

            Console.WriteLine("[HoLeeShit]: Failed to resolve service {0}", typeof(T).Name);
            return default(T);
        }

        #endregion
    }
}