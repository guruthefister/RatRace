namespace RatRace
{
    public class Bet
    {
        private int _money;
        public int Money { get { return _money; } }
        private Player _player;
        public Player Player { get { return _player; } }
        private Race _race;
        public Race Race { get { return _race; } }
        private Rat _rat;
        public Rat Rat { get { return _rat; } }
        public int Winnings = 0;

        public bool PayWinnings()
        {
            if (!RaceFinished()) { return false;  }
            if (_rat == _race.GetWinner())
            {
                Winnings = _money * 2;
                _player.Money =  _player.Money + Winnings;
                return true;
            }

            Winnings = _money * -1;
            return true;
        }

        private bool RaceFinished()
        {
            return _race.GetWinner() != null;
        }

        public Bet(int money, Player player, Race race, Rat rat)
        {
            _money = money;
            _player = player;
            _race = race;
            _rat = rat;
        }
    }
}
