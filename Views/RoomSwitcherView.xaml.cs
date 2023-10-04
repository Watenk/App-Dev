namespace App_Dev_VisalStudio;

public partial class RoomSwitcherView : ContentView
{
	public RoomSwitcherView()
	{
		InitializeComponent();
	}

    private async void KitchenRoomButtonOnClicked(object sender, EventArgs e)
    {
        await ClickAnimation(KitchenRoomButton);

        Navigation.PushAsync(new KitchenRoomPage());
    }

    private async void GardenRoomButtonOnClicked(object sender, EventArgs e)
    {
        await ClickAnimation(GardenRoomButton);

        Navigation.PushAsync(new GardenRoomPage());
    }

    private async void BedRoomButtonOnClicked(object sender, EventArgs e)
    {
        await ClickAnimation(BedRoomButton);

        Navigation.PushAsync(new BedRoomPage());
    }

    private async void SettingsRoomButtonOnClicked(object sender, EventArgs e)
    {
        await ClickAnimation(SettingsRoomButton);

        Navigation.PushAsync(new SettingsPage());
    }

    private async Task<bool> ClickAnimation(VisualElement visualElement)
    {
        visualElement.ScaleTo(1.5);
        await visualElement.RotateTo(10, 50);
        await visualElement.RotateTo(-20, 100);
        await visualElement.RotateTo(0, 50);
        visualElement.ScaleTo(1);

        return true;
    }
}