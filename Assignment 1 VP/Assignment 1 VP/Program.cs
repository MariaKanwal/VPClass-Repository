using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_VP
{
    class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                String[] Array = new String[25];
                DateTime[] user_date = new DateTime[25];
                DateTime System_date = DateTime.Today;

                try
                {
                    Console.Write("\nPlease Enter Your Number Of Sibling\t: ");
                    int n = int.Parse(Console.ReadLine());
                    for (int i = 0; i < n; i++)
                    {


                        Console.Write("\n\nEnter Date Of Birth Of Sibling  " + (i + 1) + "  in format (MM/DD/YYYY) :");

                        Array[i] = Console.ReadLine();
                        user_date[i] = DateTime.Parse(Array[i]);

                        int Total_Days_of_life = (DateTime.Now.Year * 365 + DateTime.Now.DayOfYear) - (user_date[i].Year * 365 + user_date[i].DayOfYear);
                        int Total_Years = Total_Days_of_life / 365;

                        int Days = System_date.Day - user_date[i].Day;


                        int currentMonth, birthMonth, Months;


                        currentMonth = Convert.ToInt32(DateTime.Now.Month);
                        birthMonth = Convert.ToInt32(user_date[i].Month);

                        int years = Total_Years;

                        if ((currentMonth - birthMonth > 0))
                        {
                            Months = Convert.ToInt32(currentMonth - birthMonth);
                        }

                        else
                        {
                            years = years - 1;
                            Months = Convert.ToInt32((12 - birthMonth) + currentMonth);
                        }

                        if (Months == 12)
                        {
                            Months = 0;
                        }



                        string print = (Total_Days_of_life >= 1) ? "Age Of Sibling  " + (i + 1) + "  is  " + Total_Years + " Years  " + Months + " Months " + Days + " Days" : "";

                        Console.WriteLine(print);

                    }

                    Console.WriteLine("\n\n");
                    for (int d = 0; d < n - 1; d++)
                    {
                        int Day_Diff, Month_Diff, Year_Diff;

                        Day_Diff = (user_date[d].Day - user_date[d + 1].Day);
                        Month_Diff = user_date[d].Month - user_date[d + 1].Month;
                        Year_Diff = user_date[d].Year - user_date[d + 1].Year;

                        Console.WriteLine("\nDifference Between Sibling  " + d + " and " + (d + 1) + "  is  " + Year_Diff + "  Years" + Month_Diff + "  Months" + Day_Diff + "  Days");

                    }

                }

                catch
                {
                    Console.WriteLine("\nYou Have Entered An Invalid Date");
                }


                Console.WriteLine("Do Want To Exit Press Y or N");
                string userValue = Console.ReadLine();

                if (userValue == "Y")
                {
                    Environment.Exit(0);
                }
            }

        }
    }
}
