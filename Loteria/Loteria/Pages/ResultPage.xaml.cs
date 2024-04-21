using Loteria.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Loteria.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultPage : ContentPage
    {
        public ResultPage()
        {
            InitializeComponent();
            LV_Winners.ItemsSource = App.DataBase.GetList<Result>();
        }
        private void wyszukaj_TextChanged(object sender, TextChangedEventArgs e)
        {

            List<Result> WinnersList = App.DataBase.GetList<Result>();
            List<Result> newList = WinnersList.Where(wygrana => wygrana.Id.ToString().Contains(SB_SearchLossNumber.Text)).ToList();
            LV_Winners.ItemsSource = newList;

        }
    }
}