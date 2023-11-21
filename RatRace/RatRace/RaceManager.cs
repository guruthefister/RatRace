namespace RatRace
{
    public class RaceManager
    {
        public List<Track> Tracks;
        public List<Player> Players;
        public List<Race> Races;
        public List<Rat> Rats;

        public Race CreateRace(int raceID, List<Rat> rats, Track track)
        {
            return new Race(raceID, rats, track);
        }

        public Track CreateTrack(string name, int tracklength)
        {
            return new Track(name, tracklength);
        }

        public void ConductRace(Race race)
        {
            if(!Races.Contains(race))
            {
                return;
            }
            race.ConductRace();
        }

        public string ViewLog(Race race)
        {
            return race.GetLog();
        }

        public Rat CreateRat(string name)
        {
            return new Rat(name);
        }

        public Player CreatePlayer(string name, string password, int money)
        {
            return new Player(name, password, money);
        }
    }
}
