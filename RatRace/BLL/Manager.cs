using RatRace;
using RatRaceBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Manager
    {
        public RaceManager raceManager = new RaceManager(new RatRaceRepositoryJSON());
        public Bookmaker bookmaker = new Bookmaker(new RatRaceRepositoryJSON());
    }
}
