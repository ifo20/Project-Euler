namespace Euler
{
    using System;
    using System.Collections.Generic;

    public class Problem7 : IProblem
    {
        public static double FindNthPrime(double n)
        {
            // We check whether a number is prime by trying to divide it by all of the primes below it
            // We start with the list of the first prime = 2 ... 3 is not divisible by 2 hence is prime hence we add it to the list
            // This continues until we have n primes in our list
            List<double> primes = new List<double>();
            primes.Add(2);
            double d = 3;
            while (primes.Count < n)
            {
                bool isprime = true;
                foreach (int p in primes)
                {
                    if (d % p == 0)
                    {
                        isprime = false;
                        break;
                    }
                }

                if (isprime)
                {
                    primes.Add(d);
                }

                d = d + 2;
            }

            return primes[primes.Count - 1];
        }

        public void Pose()
        {
            string q = @"
PROBLEM 7:
By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
What is the 10 001st prime number?
";
            Console.WriteLine(q);
        }

        public string Solve()
        {
            int n = 10001;
            return FindNthPrime(n).ToString();
        }
    }
}
