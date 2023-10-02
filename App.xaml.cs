using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;

namespace App_Dev_VisalStudio
{
    public partial class App : Application
    {
        public App()
        {
            DependencyService.RegisterSingleton<TamagochiDataStore>(new TamagochiDataStore());

            //Load tamagochiJson
            TamagochiDataStore tamagochiDataStore = DependencyService.Get<TamagochiDataStore>();
            tamagochiDataStore.CreateItem(tamagochiDataStore.ReadTamagochiData());

            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnSleep()
        {
            TamagochiDataStore tamagochiDataStore = DependencyService.Get<TamagochiDataStore>();
            tamagochiDataStore.SaveLocally();
        }
    }
}