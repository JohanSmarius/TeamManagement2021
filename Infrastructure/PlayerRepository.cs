using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;

namespace Infrastructure
{
    public class PlayerRepository
    {
        public List<Player> GetPlayers()
        {
            return PlayerSeeder.SeedPlayers();
        }
    }
}
