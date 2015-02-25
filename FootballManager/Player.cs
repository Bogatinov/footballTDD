using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager
{
    public class Player
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public enum PlayerPosition
    {
        GK,
        SW,
        CB,
        LB,
        RB,
        RWB,
        LWB,
        DM,
        CM,
        AM,
        LW,
        RW,
        WF,
        CF
    }
}