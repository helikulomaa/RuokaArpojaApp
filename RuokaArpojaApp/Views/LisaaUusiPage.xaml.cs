using RuokaArpojaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RuokaArpojaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LisaaUusiPage : ContentPage
    {
        public LisaaUusiPage()
        {
            InitializeComponent();
        }

        async void lisaysNappula_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ruokaEntry.Text))
            {
                await App.Database.TallennaRuokaAsync(new Ruoka
                {
                    RuuanNimi = ruokaEntry.Text
                });

                ruokaEntry.Text = string.Empty;
            }
        }

        async void palaaNappula_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RuuatPage());
        }
    }
}