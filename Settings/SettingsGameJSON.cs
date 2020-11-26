using System;
using System.Collections.Generic;
using System.Linq;
using SettingsExceptions;
using Newtonsoft.Json;
using System.IO;
using System.Threading;

namespace OptionsGame
{
    public class SettingsGameJSON
    {
        private const string path = @"GameSettings.json";
        public int Range { get; set; }
        public int Quantity { get; set; }

        public SettingsGameJSON() 
        {
            try
            {
                if(!File.Exists(path))
                    throw new SettingsJSONNotFoundException("Ustawienia nie zostały odnalezione! Nastąpi przywrócenie ustawień domyślnych!");

                using (StreamReader file = File.OpenText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    SettingsGameJSON SF = (SettingsGameJSON)serializer.Deserialize(file, typeof(SettingsGameJSON)); 
                }
            }
            catch(SettingsJSONNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                Thread.Sleep(3000);
                Range = 100;
                Quantity = 10;
            }
        }
        public SettingsGameJSON(int range, int quantity)
        {
            Range = range;
            Quantity = quantity;
        }
        public void SaveSettings(SettingsGameJSON SF)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(SF));
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, SF);
            }
        }
    }
}
