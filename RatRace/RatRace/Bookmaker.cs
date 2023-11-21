namespace RatRace
{
    public class Bookmaker
    {
        public List<Bet> Bets = new List<Bet>();

        public Bet PlaceBet(Race race, Rat rat, Player player, int money)
        {
            Bet bet = new Bet(money, player, race, rat);
            Bets.Add(bet);
            return bet;
        }

        public void PayOutWinnings(Bet bet)
        {
            bet.PayWinnings();
        }
    }
}
