namespace RatRace
{
    public class Rat
    {
        public string Name;
        private int _position;
        public int Position { get { return _position; } set { _position = value; } }

        public void ResetRat()
        {
            _position = 0;
        }

        public int MoveRat(Race race)
        {
            int lower = RNG.Range(0, 5);
            int upper = RNG.Range(6, 10);
            _position += RNG.Range(lower, upper);
            race.LogRace(this);
            return _position;
        }

        public Rat(string name)
        {
            Name = name;
            _position = 0;
        }
    }
}
