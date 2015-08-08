// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigurationService.cs" company="ChewyMoon">
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
//   The configuration service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HoLeeShit.Services
{
    using HoLeeShit.Interfaces;

    using LeagueSharp.Common;

    /// <summary>
    ///     The configuration service.
    /// </summary>
    internal class ConfigurationService : Service
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ConfigurationService" /> class.
        ///     Initializes a new instance of the <see cref="Service" /> class.
        /// </summary>
        /// <param name="serviceProvider">
        ///     The service provider.
        /// </param>
        public ConfigurationService(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the menu.
        /// </summary>
        /// <value>
        ///     The menu.
        /// </value>
        public Menu Menu { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="name">The name.</param>
        /// <returns>The value of the item in the menu.</returns>
        public T GetValue<T>(string name)
        {
            return this.Menu.Item(name).GetValue<T>();
        }

        /// <summary>
        ///     Initializes this service.
        /// </summary>
        public override void Initialize()
        {
            this.Menu = new Menu("HoLeeShit", "CM_HoLeeShit", true);

            // Orbwalker Menu
            var orbwalkerMenu = new Menu("Orbwalker", "Orbwalker");
            this.ServiceProvider.Resolve<OrbwalkerService>().Orbwalker = new Orbwalking.Orbwalker(orbwalkerMenu);
            this.Menu.AddSubMenu(orbwalkerMenu);

            // Target Selector
            var tsMenu = new Menu("Target Selector", "TargetSelector");
            TargetSelector.AddToMenu(tsMenu);
            this.Menu.AddSubMenu(tsMenu);

            // Combo
            var comboMenu = new Menu("Combo", "Combo");

            // Q Settings
            var qMenu = new Menu("Q Settings", "QSettings");
            qMenu.AddItem(new MenuItem("UseQCombo", "Use Q").SetValue(true));
            qMenu.AddItem(new MenuItem("UseQWithSmite", "Smite Minion to Q").SetValue(true));
            qMenu.AddItem(new MenuItem("UseWardJumpQ2", "Ward Jump for Second Q").SetValue(true));
            comboMenu.AddSubMenu(qMenu);

            // W Settings
            var wMenu = new Menu("W Settings", "WSettings");
            wMenu.AddItem(new MenuItem("UseWCombo", "Use W").SetValue(true));
            wMenu.AddItem(new MenuItem("UseWLowHP", "Use W when Low").SetValue(true));
            wMenu.AddItem(new MenuItem("UseWLowHPSlider", "W Health Percent").SetValue(new Slider(40)));
            wMenu.AddItem(new MenuItem("UseWGapclose", "Use W to Gapclose").SetValue(false));
            comboMenu.AddSubMenu(wMenu);

            // E Settings
            var eMenu = new Menu("E Settings", "ESettings");
            eMenu.AddItem(new MenuItem("UseECombo", "Use E").SetValue(true));
            comboMenu.AddSubMenu(eMenu);

            // R Settings
            var rMenu = new Menu("R Settings", "RSettings");
            rMenu.AddItem(new MenuItem("UseRCombo", "Use R").SetValue(true));
            rMenu.AddItem(new MenuItem("UseRKnockUp", "Use R for AOE Knockup").SetValue(true));
            rMenu.AddItem(new MenuItem("UseRKnockupSlider", "Number of Enemies").SetValue(new Slider(3, 1, 5)));
            comboMenu.AddSubMenu(rMenu);

            // Star Combo
            var starComboMenu = new Menu("Star Combo Settings", "StarComboSettings");
            starComboMenu.AddItem(
                new MenuItem("StarComboKey", "Do Star Combo").SetValue(new KeyBind(90, KeyBindType.Press)));
            starComboMenu.AddItem(new MenuItem("UseFlash", "Use Flash if cant Ward Jump").SetValue(false));
            starComboMenu.AddItem(new MenuItem("AutoStarComboKillable", "Do Star Combo if Killable").SetValue(true));
            comboMenu.AddSubMenu(starComboMenu);

            this.Menu.AddSubMenu(comboMenu);

            // Harass
            var harassMenu = new Menu("Harass", "Harass");
            harassMenu.AddItem(new MenuItem("UseQMixed", "Use Q").SetValue(true));
            harassMenu.AddItem(new MenuItem("UseWMixed", "Use W").SetValue(true));
            harassMenu.AddItem(new MenuItem("UseWEscape", "Use W to Flee Back to Minion").SetValue(true));
            harassMenu.AddItem(new MenuItem("UseEMixed", "Use E").SetValue(true));
            this.Menu.AddSubMenu(harassMenu);

            this.Menu.AddToMainMenu();
        }

        #endregion
    }
}