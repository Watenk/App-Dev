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

        protected override void OnSleep()
        {
            //Store tamagochiJson
            TamagochiDataStore tamagochiDataStore = DependencyService.Get<TamagochiDataStore>();
            tamagochiDataStore.WriteTamagochiJson(tamagochiDataStore.ReadItem());
        }

        protected override void OnResume()
        {

        }
    }
}