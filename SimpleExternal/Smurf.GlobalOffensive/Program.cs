﻿using System;
using System.Diagnostics;
using System.Threading;

namespace Smurf.GlobalOffensive
{
    internal class Program
    {
        #region Fields
        private static IntPtr _hWnd;
        private const string GameTitle = "Counter-Strike: Global Offensive";
        #endregion

        #region Methods
        private static void Main()
        {
            Thread thread1 = new Thread(PrintInfo);
            Thread thread2 = new Thread(UpdateBHop);
            Thread thread3 = new Thread(UpdateRcs);
            Thread thread4 = new Thread(UpdateSettings);
            Thread thread5 = new Thread(UpdateKeyUtils);
            Thread thread6 = new Thread(UpdateAutoPistol);

            Console.ForegroundColor = ConsoleColor.White;
            //Console.Title = "Cheat Squad";

            Console.WriteLine("> Waiting for CSGO to start up...");
            while ((_hWnd = WinAPI.FindWindowByCaption(_hWnd, GameTitle)) == IntPtr.Zero)
                Thread.Sleep(250);
            Console.Clear();

            Process[] process = Process.GetProcessesByName("csgo");
            Smurf.Attach(process[0]);

            StartThreads(thread1, thread2, thread3, thread4, thread5, thread6);

            while (true)
            {
                Smurf.Objects.Update();
                Smurf.Aimbot.Update();
                Smurf.TriggerBot.Update();
                Smurf.SoundEsp.Update();
                Smurf.Radar.Update();
                Smurf.Glow.Update();
                Thread.Sleep(1);
            }
        }

        private static void StartThreads(params Thread[] threads)
        {
            foreach (var thread in threads)
            {
                //thread.IsBackground = true;
                thread.Priority = ThreadPriority.Highest;
                thread.Start();
            }
        }
        private static void PrintInfo()
        {
#if DEBUG
            while (true)
            {
                Console.Clear();
                Console.WriteLine("State: {0}\n\n", Smurf.Client.State);

                if (Smurf.Client.InGame && Smurf.LocalPlayer != null && Smurf.LocalPlayerWeapon != null && Smurf.LocalPlayer.IsValid && Smurf.LocalPlayer.IsAlive)
                {
                    var me = Smurf.LocalPlayer;
                    var myWeapon = Smurf.LocalPlayerWeapon;

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("ID:\t\t{0}", me.Id);
                    Console.WriteLine("Health:\t\t{0}", me.Health);
                    Console.WriteLine("Armor:\t\t{0}", me.Armor);
                    Console.WriteLine("Position:\t{0}", me.Position);
                    Console.WriteLine("Team:\t\t{0}", me.Team);
                    Console.WriteLine("Player Count:\t{0}", Smurf.Objects.Players.Count);
                    Console.WriteLine("Velocity: \t{0}", me.Velocity);
                    Console.WriteLine("Shots Fired: \t{0}", me.ShotsFired);
                    Console.WriteLine("VecPunch: \t{0}", me.VecPunch);
                    Console.WriteLine("Immune: \t{0}", me.GunGameImmune);
                    Console.WriteLine("Active Weapon: \t{0}", myWeapon.WeaponName);
                    Console.WriteLine("Clip1: \t\t{0}", myWeapon.Clip1);
                    Console.WriteLine("Flags: \t\t{0}", me.Flags);
                    Console.WriteLine("Flash: \t\t{0}", me.FlashMaxAlpha);
                    Console.WriteLine("Weapon Group: \t{0}", myWeapon.WeaponGroup);
                    Console.WriteLine("Zoom Level: \t{0}", myWeapon.ZoomLevel);
                }

                Thread.Sleep(500);
            }
#endif

        }
        private static void UpdateBHop()
        {
            while (true)
            {
                Smurf.BunnyJump.Update();
                Thread.Sleep(5);
            }
        }
        private static void UpdateRcs()
        {
            while (true)
            {
                Smurf.ControlRecoil.Update();
                Thread.Sleep(5);
            }
        }
        private static void UpdateSettings()
        {
            while (true)
            {
                Smurf.Settings.Update();
                Thread.Sleep(10);
            }
        }
        private static void UpdateKeyUtils()
        {
            while (true)
            {
                Smurf.KeyUtils.Update();
                Smurf.NoFlash.Update();
                Thread.Sleep(10);
            }
        }
        private static void UpdateAutoPistol()
        {
            while (true)
            {
                Smurf.AutoPistol.Update();
                Thread.Sleep(1);
            }
        }
        #endregion

    }
}
