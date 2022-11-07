using RuokaArpojaApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RuokaArpojaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RuuatPage : ContentPage
    {
        public RuuatPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Noutaa kaikki ruuat tietokannasta ja asettaa ne collectionViewn sourceksi.
            collectionView.ItemsSource = await App.Database.HaeRuuatAsync();
        }

        async void lisaaUusinappula_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LisaaUusiPage());
        }
    }
}