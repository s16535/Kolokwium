using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class ChampionshipTeam
    {
        public int IdTeam { get; set; }
        public Team Team { get; set; }
        public int IdChampionship { get; set; }
        public Championship Championship { get; set; }
        public float Score { get; set; }
    }
}
