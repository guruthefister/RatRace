namespace RatRace
{
    public class Player
    {
        public string Name;
        private string Password;
        public int Money;
        public List<Bet> Bets;

        public Player(string name, string password, int money)
        {
            Name = name;
            Password = password;
            Money = money;
            Bets = new List<Bet>();
        }
    }
}
