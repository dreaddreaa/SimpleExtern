﻿using System;
using Smurf.GlobalOffensive.Patchables;

namespace Smurf.GlobalOffensive.Feauters
{
    public class BunnyJump
    {
        #region Methods

        public void Update()
        {
            if (!Smurf.Objects.ShouldUpdate(false, false, false))
                return;

            ReadSettings();

            if (!_bunnyJumpEnabled)
                return;

            if (Smurf.LocalPlayer.Velocity <= 100)
                return;

            BHop();
        }

        private void BHop()
        {
            if (Smurf.KeyUtils.KeyIsDown(_bunnyJumpKey))
                Smurf.Memory.Write(Smurf.ClientBase + Offsets.Misc.Jump, Smurf.LocalPlayer.InAir ? 4 : 5);
        }

        private void ReadSettings()
        {
            _bunnyJumpEnabled = Smurf.Settings.GetBool("Bunny Jump", "Bunny Jump Enabled");
            _bunnyJumpKey =
                (WinAPI.VirtualKeyShort) Convert.ToInt32(Smurf.Settings.GetString("Bunny Jump", "Bunny Jump Key"), 16);
        }

        #endregion

        #region Fields

        private bool _bunnyJumpEnabled;
        private WinAPI.VirtualKeyShort _bunnyJumpKey;

        #endregion
    }
}