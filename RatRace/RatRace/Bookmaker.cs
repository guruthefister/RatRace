namespace RatRace
{
    public class Bookmaker
    {
        public List<Bet> Bets = new List<Bet>();
        public IRatRaceRepository BetRepository;

        public Bet PlaceBet(Race race, Rat rat, Player player, int money)
        {
            Bet bet = new Bet(money, player, race, rat);
            Bets.Add(bet);
            player.Money -= money;
            return bet;
        }
        public Bookmaker()
        {
            BetRepository = new RatRaceRepositoryJSON();
        }

        public void PayOutWinnings(Bet bet)
        {
            bet.PayWinnings();
        }

        public void Save()
        {
            Console.WriteLine(Bets.Count);
            BetRepository.Save<Bet>(Bets);
        }
    }
}
