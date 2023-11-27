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
            Race race = new Race(raceID, rats, track);
            Races.Add(race);
            return race;
        }

        public Track CreateTrack(string name, int tracklength)
        {
            Track track = new Track(name, tracklength);
            Tracks.Add(track);
            return track;
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
            Rat rat = new Rat(name);
            Rats.Add(rat);
            return rat;
        }

        public Player CreatePlayer(string name, string password, int money)
        {
            Player player = new Player(name, password, money);
            Players.Add(player);
            return player;
        }

        public RaceManager(IRatRaceRepository repo)
        {
            RaceRepository = repo;
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

        public Player? PlayerLogin(string name, string password)
        {
            foreach(var player in Players)
            {
                if (player.Login(name, password))
                {
                    return player;
                }
            }
            return null;
        }
    }
}
