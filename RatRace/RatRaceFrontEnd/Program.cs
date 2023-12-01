using BLL;
using RatRace;

Manager manager = new Manager();
RaceManager raceManager = manager.raceManager;
raceManager.Load();
Bookmaker bookmaker = manager.bookmaker;
bookmaker.Load();

Player? player = null;
while(player == null)
{
    Console.WriteLine("1. Create an account.");
    Console.WriteLine("2. Login to an existing account.");

    string userInput = AskForInput("Choose an option (1-2): ");
    switch (userInput)
    {
        case "1": //create account
            string username = AskForInput("New username: ");
            string password1 = AskForInput("New password: ");
            string password2 = AskForInput("Confirm password: ");

            if (password1 != password2)
            {
                Console.WriteLine("Passwords didn't match. Please try again.");
                break;
            }

            if (raceManager.PlayerLogin(username, password1) != null)
            {
                Console.WriteLine("User already exists. Please try again.");
                break;
            }

            player = raceManager.CreatePlayer(username, password1, 5000);
            SaveAll();
            break;

        case "2": //Login to account
            string name = AskForInput("Username: ");
            string password = AskForInput("Password: ");
            player = raceManager.PlayerLogin(name, password);
            if (player == null)
            {
                Console.WriteLine("Username or password is incorrect. Please try again.");
            }
            break;
    }
}

bool userWantsToContinue = true;
while (userWantsToContinue) 
{
    Race race = CreateRace();
    Console.WriteLine("Player Info: ");
    Console.WriteLine(String.Format("   - Name: {0}", player.Name));
    Console.WriteLine(String.Format("   - Money: {0}", player.Money));
    Console.WriteLine();

    Console.WriteLine("Race info: ");
    Console.WriteLine(String.Format("   - Track length: {0}", race.RaceTrack.TrackLength));
    Console.WriteLine(String.Format("   - Number of rats: {0}", race.Rats.Count));
    Console.WriteLine(String.Format("   - Minimum bet size: {0}", race.MinBetSize));
    string joinAnotherRace = AskForInput("Do you wish to join this race? (y/n)").ToLower();

    if (joinAnotherRace == "n" || joinAnotherRace == "no")
    {
        continue;
    }

    Bet? bet = RatBetting(race);
    while (bet == null) 
    { 
        Console.WriteLine("Something went wrong");
        bet = RatBetting(race);
    }

    race.ConductRace();
    bookmaker.PayOutWinnings();
    SaveAll();
    
    if (bet.Winnings > 0)
    {
        Console.WriteLine(String.Format("You won!\n{0} won the race.\n The payout was {1}, your new total is {2}.", race.GetWinner().Name,bet.Winnings, player.Money));
        string doYouWishToContinueBetting = AskForInput("Do you want to do another bet (y/n): ").ToLower();
        if (doYouWishToContinueBetting == "n" || doYouWishToContinueBetting == "no")
        {
            break;
        }

        continue;
    } else 
    {
        Console.WriteLine(String.Format("\nYou Lost!\n{0} won the race.\nYour new total is {2}.", race.GetWinner().Name, bet.Winnings, player.Money));
        string doYouWishToContinueBetting = AskForInput("Do you want to do another bet (y/n): ").ToLower();
        if (doYouWishToContinueBetting == "n" || doYouWishToContinueBetting == "no")
        {
            break;
        }

        continue;
    }
}

Bet? RatBetting(Race race)
{
    bool done = false;
    while (!done)
    {
        RatNames(race);
        string ratToBet = AskForInput("Which rat would you like to bet on: ").ToLower();
        Rat? rat = race.Rats.Find(rat => rat.Name.ToLower() == ratToBet || rat.Name.ToLower() == "rat " + ratToBet);
        if (rat == null)
        {
            Console.WriteLine("Rat doesn't exist. Try another rat.");
            continue;
        }

        string betSizeString = String.Format("How much would you like to bet (min: {0}) (max: {1}): ", race.MinBetSize, player.Money);
        int betSize = int.Parse(AskForInput(betSizeString));

        if (player.Money < betSize) 
        {
            Console.WriteLine("Not enough money. Try another a lower amount.");
            continue;
        }

        if (race.MinBetSize > betSize)
        {
            Console.WriteLine("Betsize is too low. Try another a higher amount.");
            continue;
        }

        Bet? bet = bookmaker.PlaceBet(race, rat, player, betSize);
        Console.WriteLine(String.Format("\nBet money: {0}\n", bet.Money));
        Console.WriteLine(String.Format("\nPlayer money: {0}\n", player.Money));
        done = true;
        return bet;
    }
    return null;
}

void RatNames(Race race)
{
    foreach (var rat in race.Rats)
    {
        Console.WriteLine(String.Format("Name: {0}", rat.Name));
    }
}

Race CreateRace()
{
    int numberOfRats = RNG.Range(2, 10);
    List<Rat> rats = new List<Rat>();
    for (int i = 0; i < numberOfRats; i++)
    {
        Rat rat = raceManager.CreateRat("Rat " + (i + 1));
        rats.Add(rat);
    }

    int lengthsOfTrack = RNG.Range(100, 500);
    Track track = raceManager.CreateTrack("Track " + lengthsOfTrack, lengthsOfTrack);

    int raceID = RNG.Range(1, 1000);
    Race race = raceManager.CreateRace(raceID, rats, track);
    return race;
}

string AskForInput(string input)
{
    Console.Write(input);
    string userInput = Console.ReadLine();
    return userInput;
}

void SaveAll ()
{
    raceManager.Save();
    bookmaker.Save();
}
