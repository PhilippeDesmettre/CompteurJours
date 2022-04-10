using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using DayCounter.Models;



namespace DayCounter
{
    public partial class MainPage : ContentPage
    {
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            List<Interval> intervals = await App.Database.GetIntervalAsync();
            var list = intervals.OrderBy(a => a.Title).ToList();
            MyListView.ItemsSource = list;
        }

        public MainPage(Interval interval)
        {
            InitializeComponent();
            
            
          
           
            

        }

        public MainPage()
        {

            InitializeComponent();
            //MyListView.ItemsSource = DAL.intervals;
        }

        private async void LV_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var test = e.SelectedItem as Interval;
            await Navigation.PushAsync(new Page2(test));

            
            
        }
        private async void NewEntry(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page1());
        }
    }
}
