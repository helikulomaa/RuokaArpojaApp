using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using RuokaArpojaApp.Models;
using RuokaArpojaApp.Data;
using SQLite;

namespace RuokaArpojaApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async private void btn_arvoEhdotus_Clicked(object sender, EventArgs e)
        {
            var vaihtoehdot = await App.Database.HaeRuuatAsync();
            List<string> vaihtoehtoLista = new List<string>();

            foreach (var vaihtoehto in vaihtoehdot)
            {
                vaihtoehtoLista.Add(vaihtoehto.RuuanNimi);
            }

            Random rnd = new Random();
            int i = rnd.Next(0, vaihtoehtoLista.Count);

            tamanPaivanEhdotus.Text = vaihtoehtoLista[i];
            btn_arvoEhdotus.Text = "Arvo uudeleen!";
        }

        private async void btn_kaikkiVaihtoehdot_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RuuatPage());
        }
    }
}
