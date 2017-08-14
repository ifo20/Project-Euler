namespace Euler
{
    using System;
    using System.Collections.Generic;

    public class Problem10 : IProblem
    {
        public static double SumOfPrimesLessThan(int n)
        {
            int i = 3;
            double sum = 2;
            List<int> primes = new List<int>();
            primes.Add(2);
            while (i < n)
            {
                bool isprime = true;
                foreach (int p in primes)
                {
                    if (i % p == 0)
                    {
                        // Not prime
                        isprime = false;
                        break;
                    }
                }

                if (isprime)
                {
                    // We couldn't divide by any of existing primes, so must be prime - so we add it to our list 
                    primes.Add(i);
                    sum += (double)i;
                }

                i += 2;
            }

            return sum;
        } // Finds all primes under n and sums them

        public void Pose()
        {
            string q = @"
PROBLEM 10:
The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
Find the sum of all the primes below two million.
";
            Console.WriteLine(q);
        }

        public string Solve()
        {
            return SumOfPrimesLessThan(2000000).ToString();
        }
    }
}
