namespace App_Dev_VisalStudio;
using System.Timers;

public partial class StatsUIView : ContentView
{
    public StatsUIView()
    {
        var timer = new Timer()
        {
            Interval = 5000,
            AutoReset = true
        };
        timer.Elapsed += Update;
        timer.Start();

        InitializeComponent();

        UpdateStatValues();
    }

    private void Update(object sender, ElapsedEventArgs e)
    {
        UpdateStatValues();
    }

    private void UpdateStatValues()
    {
        TamagochiDataStore tamagochiDataStore = DependencyService.Get<TamagochiDataStore>();

        MainThread.BeginInvokeOnMainThread(() =>
        {
            HungerSlider.Value = tamagochiDataStore.ReadItem().Hunger;
            ThirstSlider.Value = tamagochiDataStore.ReadItem().Thirst;
        });
    }
}