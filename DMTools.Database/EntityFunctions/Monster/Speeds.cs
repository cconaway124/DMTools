using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMTools.Database.Entities;

public partial class Speeds
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
    public Speeds() { }

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

        this.SetSpeeds();
    }

    /*public string Speed { get => this.speed[(int)SpeedType.speed]; }
    public string Burrow { get => this.speed[(int)SpeedType.burrow]; }
    public string Climb { get => this.speed[(int)SpeedType.climb]; }
    public string Fly { get => this.speed[(int)SpeedType.fly]; }
    public string Swim { get => this.speed[(int)SpeedType.swim]; }
    public bool Hover
    {
        get => this.hover;
        set => this.hover = value;
    }*/

    public void SetSpeeds()
    {
        for (int i = 0; i < this.speed.Length; i++)
        {
            bool val = int.TryParse(this.speed[i], out int a);
            switch ((SpeedType)i)
            {
                case SpeedType.speed:
                    this.Speed = val ? a : null;
                    break;

                case SpeedType.burrow:
                    this.Burrow = val ? a : null;
                    break;

                case SpeedType.climb:
                    this.Climb = val ? a : null;
                    break;

                case SpeedType.fly:
                    this.Fly = val ? a : null;
                    break;

                case SpeedType.swim:
                    this.Swim = val ? a : null;
                    break;
                default: break;
            }
        }
        this.Hover = this.hover;
    }

    public override string ToString()
    {
        StringBuilder movementStr = new StringBuilder();
        int count = 0;
        for (int i = 0; i < this.speed.Length; i++)
        {
            string speed = this.speed[i];
            if (speed != "0")
            {
                if (count != 0)
                    movementStr.Append(", ");

                if ((SpeedType)i == SpeedType.speed)
						movementStr.Append($"{speed} ft.");
                else
					    movementStr.Append($"{(SpeedType)i} {speed} ft.");
                
                count++;
            }
        }

        if (hover)
        {
            movementStr.Append(" (hover)");
        }

        return movementStr.ToString();
    }
}
