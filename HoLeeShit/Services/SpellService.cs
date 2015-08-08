// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpellService.cs" company="ChewyMoon">
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
//   The spell service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HoLeeShit.Services
{
    using HoLeeShit.Interfaces;

    using LeagueSharp;
    using LeagueSharp.Common;

    /// <summary>
    ///     The spell service.
    /// </summary>
    public class SpellService : Service
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="SpellService" /> class.
        ///     Initializes a new instance of the <see cref="Service" /> class.
        /// </summary>
        /// <param name="serviceProvider">
        ///     The service provider.
        /// </param>
        public SpellService(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the e.
        /// </summary>
        /// <value>
        ///     The e.
        /// </value>
        public Spell E { get; internal set; }

        /// <summary>
        ///     Gets the q.
        /// </summary>
        /// <value>
        ///     The q.
        /// </value>
        public Spell Q { get
        {
            return ServiceProvider.Resolve<BuffService>().HasFirstQ ? q : q2;
        } }

        /// <summary>
        ///     Gets the r.
        /// </summary>
        /// <value>
        ///     The r.
        /// </value>
        public Spell R { get; internal set; }

        /// <summary>
        ///     Gets the w.
        /// </summary>
        /// <value>
        ///     The w.
        /// </value>
        public Spell W { get; internal set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The q
        /// </summary>
        private Spell q;

        /// <summary>
        /// The q2
        /// </summary>
        private Spell q2;

        /// <summary>
        ///     Initializes this service.
        /// </summary>
        public override void Initialize()
        {
            this.q = new Spell(SpellSlot.Q, 1100);
            this.q2 = new Spell(SpellSlot.Q, 1300);
            this.W = new Spell(SpellSlot.W, 700);
            this.E = new Spell(SpellSlot.E, 350);
            this.R = new Spell(SpellSlot.R, 375);

            this.q.SetSkillshot(0.25f, 60, 1800, true, SkillshotType.SkillshotLine);
            this.W.SetTargetted(0.2645f, 1500);
            this.E.SetTargetted(0.25f, 1500);
        }

        #endregion
    }
}