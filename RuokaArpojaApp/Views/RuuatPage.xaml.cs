using RuokaArpojaApp.Models;
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

        Ruoka lastSelection;
        void collectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            lastSelection = e.SelectedItem as Ruoka;
        }

        async void poistoNappula_Clicked(object sender, EventArgs e)
        {
            if(lastSelection != null)
            {
            await App.Database.PoistaRuokaAsync(lastSelection);
            collectionView.ItemsSource = await App.Database.HaeRuuatAsync();
            }
        }
    }
}