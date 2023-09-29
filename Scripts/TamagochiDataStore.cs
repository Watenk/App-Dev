using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Resources;
using System.Text;

namespace App_Dev_VisalStudio
{
    public class TamagochiDataStore : IDataStore<TamagochiData>
    {
        private TamagochiData tamagochiData;

        public void CreateItem(TamagochiData data)
        {
            tamagochiData = data;
        }

        public TamagochiData ReadItem()
        {
            return tamagochiData;
        }

        public void UpdateItem(TamagochiData data)
        {
            tamagochiData = data;
        }

        public void DeleteItem()
        {
            tamagochiData = null;
        }

        public TamagochiData ReadTamagochiJson()
        {
            string tamagochiPath = Path.Combine(AppContext.BaseDirectory, "Tamagochi.json");
            string tamagochiJson = File.ReadAllText(tamagochiPath);
            return JsonConvert.DeserializeObject<TamagochiData>(tamagochiJson);
        }

        public void WriteTamagochiJson(TamagochiData TamagochiData)
        {
            string tamagochiPath = Path.Combine(AppContext.BaseDirectory, "Tamagochi.json");
            string newTamagochiJson = JsonConvert.SerializeObject(TamagochiData);
            File.WriteAllText(tamagochiPath, newTamagochiJson);
        }
    }
}
