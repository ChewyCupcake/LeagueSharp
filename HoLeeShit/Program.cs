// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="ChewyMoon">
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
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HoLeeShit
{
    using System;
    using System.Linq;

    using HoLeeShit.Services;

    using LeagueSharp;
    using LeagueSharp.Common;

    /// <summary>
    ///     The program.
    /// </summary>
    internal class Program
    {
        #region Methods

        /// <summary>
        ///     Called when the game is loaded.
        /// </summary>
        /// <param name="args">The <see cref="EventArgs" /> instance containing the event data.</param>
        private static void GameOnOnGameLoad(EventArgs args)
        {
            var serviceProvider = new ServiceProvider();
            serviceProvider.RegisterService<SpellService>();
            serviceProvider.RegisterService<OrbwalkerService>();
            serviceProvider.RegisterService<ConfigurationService>();
            serviceProvider.RegisterService<ComboService>();
            serviceProvider.RegisterService<DrawingService>();

            serviceProvider.InitializeServices();

            Game.PrintChat("<font color=\"#7CFC00\"><b>HoLeeShit:</b></font> Loaded");

            Game.OnUpdate += Game_OnUpdate;
        }

        private static void Game_OnUpdate(EventArgs args)
        {
            Console.Clear();
            Console.WriteLine(string.Join(" ", ObjectManager.Player.Buffs.Select(x => x.Name)));

        }

        /// <summary>
        ///     The main.
        /// </summary>
        /// <param name="args">
        ///     The args.
        /// </param>
        private static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += GameOnOnGameLoad;
        }

        #endregion
    }
}