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

        public TamagochiData ReadTamagochiData()
        {
            return LoadLocally();
        }

        public async Task<bool> LoadRemotely()
        {
            if (tamagochiData.Id != 0)
            {
                var httpClient = new HttpClient();

                var response = await httpClient.GetAsync("https://tamagotchi.hku.nl/api/Creatures/" + tamagochiData.Id.ToString());

                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    tamagochiData = JsonConvert.DeserializeObject<TamagochiData>(responseString);
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> SaveRemotely()
        {
            if (tamagochiData.Id != 0)
            {
                var httpClient = new HttpClient();

                var newJson = new StringContent(JsonConvert.SerializeObject(tamagochiData), Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync("https://tamagotchi.hku.nl/api/Creatures/" + tamagochiData.Id.ToString(), newJson);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            return false;
        }

        public void SaveLocally()
        {
            string tamagochiDirPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "App_Dev_VisalStudio");
            if (!Directory.Exists(tamagochiDirPath))
            {
                Directory.CreateDirectory(tamagochiDirPath);
            }

            string tamagochiPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "App_Dev_VisalStudio/Tamagochi.json");
            string newTamagochiJson = JsonConvert.SerializeObject(tamagochiData);
            File.WriteAllText(tamagochiPath, newTamagochiJson);
        }

        private TamagochiData LoadLocally()
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
                SaveLocally();
                return newTamagochiJson;
            }
        }
    }
}
