namespace Euler
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Problem23 : IProblem
    {
        public static int FindSOPD(int n) // Finds Sum Of Prime Divisors of a number n
        {
            int sum = 0;
            for (int i = 1; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    sum += i;
                }
            }

            return sum;
        }

        public void Pose()
        {
            string q = @"
PROBLEM 23:
A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. 
For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.
A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.
As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24. 
By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers. 
However, this upper limit cannot be reduced any further by analysis even though it is known that the greatest number that cannot be expressed as the sum of two abundant numbers is less than this limit.
Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.
";
            Console.WriteLine(q);
        }

        public string Solve()
        {
            List<int> abundants = new List<int>();
            int x = 28124;
            for (int i = 1; i < x; i++)
            {
                // Find sum of proper divisors
                int sopd = FindSOPD(i);
                if (sopd > i)
                {
                    // is abundant
                    abundants.Add(i);
                }
            }

            // Find all sums of two of these numbers
            List<int> sums = new List<int>();
            int n = abundants.Count;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int tmp = abundants[i] + abundants[j];
                    if (tmp < x)
                    {
                        sums.Add(tmp);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            double a = 0;

            // Now we cycle through all numbers less than x and check if it can be written as the sum of two abundant numbers
            // If this number i is not in the list of sums (i.e. it cannot be written as a sum of two abundant numbers) then we add it to our total
            for (int i = 1; i < x; i++)
            {
                if (sums.IndexOf(i) == -1) 
                {
                    a += i;
                }
            }

            return a.ToString();
        }
    }
}
