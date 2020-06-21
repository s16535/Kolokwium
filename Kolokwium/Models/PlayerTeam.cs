using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class PlayerTeam
    {
        public int IdPlayer { get; set; }
        public Player Player { get; set; }
        public int IdTeam { get; set; }
        public Team Team { get; set; }
        public int NumOnShirt { get; set; }
        public string? Comment { get; set; }
    }
}
