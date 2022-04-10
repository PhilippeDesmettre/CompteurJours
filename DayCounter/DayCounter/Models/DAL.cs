using System;
using System.Collections.Generic;
using System.Text;
using DayCounter.Models;

namespace DayCounter.Models
{
    public static class DAL
    {
        public static List<Interval> intervals = new List<Interval>();

        public static void addItem(Interval interval)
        {
            

            intervals.Add(interval);

        }

        public static TimeSpan calculInterval(DateTime startDate, DateTime endDate)
        {
            TimeSpan result = (endDate - startDate);

            return result;

        }

        public static string stringBuilder( double tspan, string JourMoisAnnee)
        {
            string verb=null, jour=null, adverb=null;
            switch (JourMoisAnnee)
            {
                case "Jour":
                    if (tspan<=1)
                    {
                        jour = "jour";
                        verb = "est";
                        adverb = "passé";
                    }
                    else
                    {
                        jour = "jours";
                        verb = "sont";
                        adverb = "passés";
                    }
                    break;
                case "Mois":
                    if (tspan <= 1)
                    {
                        jour = "Moi";
                        verb = "est";
                        adverb = "passé";
                    }
                    else
                    {
                        jour = "Mois";
                        verb = "sont";
                        adverb = "passés";
                    }
                    break;
                case "Année":
                    if (tspan <= 1)
                    {
                        jour = "année";
                        verb = "est";
                        adverb = "passé";
                    }
                    else
                    {
                        jour = "années";
                        verb = "sont";
                        adverb = "passés";
                    }
                    break;
                default:
                    break;
            }

            string result = $"{tspan} {jour} {verb} {adverb}";

            return result;
        }

        public static int MonthDifference( DateTime lValue, DateTime rValue)
        {
            //return Math.Abs((lValue.Month - rValue.Month) + 12 * (lValue.Year - rValue.Year));
            return Convert.ToInt32(lValue.Subtract(rValue).Days / (365.25 / 12));
        }

        public static int YearsDifference(DateTime now, DateTime target)
        {
            DateTime zeroTime = new DateTime(1, 1, 1);

           

            TimeSpan span = now - target;
            // Because we start at year 1 for the Gregorian
            // calendar, we must subtract a year here.
            int years = (zeroTime + span).Year - 1;
            return years;
        }

    }
}
