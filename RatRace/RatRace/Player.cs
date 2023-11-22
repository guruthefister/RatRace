namespace RatRace
{
    public class Player
    {
        public string Name;
        private string _password;
        public string Password { get { return _password; } }
        public int Money;
        public List<Bet> Bets;

        public Player(string name, string password, int money)
        {
            Name = name;
            _password = password;
            Money = money;
            Bets = new List<Bet>();
        }

        public bool Login(string name, string password)
        {
            if (name == Name && password == Password)
            {
                return true;
            } 
            return false;
        } 
    }
}
