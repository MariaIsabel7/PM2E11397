using PM02IP_EXAMEN.Controllers;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM02IP_EXAMEN
{
    public partial class App : Application
    {
        static DataBaseSQLite dataBaseSQLite;

        public static DataBaseSQLite DataBaseSQLite
        {
            get
            {
                if (dataBaseSQLite == null)
                {
                    dataBaseSQLite = new DataBaseSQLite(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PM02.db3"));
                }

                return dataBaseSQLite;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
