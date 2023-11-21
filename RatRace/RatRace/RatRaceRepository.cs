﻿using System;
using System.Net;
using System.Text.Json;
using Newtonsoft.Json;

namespace RatRace
{
    public abstract class RatRaceRepository
    {
        public RatRaceRepository()
        {
        }
    }

    public class RatRaceRepositoryJSON : RatRaceRepository, IRatRaceRepository
    {
        public List<T>? Read<T>()
        {
            string filePath = String.Format("C:\\Users\\HFGF\\Desktop\\RatRace_filer\\{0}.json", typeof(T).Name);
            string json = File.ReadAllText(filePath);
            List<T>? objects = JsonConvert.DeserializeObject<List<T>>(json);
            return objects;
        }

        public void Save<T>(List<T> objectList)
        {
            if (objectList.Count == 0) {
                return;
            }
            string jsonString = JsonConvert.SerializeObject(objectList);
            string filePath = String.Format("C:\\Users\\HFGF\\Desktop\\RatRace_filer\\{0}.json", objectList.First().GetType().Name);
            File.WriteAllText(filePath, jsonString);
        }
    }
}
