// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
using RatRace;

RaceManager raceManager = new RaceManager();
raceManager.Load();

Bookmaker bookmaker = new Bookmaker();
Bet bet = bookmaker.PlaceBet(raceManager.Races.First(), raceManager.Rats[1], raceManager.Players.First(), 500);

raceManager.Players.First().Bets.Add(bet);


bookmaker.Save();


