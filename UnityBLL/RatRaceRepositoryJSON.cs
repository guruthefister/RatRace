﻿using System;
using System.IO;
using System.Linq;
using System.Net;
using RatRace;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace RatRaceBLL
{
    public class RatRaceRepositoryJSON : IRatRaceRepository
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
            if (objectList.Count == 0)
            {
                return;
            }
            string jsonString = JsonConvert.SerializeObject(objectList);
            string filePath = String.Format("C:\\Users\\HFGF\\Desktop\\RatRace_filer\\{0}.json", objectList.First().GetType().Name);
            File.WriteAllText(filePath, jsonString);
        }
    }
}
