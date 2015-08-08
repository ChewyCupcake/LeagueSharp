// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DrawingService.cs" company="ChewyMoon">
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
//   The drawing service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HoLeeShit.Services
{
    using HoLeeShit.Interfaces;

    /// <summary>
    ///     The drawing service.
    /// </summary>
    internal class DrawingService : Service
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawingService"/> class. 
        ///     Initializes a new instance of the <see cref="Service"/> class.
        /// </summary>
        /// <param name="serviceProvider">
        /// The service provider.
        /// </param>
        public DrawingService(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        #endregion
    }
}