using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DayCounter.Models;

namespace DayCounter
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private async void SaveEntry(object sender, EventArgs e)
        {
            if (CounterName.Text is null || DatePick.Date.ToString().Length == 0)
            {
                await DisplayAlert("Attention", "Vous n'avez pas remplis les informations", "OK");
            }
            if(DatePick.Date>DateTime.Now)
            {
                await DisplayAlert("Attention", "Impossible de choisir une date superieur à la date d'aujourdhui", "OK");
            }
            else
            {

                await App.Database.SaveIntervalAsync(new Interval
                {
                    StartDate = DatePick.Date,
                    Title = CounterName.Text
                });
                await Navigation.PushAsync(new MainPage());
            }
                       
        }
    }
}