using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Timers;

namespace App_Dev_VisalStudio;

public partial class GardenRoomPage : ContentPage
{
    private string currentButton;
    private float timeLeft = 0;
    private int previousRandom = 0;

	public GardenRoomPage()
	{
        //Create UpdateTimer
        var timer = new System.Timers.Timer()
        {
            Interval = 10,
            AutoReset = true
        };
        timer.Elapsed += Update;
        timer.Start();

        InitializeComponent();

        ChooseNewButton();
	}

    private void Update(object sender, ElapsedEventArgs e)
    {
        UpdateValues();
    }

    private void UpdateValues()
    {
        timeLeft -= 10;
    }

    private void ChooseNewButton()
    {
        //get random int
        int randomInt;
        randomInt = GetRandomInt();
        while (randomInt == previousRandom)
        {
            randomInt = GetRandomInt();
        }
        previousRandom = randomInt;

        timeLeft = 1000;

        switch (randomInt)
        {
            case 1:
                currentButton = "button00";
                button00.BackgroundColor = Color.FromRgb(0, 255, 0);
                break;

            case 2:
                currentButton = "button10";
                button10.BackgroundColor = Color.FromRgb(0, 255, 0);
                break;

            case 3:
                currentButton = "button20";
                button20.BackgroundColor = Color.FromRgb(0, 255, 0);
                break;

            case 4:
                currentButton = "button01";
                button01.BackgroundColor = Color.FromRgb(0, 255, 0);
                break;

            case 5:
                currentButton = "button11";
                button11.BackgroundColor = Color.FromRgb(0, 255, 0);
                break;

            case 6:
                currentButton = "button21";
                button21.BackgroundColor = Color.FromRgb(0, 255, 0);
                break;
        }
    }

    private int GetRandomInt()
    {
        Random random = new Random();
        return random.Next(1, 6);
    }

    private void AddValues()
    {
        float multiplier = timeLeft / 200;

        TamagochiDataStore tamagochiDataStore = DependencyService.Get<TamagochiDataStore>();

        if (tamagochiDataStore.ReadItem().Loneliness >= 0)
        {
            tamagochiDataStore.ReadItem().Loneliness -= 0.5f * multiplier;
        }

        if (tamagochiDataStore.ReadItem().Thirst <= 100)
        {
            tamagochiDataStore.ReadItem().Thirst += 1f * multiplier;
        }

        if (tamagochiDataStore.ReadItem().Hunger <= 100)
        {
            tamagochiDataStore.ReadItem().Hunger += 0.8f * multiplier;
        }

        if (tamagochiDataStore.ReadItem().Boredom >= 0)
        {
            tamagochiDataStore.ReadItem().Boredom -= 2f * multiplier;
        }

        if (tamagochiDataStore.ReadItem().tired <= 100)
        {
            tamagochiDataStore.ReadItem().tired += 2f * multiplier;
        }

        if (tamagochiDataStore.ReadItem().Stimulated <= 100)
        {
            tamagochiDataStore.ReadItem().Stimulated += 3f * multiplier;
        }
    }

    private async void ClickAnimation(VisualElement visualElement)
    {
        visualElement.ScaleTo(1.2);
        await visualElement.RotateTo(5, 100);
        await visualElement.RotateTo(-5, 200);
        await visualElement.RotateTo(0, 100);
        visualElement.ScaleTo(1);
    }

    private void button00OnClicked(object sender, EventArgs e)
    {
        if (currentButton == "button00")
        {
            AddValues();
            ClickAnimation(button00);

            button00.BackgroundColor = Color.FromRgb(255, 0, 0);
            ChooseNewButton();
        }
    }

    private void button10OnClicked(object sender, EventArgs e)
    {
        if (currentButton == "button10")
        {
            AddValues();
            ClickAnimation(button10);

            button10.BackgroundColor = Color.FromRgb(255, 0, 0);
            ChooseNewButton();
        }
    }

    private void button20OnClicked(object sender, EventArgs e)
    {
        if (currentButton == "button20")
        {
            AddValues();
            ClickAnimation(button20);

            button20.BackgroundColor = Color.FromRgb(255, 0, 0);
            ChooseNewButton();
        }
    }

    private void button01OnClicked(object sender, EventArgs e)
    {
        if (currentButton == "button01")
        {
            AddValues();
            ClickAnimation(button01);

            button01.BackgroundColor = Color.FromRgb(255, 0, 0);
            ChooseNewButton();
        }
    }

    private void button11OnClicked(object sender, EventArgs e)
    {
        if (currentButton == "button11")
        {
            AddValues();
            ClickAnimation(button11);

            button11.BackgroundColor = Color.FromRgb(255, 0, 0);
            ChooseNewButton();
        }
    }

    private void button21OnClicked(object sender, EventArgs e)
    {
        if (currentButton == "button21")
        {
            AddValues();
            ClickAnimation(button21);

            button21.BackgroundColor = Color.FromRgb(255, 0, 0);
            ChooseNewButton();
        }
    }
}