namespace Euler
{
    using System;

    public class Problem19 : IProblem
    {
        public void Pose()
        {
            string q = @"
PROBLEM 19:
You are given the following information, but you may prefer to do some research for yourself.
1 Jan 1900 was a Monday.
Thirty days has September,
April, June and November.
All the rest have thirty-one,
Saving February alone,
Which has twenty-eight, rain or shine.
And on leap years, twenty-nine.
A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.
How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
";
            Console.WriteLine(q);
        }

        public string Solve()
        {
            int leap = 0;
            int[] months = { 31, 28 + leap, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            // 1 Jan 1900 = Monday = Day 1 of 7
            int day = 1;
            int date = 1;
            int month = 0;
            int year = 1900;
            bool count = true;
            int ans = 0;
            while (count)
            {
                day = (day + 1) % 7;
                date++;

                // Check we haven't gone into next month
                if (date > months[month])
                {
                    date = 1;
                    month++;

                    // Check we haven't gone into next year
                    if (month == 12)
                    {
                        month = 0;
                        year++;

                        // Check if this new year is a leap year
                        if (year % 4 == 0 && ((year % 100 != 0) || (year % 400 == 0)))
                        {
                            leap = 1;
                        }
                        else
                        {
                            leap = 0;
                        }
                    }
                }

                // Check if this day is Sunday 1st (and ignoring first year as question does not include 1900)
                if (day == 0 && date == 1 && year != 1900)
                {
                    ans++;
                }

                // Check whether this is the last date to check
                if (date == 31 && month == 11 & year == 2000)
                {
                    count = false;
                }
            }

            Console.WriteLine("Checking answer for reasonableness - there are 365 days over 100 years, of which 1 in 7 are Sundays. Similarly 1 in 30 (ish) are '1st's");
            double g = 365.25 * 100 / (7 * 30); // There are ~36,525 days, 1/7 are Sundays and 1/30 are 1sts so approx 173 is expected answer 
            Console.WriteLine("So one would expect approx " + g.ToString());
            return ans.ToString();
        }
    }
}
