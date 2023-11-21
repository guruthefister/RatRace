using System.Xml.Linq;

namespace RatRace
{
    public class RaceManager
    {
        public List<Track> Tracks;
        public List<Player> Players;
        public List<Race> Races;
        public List<Rat> Rats;
        public IRatRaceRepository RaceRepository;

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

        public RaceManager()
        {
            RaceRepository = new RatRaceRepositoryJSON();
            Races = new List<Race>();
            Players = new List<Player>();
            Rats = new List<Rat>();
            Tracks = new List<Track>();
        }

        public void Save()
        {
            RaceRepository.Save<Player>(Players);
            RaceRepository.Save<Track>(Tracks);
            RaceRepository.Save<Race>(Races);
            RaceRepository.Save<Rat>(Rats);
        }

        public void Load()
        {
            Races = RaceRepository.Read<Race>();
            Players = RaceRepository.Read<Player>();
            Rats = RaceRepository.Read<Rat>();
            Tracks = RaceRepository.Read<Track>();
        }
    }
}
