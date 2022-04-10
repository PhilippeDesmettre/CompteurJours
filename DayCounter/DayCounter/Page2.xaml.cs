using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DayCounter.Models;
using System.Windows.Input;

namespace DayCounter
{
   
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public Page2(Interval interval)
        {
            InitializeComponent();
            titleInterval.Text = interval.Title;
            datePickerInterval.Date = interval.StartDate;
            DateTime nowDate = DateTime.Now;
            double days = Math.Floor(DAL.calculInterval(interval.StartDate, nowDate).TotalDays);
            double month = DAL.MonthDifference(nowDate, interval.StartDate);
            double year = DAL.YearsDifference(nowDate, interval.StartDate);

            day.Text = DAL.stringBuilder(days, "Jour");
            Months.Text = DAL.stringBuilder(month, "Mois"); 
            years.Text = DAL.stringBuilder(year, "Année");

            //saveIntervalButton.BindingContext = interval;



            saveIntervalButton.Clicked += async (o, a) =>
            {

                interval.Title = titleInterval.Text;
                interval.StartDate = datePickerInterval.Date;
                await App.Database.ModifyIntervalAsync(interval);
                await Navigation.PushAsync(new MainPage());
            };
        }




    }

    
}
