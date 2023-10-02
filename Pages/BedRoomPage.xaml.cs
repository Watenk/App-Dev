using System.Timers;

namespace App_Dev_VisalStudio;

public partial class BedRoomPage : ContentPage
{
    bool isSleeping;

	public BedRoomPage()
	{
        InitializeComponent();

        //Create UpdateTimer
        var timer = new System.Timers.Timer()
        {
            Interval = 1000,
            AutoReset = true
        };
        timer.Elapsed += Update;
        timer.Start();

        isSleeping = false;
        TamagochiDataStore tamagochiDataStore = DependencyService.Get<TamagochiDataStore>();
        fatigueSlider.Value = tamagochiDataStore.ReadItem().Fatigue;
    }

    public void Update(object sender, ElapsedEventArgs e)
    {
        RemoveFatigue();
    }

    private void RemoveFatigue()
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            if (isSleeping)
            {
                TamagochiDataStore tamagochiDataStore = DependencyService.Get<TamagochiDataStore>();
                tamagochiDataStore.ReadItem().Fatigue -= 1;
                fatigueSlider.Value = tamagochiDataStore.ReadItem().Fatigue;
            }
        });
    }

    private void sleepButtonOnClicked(object sender, EventArgs e)
    {
        isSleeping = !isSleeping;

        if (isSleeping)
        {
            sleepButton.Text = "Wake Up!";
            sleepButton.BackgroundColor = Color.FromRgb(0, 255, 0);
            sleepButton.TextColor = Color.FromRgb(0, 0, 0);
            BackgroundImageSource = "sleepingpoekie.jpg";
        }
        else
        {
            sleepButton.BackgroundColor = Color.FromRgb(255, 0, 0);
            sleepButton.Text = "Sleep!";
            sleepButton.TextColor = Color.FromRgb(255, 255, 255);
            BackgroundImageSource = "notsleepingpoekie.jpeg";
        }
    }
}