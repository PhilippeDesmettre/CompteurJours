using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DayCounter.Models
{
    public class Interval
    {
        public Interval(string title, DateTime startDate)
        {
            Title = title;
            StartDate = startDate;
            

        }

        public Interval()
        {
            

        }
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }

       

    }
}
