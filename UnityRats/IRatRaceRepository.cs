using System;
using System.Collections.Generic;

namespace RatRace
{
    public interface IRatRaceRepository
    {
        public List<T>? Read<T>();
        public void Save<T>(List<T> objectList);
    }
}
