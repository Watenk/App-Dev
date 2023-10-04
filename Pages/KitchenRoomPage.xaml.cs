namespace App_Dev_VisalStudio;

public partial class KitchenRoomPage : ContentPage
{
	public KitchenRoomPage()
	{
		InitializeComponent();
	}

    private async void EatButtonOnClicked(object sender, EventArgs e)
    {
        TamagochiDataStore tamagochiDataStore = DependencyService.Get<TamagochiDataStore>();

        if (tamagochiDataStore.ReadItem().Hunger >= 0)
        {
            tamagochiDataStore.ReadItem().Hunger -= 5;

            await ClickAnimation(EatButton);
        }
    }

    private async void DrinkButtonOnClicked(object sender, EventArgs e)
    {
        TamagochiDataStore tamagochiDataStore = DependencyService.Get<TamagochiDataStore>();

        if (tamagochiDataStore.ReadItem().Thirst >= 0)
        {
            tamagochiDataStore.ReadItem().Thirst -= 5;

            await ClickAnimation(DrinkButton);
        }
    }

    private async Task<bool> ClickAnimation(VisualElement visualElement)
    {
        BackgroundImageSource = "eatingpoekie.png";
        visualElement.ScaleTo(1.5);
        await visualElement.RotateTo(10, 50);
        await visualElement.RotateTo(-20, 100);
        await visualElement.RotateTo(0, 50);
        visualElement.ScaleTo(1);

        BackgroundImageSource = "noteatingpoekie.png";

        return true;
    }
}