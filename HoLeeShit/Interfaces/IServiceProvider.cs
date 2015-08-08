// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IServiceProvider.cs" company="ChewyMoon">
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
//   Provides implementations to services.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HoLeeShit.Interfaces
{
    /// <summary>
    ///     Provides implementations to services.
    /// </summary>
    public interface IServiceProvider
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Resolves the service.
        /// </summary>
        /// <typeparam name="T">The type of service.</typeparam>
        /// <returns>The service.</returns>
        T Resolve<T>() where T : Service;

        #endregion
    }
}