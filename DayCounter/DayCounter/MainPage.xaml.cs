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

            MyListView.ItemsSource = intervals;
        }

        public MainPage(Interval interval)
        {
            InitializeComponent();






        }

        public MainPage()
        {

            InitializeComponent();
            List<string> sortByList = new List<string>()
            {"Trier par Titre","Trier Par Tire Desc","Trier par Date","Trier par Date Desc" };
            SortPickr.ItemsSource = sortByList;



            SortByClick.Clicked += (o, a) =>
           {
               SortPickr.Focus();

           };
            SortPickr.SelectedIndexChanged += async (o, e) =>
              {
                  if (SortPickr.SelectedItem.ToString() == "Trier par Titre")
                  {
                      List<Interval> intervals = await App.Database.GetIntervalAsync();
                      var list = intervals.OrderBy(a => a.Title).ToList();
                      MyListView.ItemsSource = list;
                  }
                  if (SortPickr.SelectedItem.ToString() == "Trier Par Tire Desc")
                  {
                      List<Interval> intervals = await App.Database.GetIntervalAsync();
                      var list = intervals.OrderByDescending(a => a.Title).ToList();
                      MyListView.ItemsSource = list;
                  }
                  if (SortPickr.SelectedItem.ToString() == "Trier par Date")
                  {
                      List<Interval> intervals = await App.Database.GetIntervalAsync();
                      var list = intervals.OrderBy(a => a.StartDate).ToList();
                      MyListView.ItemsSource = list;
                  }
                  if (SortPickr.SelectedItem.ToString() == "Trier par Date Desc")
                  {
                      List<Interval> intervals = await App.Database.GetIntervalAsync();
                      var list = intervals.OrderByDescending(a => a.StartDate).ToList();
                      MyListView.ItemsSource = list;
                  }
              };

        }

        private async void LV_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var interval = e.SelectedItem as Interval;
            await Navigation.PushAsync(new Page2(interval));



        }
        private async void NewEntry(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page1());
        }
    }
}
