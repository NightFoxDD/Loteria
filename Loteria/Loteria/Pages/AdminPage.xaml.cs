using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Loteria.Tables;

namespace Loteria.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminPage : ContentPage
    {
        public AdminPage()
        {
            InitializeComponent();
        }
        void Btn_SendMail_Clicked(string where, string title, string discription)
        {
            MailMessage message = new MailMessage("jankowalski334432@outlook.com", where, title, discription);
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("jankowalski334432@outlook.com", "haslo123123");
            client.UseDefaultCredentials = false;
            client.Send(message);

        }

        private void Btn_LossWinner_Clicked(object sender, EventArgs e)
        {
            int numberOfWinners = 0;
            Random randomNumber = new Random();
            string result = "";
            for (int i = 0; i < 9; i++)
            {
                result += randomNumber.Next(0, 10);
            }
            List<User> playerList = App.DataBase.GetList<User>();
            foreach (User player in playerList)
            {
                if (player.Code == result)
                {
                    Btn_SendMail_Clicked(player.Email, "Gratuluje wygranej!", "Proszę o kontakt pod adresem Limanowa 32. \nPozdrawiamy zespół lotto.");
                    numberOfWinners++;
                }
            }
            Result addResult = new Result(DateTime.Now, result, numberOfWinners);
            App.DataBase.Save(addResult);
            Lbl_Date.Text = "Data losowania: " + addResult.LotteryDay.ToString();
            Lbl_NumberOfWinners.Text = "Ilosc wygranych: " + numberOfWinners.ToString();
            Lbl_WinnerCode.Text = "Wygrany kod: " + result;
        }

        private void Btn_EveryUserWinning_Clicked(object sender, EventArgs e)
        {
            int numberOfWinners = 0;
            string result = "Każdy wygrywa";

            List<User> playerList = App.DataBase.GetList<User>();
            foreach (User player in playerList)
            {
                Btn_SendMail_Clicked(player.Email, "Gratuluje wygranej!", "Proszę o kontakt pod adresem Limanowa 32. \nPozdrawiamy zespół lotto.");
                numberOfWinners++;
            }

            Result dodawanyWynik = new Result(DateTime.Now, result, numberOfWinners);
            App.DataBase.Save(dodawanyWynik);
            Lbl_Date.Text = "Data losowania: " + dodawanyWynik.LotteryDay.ToString();
            Lbl_NumberOfWinners.Text = "Ilosc wygranych: " + numberOfWinners.ToString();
            Lbl_WinnerCode.Text = "Wygrany kod: " + result;
        }
    }
}