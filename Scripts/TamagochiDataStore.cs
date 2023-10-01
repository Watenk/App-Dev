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
            string tamagochiPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "App_Dev_VisalStudio/Tamagochi.json");

            if (File.Exists(tamagochiPath))
            {
                string tamagochiJson = File.ReadAllText(tamagochiPath);
                return JsonConvert.DeserializeObject<TamagochiData>(tamagochiJson);
            }
            else
            {
                TamagochiData newTamagochiJson = new TamagochiData();
                WriteTamagochiJson(newTamagochiJson);
                return newTamagochiJson;
            }
        }

        public void WriteTamagochiJson(TamagochiData TamagochiData)
        {
            string tamagochiDirPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "App_Dev_VisalStudio");
            if (!Directory.Exists(tamagochiDirPath))
            {
                Directory.CreateDirectory(tamagochiDirPath);
            }

            string tamagochiPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "App_Dev_VisalStudio/Tamagochi.json");
            string newTamagochiJson = JsonConvert.SerializeObject(TamagochiData);
            File.WriteAllText(tamagochiPath, newTamagochiJson);
        }
    }
}
