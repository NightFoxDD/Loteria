using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Loteria
{
    public partial class App : Application
    {
        private static DataAccess dataBase;

        public static DataAccess DataBase
        {
            get
            {
                if (dataBase == null)
                {
                    dataBase = new DataAccess(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LotteryBase.db3"));
                }
                return dataBase;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage( new MainPage());
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
