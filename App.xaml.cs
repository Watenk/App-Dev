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

        //Save On Android
        protected override void OnSleep()
        {
            TamagochiDataStore tamagochiDataStore = DependencyService.Get<TamagochiDataStore>();
            tamagochiDataStore.SaveLocally();
        }

        //Save On Windows
        protected override Window CreateWindow(IActivationState activationState)
        {
            Window window = base.CreateWindow(activationState);

            window.Destroying += (s, e) =>
            {
                TamagochiDataStore tamagochiDataStore = DependencyService.Get<TamagochiDataStore>();
                tamagochiDataStore.SaveLocally();
            };

            return window;
        }
    }
}