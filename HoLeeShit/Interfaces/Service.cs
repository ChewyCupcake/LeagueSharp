// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Service.cs" company="ChewyMoon">
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
//   The Service interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HoLeeShit.Interfaces
{
    /// <summary>
    ///     The Service interface.
    /// </summary>
    public abstract class Service
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Service" /> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        protected Service(IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the service provider.
        /// </summary>
        /// <value>
        ///     The service provider.
        /// </value>
        public IServiceProvider ServiceProvider { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Initializes this service.
        /// </summary>
        public virtual void Initialize()
        {
        }

        /// <summary>
        ///     Invokes this service.
        /// </summary>
        public virtual void Invoke()
        {
        }

        #endregion
    }
}