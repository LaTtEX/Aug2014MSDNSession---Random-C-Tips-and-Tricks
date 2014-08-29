using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomCSharpTipsDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            var schools = new List<School> 
            {
                new School {Name = "University of Santo Tomas", Address = "Espana, Manila", YearEstablished = 1611},
                new School {Name = "De La Salle University", Address = "Taft Ave., Manila", YearEstablished = 1911},
                new School {Name = "University of the Philippines", Address = "Diliman, Quezon City", YearEstablished = 1908},
                new School {Name = "Ateneo de Manila University", Address = "Loyola Heights, Quezon City", YearEstablished = 1859},
                new School {Name = "iAcademy", Address = "Gil Puyat Ave., Makati", YearEstablished = 2001}
            };

            foreach (var name in ReturnCaps(schools))
            {
                Console.WriteLine(name);
            }

            Console.WriteLine();

            var hasAcademy = schools.Any(s => s.Name.Contains("Academy"));
            var hasCollege = schools.Any(s => s.Name.Contains("College"));

            Console.WriteLine("The list has an academy: {0}", hasAcademy);
            Console.WriteLine("The list has a college: {0}", hasCollege);

            Console.WriteLine();

            var manilaSchools = new List<School> 
            {
                new School {Name = "University of Santo Tomas", Address = "Espana, Manila", YearEstablished = 1611},
                new School {Name = "De La Salle University", Address = "Taft Ave., Manila", YearEstablished = 1911}
            };

            var nonManilaSchools = ReturnCaps(schools).Except(ReturnCaps(manilaSchools));

            nonManilaSchools.ToList().ForEach(s => Console.WriteLine(s));

            Console.WriteLine();

            var oldschools = schools.Except(schools.Where(s => s.YearEstablished < 1900));

            oldschools.ToList().ForEach(s => Console.WriteLine("School {0} was established in {1}", s.Name, s.YearEstablished));

            Console.WriteLine();

            DateTime myDate = DateTime.Now;

            Console.WriteLine("The date and time now is {0}", myDate);
            Console.WriteLine("The date and time tomorrow is {0}", Duration.Day.From(myDate));
            Console.WriteLine("The date and time one week from now is {0}", Duration.Week.From(myDate));
            Console.WriteLine("The date and time a month from now is {0}", Duration.Month.From(myDate));

            Console.WriteLine();

            Console.ReadKey();

        }

        static IEnumerable<string> ReturnCaps(IEnumerable<School> schools)
        {
            foreach (var school in schools)
            {
                yield return school.Name.ToUpperInvariant();
            }
        }
    }

    class School
    {
        public string Name { get; set; }
        public string Address { get; set; }

        private int yearEstablished;

        public int YearEstablished
        {
            get { return yearEstablished; }
            set { yearEstablished = value; }
        }
        
    }

    public enum Duration
    {
        Day,
        Week,
        Month
    }

    public static class DurationExtensions
    {
        public static DateTime From(this Duration duration, DateTime dateTime)
        {
            switch (duration)
            {
                case Duration.Day:
                    return dateTime.AddDays(1);
                case Duration.Week:
                    return dateTime.AddDays(7);
                case Duration.Month:
                    return dateTime.AddMonths(1);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
