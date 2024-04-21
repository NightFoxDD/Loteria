using Loteria.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Loteria
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Btn_GoToPlayerPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserPage());
        }

        private void Btn_GoToAdminPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdminPage());
        }        
        private void Btn_GoToResultPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ResultPage());
        }

        private void Btn_GoToRankingPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RankingPage());
        }
    }
}
