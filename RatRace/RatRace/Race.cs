using System.Collections.Specialized;

namespace RatRace
{
    public class Race
    {
        public int RaceID;
        public List<Rat> Rats;
        public Track RaceTrack;
        private Rat _winner;
        private string _log;

        public void ConductRace()
        {
            while (_winner == null)
            {
                foreach (var rat in Rats)
                {
                    rat.MoveRat(this);
                    if(rat.Position >= RaceTrack.TrackLength)
                    {
                        _winner = rat;
                    }
                }
            }
        }

        public Rat GetWinner()
        {
            if(_winner != null) return _winner;

            int currentHighestPosition = 0;

            foreach (var rat in Rats)
            {
                if (rat.Position > currentHighestPosition)
                {
                    currentHighestPosition = rat.Position;
                    _winner = rat;
                }
            }
            return _winner;
        }

        public string GetLog()
        {
            return _log;
        }

        public void LogRace(Rat rat)
        {
            string newLog = String.Format("Rat {0}, har løbet {1}/{2};", rat.Name, rat.Position, RaceTrack.TrackLength);
            _log += newLog;
        }

        public Race(int raceid, List<Rat> rats, Track racetrack)
        {
            RaceID = raceid;
            Rats = rats;
            RaceTrack = racetrack;
        }
    }
}
