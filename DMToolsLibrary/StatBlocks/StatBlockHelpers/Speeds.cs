﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolsLibrary.StatBlocks.StatBlockHelpers
{
    public class Speeds
    {
        private string[] speed;
        private bool hover;
        
        private enum SpeedType
        {
            speed = 0,
            burrow,
            climb,
            fly,
            swim,
        }
        public Speeds(string speed,
            string burrowSpeed,
            string climbSpeed,
            string flySpeed,
            string swimSpeed,
            bool hover)
        {
            this.hover = hover;
            this.speed = new string[]
            {
                speed,
                burrowSpeed,
                climbSpeed,
                flySpeed,
                swimSpeed,
            };
        }

        public string Speed { get => this.speed[(int)SpeedType.speed]; }
        public string Burrow { get => this.speed[(int)SpeedType.burrow]; }
        public string Climb { get => this.speed[(int)SpeedType.climb]; }
        public string Fly { get => this.speed[(int)SpeedType.fly]; }
        public string Swim { get => this.speed[(int)SpeedType.swim]; }
        public bool Hover
        {
            get => this.hover;
            set => this.hover = value;
        }

        public override string ToString()
        {
            StringBuilder movementStr = new StringBuilder();
            for (int i = 0; i < this.speed.Length; i++)
            {
                string speed = this.speed[i];
                if (speed != "0")
                {
                    string appendTo = string.Empty;
                    if (i == (int)SpeedType.speed)
                    {
                        appendTo = "<b>Speed</b> " + speed + " ft., ";
                    }
                    else if (i == (int)SpeedType.swim)
                    {
                        appendTo = (SpeedType)i + " " + speed + " ft.";
                    }
                    else
                    {
                        appendTo = (SpeedType)i + speed + " ft., ";
                    }

                    movementStr.Append(appendTo);
                }
            }

            if (hover)
            {
                movementStr.Append(" (hover)");
            }

            return movementStr.ToString();
        }
    }
}
