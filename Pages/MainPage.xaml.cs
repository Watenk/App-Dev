using System.Diagnostics;
using System.Timers;

namespace App_Dev_VisalStudio
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            //Create UpdateTimer
            var timer = new System.Timers.Timer()
            {
                Interval = 5000,
                AutoReset = true
            };
            timer.Elapsed += Update;
            timer.Start();

            InitializeComponent();

            //Update Values
            TamagochiDataStore tamagochiDataStore = DependencyService.Get<TamagochiDataStore>();
            NameText.Text = tamagochiDataStore.ReadItem().Name.ToString();
        }

        //Update
        /////////////////////////////////////////////////////////////////

        private void Update(object sender, ElapsedEventArgs e)
        {
            CheckValues();
        }

        private void CheckValues()
        {
            //Check here if tamagochi values are right or wrong
        }

        //OnImageClicked
        ///////////////////////////////////////////////////////////////////

        private void OnImageClicked(object sender, TappedEventArgs e)
        {
            CalcValuesOnImageClicked();
            AnimationOnImageClicked();
        }

        private void CalcValuesOnImageClicked()
        {
            TamagochiDataStore tamagochiDataStore = DependencyService.Get<TamagochiDataStore>();
            TamagochiData newTamagochiData = tamagochiDataStore.ReadItem();

            if (tamagochiDataStore.ReadItem().Fatigue <= 90)
            {
                newTamagochiData.Fatigue += 10;
            }

            if (tamagochiDataStore.ReadItem().Stimulated <= 90)
            {
                newTamagochiData.Stimulated += 10;
            }

            tamagochiDataStore.UpdateItem(newTamagochiData);
        }

        private async void AnimationOnImageClicked()
        {
            defaultPoekieImage.ScaleTo(4, 100);
            await defaultPoekieImage.RotateTo(5, 100);
            defaultPoekieImage.ScaleTo(3, 100);
            await defaultPoekieImage.RotateTo(0, 100);
        }

        /////////////////////////////////////////////////////////////////////////
    }
}