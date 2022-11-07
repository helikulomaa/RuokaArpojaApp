using System;
using System.IO;
using RuokaArpojaApp.Data;
using Xamarin.Forms;

namespace RuokaArpojaApp
{
    public partial class App : Application
    {
        static RuokaArpojaDatabase database;

        //Luo tietokantayhteyden
        public static RuokaArpojaDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new RuokaArpojaDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Ruuat.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage (new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
