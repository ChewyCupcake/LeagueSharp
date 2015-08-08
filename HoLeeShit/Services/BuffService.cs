// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuffService.cs" company="ChewyMoon">
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
//   Provides the status of buffs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HoLeeShit.Services
{
    using HoLeeShit.Interfaces;

    using LeagueSharp;

    /// <summary>
    ///     Provides the status of buffs.
    /// </summary>
    internal class BuffService : Service
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BuffService"/> class. 
        ///     Initializes a new instance of the <see cref="Service"/> class.
        /// </summary>
        /// <param name="serviceProvider">
        /// The service provider.
        /// </param>
        public BuffService(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        #endregion

        #region Public Properties


        public bool HasFuryBuff
        {
            get
            {
                return ObjectManager.Player.HasBuff("blindmonkpassive_cosmetic");
            }
        }

        /// <summary>
        ///     Gets a value indicating whether this instance has first e.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance has first e; otherwise, <c>false</c>.
        /// </value>
        public bool HasFirstE
        {
            get
            {
                return this.ServiceProvider.Resolve<SpellService>().Q.Instance.Name == "BlindMonkEOne";
            }
        }

        /// <summary>
        ///     Gets a value indicating whether this instance has first q.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance has first q; otherwise, <c>false</c>.
        /// </value>
        public bool HasFirstQ
        {
            get
            {
                return this.ServiceProvider.Resolve<SpellService>().Q.Instance.Name == "BlindMonkQOne";
            }
        }

        /// <summary>
        ///     Gets a value indicating whether this instance has first w.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance has first w; otherwise, <c>false</c>.
        /// </value>
        public bool HasFirstW
        {
            get
            {
                return this.ServiceProvider.Resolve<SpellService>().Q.Instance.Name == "BlindMonkWOne";
            }
        }

        /// <summary>
        ///     Gets a value indicating whether this instance has second e.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance has second e; otherwise, <c>false</c>.
        /// </value>
        public bool HasSecondE
        {
            get
            {
                return !this.HasFirstE;
            }
        }

        /// <summary>
        ///     Gets a value indicating whether this instance has second q.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance has second q; otherwise, <c>false</c>.
        /// </value>
        public bool HasSecondQ
        {
            get
            {
                return !this.HasFirstQ;
            }
        }

        /// <summary>
        ///     Gets a value indicating whether this instance has second w.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance has second w; otherwise, <c>false</c>.
        /// </value>
        public bool HasSecondW
        {
            get
            {
                return !this.HasFirstQ;
            }
        }

        #endregion
    }
}