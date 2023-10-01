namespace App_Dev_VisalStudio;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();

        TamagochiDataStore tamagochiDataStore = DependencyService.Get<TamagochiDataStore>();
        CurrentIdTextLabel.Text = tamagochiDataStore.ReadItem().Id.ToString();
	}

    private void NameEntryOnTextChanged(object sender, TextChangedEventArgs e)
    {
        TamagochiDataStore tamagochiDataStore = DependencyService.Get<TamagochiDataStore>();
        tamagochiDataStore.ReadItem().Name = e.NewTextValue;
    }

    private void IdEntryOnTextChanged(object sender, TextChangedEventArgs e)
    {
        TamagochiDataStore tamagochiDataStore = DependencyService.Get<TamagochiDataStore>();
        int newId;
        string newIdString = e.NewTextValue;

        if (int.TryParse(newIdString, out newId))
        {
            tamagochiDataStore.ReadItem().Id = newId;
        }
    }
}