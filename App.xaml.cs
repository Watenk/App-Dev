namespace App_Dev_VisalStudio
{
    public partial class App : Application
    {
        public App()
        {
            DependencyService.RegisterSingleton<TamagochiDataStore>(new TamagochiDataStore());

            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}