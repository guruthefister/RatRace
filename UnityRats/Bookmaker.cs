using System.Collections.Generic;

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
            player.Money += (money * -1);
            return bet;
        }

        public Bookmaker(IRatRaceRepository repo)
        {
            BetRepository = repo;
        }

        public void PayOutWinnings()
        {
            List<Bet> betsToRemove = new List<Bet>();
            foreach (var bet in Bets)
            {
                if (bet.PayWinnings())
                {
                    betsToRemove.Add(bet);
                }
            }

            foreach (var bet in betsToRemove)
            {
                Bets.Remove(bet);
            }
        }

        public void Save()
        {
            BetRepository.Save<Bet>(Bets);
        }

        public void Load()
        {
            Bets = BetRepository.Read<Bet>();
        }
    }
}
