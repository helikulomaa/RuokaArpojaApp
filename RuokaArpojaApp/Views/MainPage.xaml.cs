using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using RuokaArpojaApp.Models;

namespace RuokaArpojaApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btn_arvoEhdotus_Clicked(object sender, EventArgs e)
        {
            List<String> vaihtoehdot = new List<String>() { "Makaronilaatikko", "Nakkikastike ja perunat", "Uuniperunat", "Tortillot", "Pitsa", "Pinaattikeitto", "Kasvissosekeitto", "Hernekeitto" };
            Random rnd = new Random();
            int i = rnd.Next(0, 8);

            tamanPaivanEhdotus.Text = vaihtoehdot[i];
            btn_arvoEhdotus.Text = "Arvo uudeleen!";
        }

        private async void btn_kaikkiVaihtoehdot_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RuuatPage());
        }
    }
}
