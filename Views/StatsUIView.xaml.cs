namespace App_Dev_VisalStudio;
using System.Timers;

public partial class StatsUIView : ContentView
{
    public StatsUIView()
    {
        InitializeComponent();

        var timer = new Timer()
        {
            Interval = 1000,
            AutoReset = true
        };
        timer.Elapsed += Update;
        timer.Start();

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