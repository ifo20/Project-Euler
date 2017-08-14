﻿namespace Euler
{
    using System;

    public class Problem12 : IProblem
    {
        public static int FindDivisors(double n)
        {
            int factors = 1;
            int this_prime_power = 0;
            bool used;
            double t = n;
            int d = 2;
            while (t > 1)
            {
                used = false;
                this_prime_power = 0;
                while (t % d == 0)
                {
                    used = true;
                    t = t / d;
                    this_prime_power++;
                }

                if (used)
                {
                    factors = factors * (this_prime_power + 1);
                }

                d++;
            }

            return factors;
        }

        public void Pose()
        {
            string q = @"
PROBLEM 12:
The sequence of triangle numbers is generated by adding the natural numbers. So the 7th triangle number would be 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28. The first ten terms would be:
1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...
Let us list the factors of the first seven triangle numbers:
	
    1: 1
    3: 1,3
    6: 1,2,3,6
    10: 1,2,5,10
    15: 1,3,5,15
    21: 1,3,7,21
    28: 1,2,4,7,14,28

We can see that 28 is the first triangle number to have over five divisors.

What is the value of the first triangle number to have over five hundred divisors?
";
            Console.WriteLine(q);
        }

        public string Solve()
        {
            int divisors = 6;
            double n = 7; // 7th triangle number 28 has 6 divisors
            double s = 0;
            double div_lim = 500; // We want to find the first triangle number with more than div_lim divisors
            while (divisors < div_lim + 1)
            {
                n++;
                s = n * (n + 1) / 2; // Sum of 1 to N formula = triangle number
                divisors = FindDivisors(s);
            }

            return s.ToString();
        }
    }
}