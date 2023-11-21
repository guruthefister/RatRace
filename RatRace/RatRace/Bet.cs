namespace RatRace
{
    public class Bet
    {
        private int _money;
        private Player _player;
        private Race _race;
        private Rat _rat;

        public void PayWinnings()
        {
            if (_rat == _race.GetWinner())
            {
                _player.Money += _money * 2;
                //lav en pulje med prisen i stedet
            }
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
