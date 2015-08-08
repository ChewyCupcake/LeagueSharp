// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ComboService.cs" company="ChewyMoon">
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
//   The combo service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HoLeeShit.Services
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using HoLeeShit.Interfaces;

    using LeagueSharp;
    using LeagueSharp.Common;

    using IServiceProvider = HoLeeShit.Interfaces.IServiceProvider;

    /// <summary>
    ///     The combo service.
    /// </summary>
    internal class ComboService : Service
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ComboService" /> class.
        ///     Initializes a new instance of the <see cref="Service" /> class.
        /// </summary>
        /// <param name="serviceProvider">
        ///     The service provider.
        /// </param>
        public ComboService(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the configuration service.
        /// </summary>
        /// <value>
        ///     The configuration service.
        /// </value>
        private ConfigurationService Config
        {
            get
            {
                return this.ServiceProvider.Resolve<ConfigurationService>();
            }
        }

        /// <summary>
        ///     Gets the orbwalker.
        /// </summary>
        /// <value>
        ///     The orbwalker.
        /// </value>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", 
            Justification = "Reviewed. Suppression is OK here.")]
        private Orbwalking.Orbwalker Orbwalker
        {
            get
            {
                return this.ServiceProvider.Resolve<OrbwalkerService>().Orbwalker;
            }
        }

        /// <summary>
        /// Gets the spells.
        /// </summary>
        private SpellService Spells
        {
            get
            {
                return this.ServiceProvider.Resolve<SpellService>();
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Initializes this service.
        /// </summary>
        public override void Initialize()
        {
            Game.OnUpdate += this.Game_OnUpdate;
        }

        /// <summary>
        ///     Invokes this service.
        /// </summary>
        public override void Invoke()
        {
            var target = TargetSelector.GetTarget(ServiceProvider.Resolve<BuffService>().HasFirstQ ? Spells.Q.Range : 1300, TargetSelector.DamageType.Physical);

            if (!target.IsValidTarget())
            {
                return;
            }

            var useQ = this.Config.GetValue<bool>("UseQCombo");
            var useQWithSmite = this.Config.GetValue<bool>("UseQWithSmite");
            var useWardJumpQ2 = this.Config.GetValue<bool>("UseWardJumpQ2");
            var useW = this.Config.GetValue<bool>("UseWCombo");
            var useWLowHealth = this.Config.GetValue<bool>("UseWLowHP");
            var useWHealthPercent = this.Config.GetValue<Slider>("UseWLowHP").Value;
            var useWGapclose = this.Config.GetValue<bool>("UseWGapclose");
            var useE = this.Config.GetValue<bool>("UseECombo");
            var useR = this.Config.GetValue<bool>("UseRCombo");
            var useRKnockUp = this.Config.GetValue<bool>("UseRKnockUp");
            var useRKnockUpEnemies = this.Config.GetValue<Slider>("UseRKnockupSlider").Value;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Called when the game updates.
        /// </summary>
        /// <param name="args">
        ///     The args.
        /// </param>
        private void Game_OnUpdate(EventArgs args)
        {
            if (this.Orbwalker.ActiveMode == Orbwalking.OrbwalkingMode.Combo)
            {
                this.Invoke();
            }
        }

        #endregion
    }
}