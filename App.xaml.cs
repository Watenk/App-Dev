using System.Diagnostics;

namespace App_Dev_VisalStudio
{
    public partial class App : Application
    {
        public App()
        {
            DependencyService.RegisterSingleton<TamagochiDataStore>(new TamagochiDataStore());

            //Load tamagochiJson
            TamagochiDataStore tamagochiDataStore = DependencyService.Get<TamagochiDataStore>();
            tamagochiDataStore.CreateItem(tamagochiDataStore.ReadTamagochiJson());

            InitializeComponent();
            MainPage = new AppShell();
        }

        //Save Data on Android
        protected override void OnSleep()
        {
            SaveTamagochiJson();
        }

        //Save Data on windows
        protected override Window CreateWindow(IActivationState activationState)
        {
            Window window = base.CreateWindow(activationState);

            window.Destroying += (s, e) =>
            {
                SaveTamagochiJson();
            };

            return window;
        }

        private void SaveTamagochiJson()
        {
            TamagochiDataStore tamagochiDataStore = DependencyService.Get<TamagochiDataStore>();
            tamagochiDataStore.WriteTamagochiJson(tamagochiDataStore.ReadItem());
        }
    }
}