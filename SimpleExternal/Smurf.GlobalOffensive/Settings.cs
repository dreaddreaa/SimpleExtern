﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using IniParser;
using IniParser.Model;

namespace Smurf.GlobalOffensive
{
    public class Settings
    {
        #region Fields
        private static readonly FileIniDataParser Parser = new FileIniDataParser();
        private IniData _data;
        private WinAPI.VirtualKeyShort _reloadConfigKey;
        #endregion
        #region Constructor
        public Settings()
        {
            if (!File.Exists("Config.ini"))
            {
                CreateConfigFile();
            }
            _data = Parser.ReadFile("Config.ini");
        }
        #endregion
        #region Methods
        public void Update()
        {
            _reloadConfigKey = (WinAPI.VirtualKeyShort)Convert.ToInt32(Core.Settings.GetString("Misc", "Reload Config Key"), 16);
            if (Core.KeyUtils.KeyWentDown(_reloadConfigKey)) //Tab Key, don't hard code key, will fix later.
            {
                _data = Parser.ReadFile("Config.ini");
            }
        }

        private void CreateConfigFile()
        {
            #region WeaponList
            List<string> snipersList = new List<string>
            {
                "AWP",
                "SSG08",
                "SCAR20",
                "G3SG1"
            };
            List<string> machineGunList = new List<string>
            {
                "M249",
                "Negev"
            };

            List<string> heavyList = new List<string>
            {
                "NOVA",
                "XM1014",
                "Sawedoff",
                "Mag7"
            };

            List<string> smgList = new List<string>
            {
                "MAC10",
                "MP9",
                "MP7",
                "UMP45",
                "Bizon",
                "P90"
            };

            List<string> pistolList = new List<string>
            {
                "DEagle",
                "Elite",
                "FiveSeven",
                "Glock",
                "P228",
                "P250",
                "HKP2000",
                "Tec9"
            };

            List<string> rifleList = new List<string>
            {
                "GalilAR",
                "AK47",
                "SG556",
                "Famas",
                "M4A1",
                "Aug"
            };
            #endregion

            StringBuilder builder = new StringBuilder();
            //Bunny Jump
            builder.AppendLine("[Bunny Jump]");
            builder.AppendLine("Bunny Jump Enabled = True");
            builder.AppendLine("Bunny Jump Key = 0x20").AppendLine();

            //Glow
            builder.AppendLine("[Glow ESP]");
            builder.AppendLine("Glow ESP Enabled = False");
            builder.AppendLine("Glow ESP Allies = False");
            builder.AppendLine("Glow ESP Enemies = False").AppendLine();

            //SoundESP
            builder.AppendLine("[Sound ESP]");
            builder.AppendLine("Sound ESP = True");
            builder.AppendLine("Sound Range = 10");
            builder.AppendLine("Sound Interval = 1000");
            builder.AppendLine("Sound Volume = 100").AppendLine();

            //Misc
            builder.AppendLine("[Misc]");
            builder.AppendLine("Mouse Movement = True");
            builder.AppendLine("Radar = True");
            builder.AppendLine("InCross Trigger Bot = False");
            builder.AppendLine("No Flash = False");
            builder.AppendLine("Reload Config Key = 0x35").AppendLine();

            foreach (var weapon in pistolList)
            {
                builder.AppendLine("[" + weapon + "]");
                //Auto Pistol
                builder.AppendLine("Auto Pistol = False");
                builder.AppendLine("Auto Pistol Key = 0x12");
                builder.AppendLine("Auto Pistol Delay = 0").AppendLine();
                //RCS
                builder.AppendLine("Rcs Enabled = False");
                builder.AppendLine("Rcs Start = 1");
                builder.AppendLine("Rcs Force Max Yaw = 2");
                builder.AppendLine("Rcs Force Min Yaw = 2");
                builder.AppendLine("Rcs Force Max Pitch = 2");
                builder.AppendLine("Rcs Force Min Pitch = 2").AppendLine();
                //Trigger
                builder.AppendLine("Trigger Enabled = True");
                builder.AppendLine("Trigger Key = 0x12");
                builder.AppendLine("Trigger Dash = False");
                builder.AppendLine("Trigger When Zoomed = False");
                builder.AppendLine("Trigger Enemies = True");
                builder.AppendLine("Trigger Allies = False");
                builder.AppendLine("Trigger Spawn Protected = False");
                builder.AppendLine("Trigger Delay FirstShot Max = 128");
                builder.AppendLine("Trigger Delay FirstShot Min = 98");
                builder.AppendLine("Trigger Delay Shots Max = 68");
                builder.AppendLine("Trigger Delay Shots Min = 35").AppendLine();

                //Aim Assist
                builder.AppendLine("Aim Enabled = True");
                builder.AppendLine("Aim Key = 0x12");
                builder.AppendLine("Aim Fov = 50");
                builder.AppendLine("Aim Humanized = True");
                builder.AppendLine("Aim Spotted = True");
                builder.AppendLine("Aim Enemies = True");
                builder.AppendLine("Aim Allies = False");
                builder.AppendLine("Aim Speed = 50");
                builder.AppendLine("Aim Bone = 5").AppendLine();
            }
            foreach (var weapon in rifleList)
            {
                builder.AppendLine("[" + weapon + "]");
                //RCS
                builder.AppendLine("Rcs Enabled = True");
                builder.AppendLine("Rcs Start = 1");
                builder.AppendLine("Rcs Force Max Yaw = 2");
                builder.AppendLine("Rcs Force Min Yaw = 2");
                builder.AppendLine("Rcs Force Max Pitch = 2");
                builder.AppendLine("Rcs Force Min Pitch = 2").AppendLine();
                //Trigger
                builder.AppendLine("Trigger Enabled = False");
                builder.AppendLine("Trigger Key = 0x12");
                builder.AppendLine("Trigger Dash = False");
                builder.AppendLine("Trigger When Zoomed = False");
                builder.AppendLine("Trigger Enemies = True");
                builder.AppendLine("Trigger Allies = False");
                builder.AppendLine("Trigger Burst Enabled = False");
                builder.AppendLine("Trigger Spawn Protected = False");
                builder.AppendLine("Trigger Delay FirstShot Max = 35");
                builder.AppendLine("Trigger Delay FirstShot Min = 35");
                builder.AppendLine("Trigger Delay Shots Max = 35");
                builder.AppendLine("Trigger Delay Shots Min = 35").AppendLine();

                //Aim Assist
                builder.AppendLine("Aim Enabled = True");
                builder.AppendLine("Aim Key = 0x12");
                builder.AppendLine("Aim Fov = 50");
                builder.AppendLine("Aim Humanized = True");
                builder.AppendLine("Aim Spotted = True");
                builder.AppendLine("Aim Enemies = True");
                builder.AppendLine("Aim Allies = False");
                builder.AppendLine("Aim Speed = 50");
                builder.AppendLine("Aim Bone = 5").AppendLine();
            }
            foreach (var weapon in smgList)
            {
                builder.AppendLine("[" + weapon + "]");
                //RCS
                builder.AppendLine("Rcs Enabled = True");
                builder.AppendLine("Rcs Start = 1");
                builder.AppendLine("Rcs Force Max Yaw = 2");
                builder.AppendLine("Rcs Force Min Yaw = 2");
                builder.AppendLine("Rcs Force Max Pitch = 2");
                builder.AppendLine("Rcs Force Min Pitch = 2").AppendLine();
                //Trigger
                builder.AppendLine("Trigger Enabled = True");
                builder.AppendLine("Trigger Key = 0x12");
                builder.AppendLine("Trigger Dash = False");
                builder.AppendLine("Trigger When Zoomed = False");
                builder.AppendLine("Trigger Enemies = True");
                builder.AppendLine("Trigger Allies = False");
                builder.AppendLine("Trigger Burst Enabled = False");
                builder.AppendLine("Trigger Spawn Protected = False");
                builder.AppendLine("Trigger Delay FirstShot Max = 35");
                builder.AppendLine("Trigger Delay FirstShot Min = 35");
                builder.AppendLine("Trigger Delay Shots Max = 35");
                builder.AppendLine("Trigger Delay Shots Min = 35").AppendLine();

                //Aim Assist
                builder.AppendLine("Aim Enabled = True");
                builder.AppendLine("Aim Key = 0x12");
                builder.AppendLine("Aim Fov = 50");
                builder.AppendLine("Aim Humanized = True");
                builder.AppendLine("Aim Spotted = True");
                builder.AppendLine("Aim Enemies = True");
                builder.AppendLine("Aim Allies = False");
                builder.AppendLine("Aim Speed = 50");
                builder.AppendLine("Aim Bone = 5").AppendLine();
            }
            foreach (var weapon in snipersList)
            {
                builder.AppendLine("[" + weapon + "]");
                //RCS
                builder.AppendLine("Rcs Enabled = False");
                builder.AppendLine("Rcs Start = 1");
                builder.AppendLine("Rcs Force Max Yaw = 2");
                builder.AppendLine("Rcs Force Min Yaw = 2");
                builder.AppendLine("Rcs Force Max Pitch = 2");
                builder.AppendLine("Rcs Force Min Pitch = 2").AppendLine();
                //Trigger
                builder.AppendLine("Trigger Enabled = True");
                builder.AppendLine("Trigger Key = 0x12");
                builder.AppendLine("Trigger Dash = False");
                builder.AppendLine("Trigger When Zoomed = False");
                builder.AppendLine("Trigger Enemies = True");
                builder.AppendLine("Trigger Allies = False");
                builder.AppendLine("Trigger Burst Enabled = False");
                builder.AppendLine("Trigger Spawn Protected = False");
                builder.AppendLine("Trigger Delay FirstShot Max = 128");
                builder.AppendLine("Trigger Delay FirstShot Min = 98");
                builder.AppendLine("Trigger Delay Shots Max = 68");
                builder.AppendLine("Trigger Delay Shots Min = 35").AppendLine();

                //Aim Assist
                builder.AppendLine("Aim Enabled = True");
                builder.AppendLine("Aim Key = 0x12");
                builder.AppendLine("Aim Fov = 50");
                builder.AppendLine("Aim Humanized = True");
                builder.AppendLine("Aim Spotted = True");
                builder.AppendLine("Aim Enemies = True");
                builder.AppendLine("Aim Allies = False");
                builder.AppendLine("Aim Speed = 50");
                builder.AppendLine("Aim Bone = 5").AppendLine();
            }
            foreach (var weapon in machineGunList)
            {
                builder.AppendLine("[" + weapon + "]");
                //RCS
                builder.AppendLine("Rcs Enabled = False");
                builder.AppendLine("Rcs Start = 1");
                builder.AppendLine("Rcs Force Max Yaw = 2");
                builder.AppendLine("Rcs Force Min Yaw = 2");
                builder.AppendLine("Rcs Force Max Pitch = 2");
                builder.AppendLine("Rcs Force Min Pitch = 2").AppendLine();
                //Trigger
                builder.AppendLine("Trigger Enabled = True");
                builder.AppendLine("Trigger Key = 0x12");
                builder.AppendLine("Trigger Dash = False");
                builder.AppendLine("Trigger When Zoomed = False");
                builder.AppendLine("Trigger Enemies = True");
                builder.AppendLine("Trigger Allies = False");
                builder.AppendLine("Trigger Burst Enabled = False");
                builder.AppendLine("Trigger Spawn Protected = False");
                builder.AppendLine("Trigger Delay FirstShot Max = 35");
                builder.AppendLine("Trigger Delay FirstShot Min = 35");
                builder.AppendLine("Trigger Delay Shots Max = 35");
                builder.AppendLine("Trigger Delay Shots Min = 35").AppendLine();

                //Aim Assist
                builder.AppendLine("Aim Enabled = True");
                builder.AppendLine("Aim Key = 0x12");
                builder.AppendLine("Aim Fov = 50");
                builder.AppendLine("Aim Humanized = True");
                builder.AppendLine("Aim Spotted = True");
                builder.AppendLine("Aim Enemies = True");
                builder.AppendLine("Aim Allies = False");
                builder.AppendLine("Aim Speed = 50");
                builder.AppendLine("Aim Bone = 5").AppendLine();
            }
            foreach (var weapon in heavyList)
            {
                builder.AppendLine("[" + weapon + "]");
                //RCS
                builder.AppendLine("Rcs Enabled = False");
                builder.AppendLine("Rcs Start = 1");
                builder.AppendLine("Rcs Force Max Yaw = 2");
                builder.AppendLine("Rcs Force Min Yaw = 2");
                builder.AppendLine("Rcs Force Max Pitch = 2");
                builder.AppendLine("Rcs Force Min Pitch = 2").AppendLine();
                //Trigger
                builder.AppendLine("Trigger Enabled = True");
                builder.AppendLine("Trigger Key = 0x12");
                builder.AppendLine("Trigger Dash = False");
                builder.AppendLine("Trigger When Zoomed = False");
                builder.AppendLine("Trigger Enemies = True");
                builder.AppendLine("Trigger Allies = False");
                builder.AppendLine("Trigger Burst Enabled = False");
                builder.AppendLine("Trigger Spawn Protected = False");
                builder.AppendLine("Trigger Delay FirstShot Max = 35");
                builder.AppendLine("Trigger Delay FirstShot Min = 35");
                builder.AppendLine("Trigger Delay Shots Max = 35");
                builder.AppendLine("Trigger Delay Shots Min = 35").AppendLine();

                //Aim Assist
                builder.AppendLine("Aim Enabled = True");
                builder.AppendLine("Aim Key = 0x12");
                builder.AppendLine("Aim Fov = 50");
                builder.AppendLine("Aim Humanized = True");
                builder.AppendLine("Aim Spotted = True");
                builder.AppendLine("Aim Enemies = True");
                builder.AppendLine("Aim Allies = False");
                builder.AppendLine("Aim Speed = 50");
                builder.AppendLine("Aim Bone = 5").AppendLine();
            }


            if (!File.Exists("Config.ini"))
            {
                var sr = new StreamWriter(@"Config.ini");
                sr.WriteLine(builder);
                sr.Close();
            }
        }

        public int GetInt(string section, string key)
        {
            try
            {
                var keyValue = _data[section][key];
                var setting = int.Parse(keyValue);
                return setting;
            }
            catch (Exception e)
            {
#if DEBUG
                Console.WriteLine("Error: {0},\nSection: {1}\nKey: {2}", e.Message, section, key);
#endif

            }
            return 0;
        }

        public string GetString(string section, string key)
        {
            try
            {
                var keyValue = _data[section][key];
                var setting = keyValue;
                return setting;
            }
            catch (Exception e)
            {
#if DEBUG
                Console.WriteLine("Error: {0},\nSection: {1}\nKey: {2}", e.Message, section, key);
#endif

            }
            return "M4A1";
        }

        public uint GetUInt(string section, string key)
        {
            var keyValue = _data[section][key];
            var setting = uint.Parse(keyValue);
            return setting;
        }

        public float GetFloat(string section, string key)
        {
            try
            {
                var keyValue = _data[section][key];
                var setting = float.Parse(keyValue);
                return setting;
            }
            catch (Exception e)
            {
#if DEBUG
                Console.WriteLine("Error: {0},\nSection: {1}\nKey: {2}", e.Message, section, key);
#endif

            }
            return 0;
        }

        public bool GetBool(string section, string key)
        {
            try
            {
                var keyValue = _data[section][key];
                var setting = bool.Parse(keyValue);
                return setting;
            }
            catch (Exception e)
            {
#if DEBUG
                Console.WriteLine("Error: {0},\nSection: {1}\nKey: {2}", e.Message, section, key);
#endif

            }
            return false;
        }

        public WinAPI.VirtualKeyShort GetKey(string section, string key)
        {
            try
            {
                var keyValue = _data[section][key];
                var button = (WinAPI.VirtualKeyShort)int.Parse(keyValue);
                return button;
            }
            catch (Exception e)
            {
#if DEBUG
                Console.WriteLine("Error: {0},\nSection: {1}\nKey: {2}", e.Message, section, key);
#endif

            }
            return WinAPI.VirtualKeyShort.ACCEPT;
        }
        #endregion
    }
}