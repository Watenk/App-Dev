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
        fatigueSlider.Value = tamagochiDataStore.ReadItem().tired;
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

                if (tamagochiDataStore.ReadItem().tired >= 0)
                {
                    tamagochiDataStore.ReadItem().tired -= 1;
                }

                if (tamagochiDataStore.ReadItem().tired >= 0)
                {
                    tamagochiDataStore.ReadItem().Stimulated -= 0.5f;
                }

                if (tamagochiDataStore.ReadItem().tired <= 100)
                {
                    tamagochiDataStore.ReadItem().Boredom += 0.5f;
                }

                fatigueSlider.Value = tamagochiDataStore.ReadItem().tired;
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