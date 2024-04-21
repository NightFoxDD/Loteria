using Loteria.Tables;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Loteria.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            InitializeComponent();
        }

        private void Btn_Apply_Clicked(object sender, EventArgs e)
        {
            User nowygracz = new User(E_Name.Text, E_Surname.Text, E_Email.Text, E_Code.Text);
            if (E_Name.Text != "" && E_Surname.Text != "" && E_Email.Text != "" && E_Code.Text != "" &&
                Regex.IsMatch(E_Email.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$") && Regex.IsMatch(E_Code.Text, @"^[0-9]{9}$"))
            {
                App.DataBase.Save(nowygracz);
                DisplayAlert("Informacja", "Gratuluję!\n Wziołeś udział w loterii", "OK");
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Błąd", "Niepoprawnie wpisano dane!", "OK");
            }

            E_Name.Text = "";
            E_Surname.Text = "";
            E_Email.Text = "";
            E_Code.Text = "";
        }
    }
}