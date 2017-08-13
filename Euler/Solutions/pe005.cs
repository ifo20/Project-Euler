namespace Euler
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class Problem5 : IProblem
    {
        public static List<int> FindPrimesLessThan(int n) // Returns list of prime numbers less than n
        {
            // We check whether a number is prime by trying to divide it by all of the primes below it
            // We start with the list of the first prime = 2 ... 3 is not divisible by 2 hence is prime hence we add it to the list
            // This continues until we exceed n
            int i = 2;
            List<int> primes = new List<int>();
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
                }

                i++;
            }

            return primes;
        }

        public void Pose()
        {
            string q = @"
PROBLEM 5:
2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
";
            Console.WriteLine(q);
        }

        public string Solve()
        {
            Console.WriteLine("Here is the solution:");
            int n = 20;

            // Brute force solution - cycle through every number starting from n, then if that number is divisble by all numbers <= n, we finish
            Console.WriteLine("Attempting brute force solution...");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            double a = (double)n;
            bool can = true;
            while (can)
            {
                for (int d = 2; d <= n; d++)
                {
                    if (a % d != 0)
                    {
                        // Not divisible so not a candidate
                        a++;
                        can = false;
                        break;
                    }
                }

                if (can)
                {
                    // We can divide this a by all numbers 1 to n so we have found our answer
                    Console.WriteLine(a.ToString());
                    stopWatch.Stop();
                    break;
                }

                can = true;
            }

            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = string.Format("{0:00}", ts.Milliseconds);
            Console.WriteLine("Solution took " + elapsedTime + "ms");
            stopWatch.Reset();

            // Mathematical solution: go through numbers 2 to 20, find lowest common multiple by writing out all prime factors
            Console.WriteLine("Attempting mathematical solution...");
            stopWatch.Start();
            //// 1 Find all primes <= 20
            List<int> primes = FindPrimesLessThan(n + 1);
            //// 2 Fill in prime counting array .... e.g primes = {2,3,5,7...} and powers[i][j] is the power of the jth prime in number i = i + 2 (start at 2 because x1 has no impact)
            int[,] powers = new int[n - 1, primes.Count];
            for (int i = 0; i < n - 2; i++)
            {
                int j = 0;
                foreach (int p in primes)
                {
                    int t = i + 2;
                    powers[i, j] = 0;
                    bool done = false;
                    while (!done)
                    {
                        if (t % p == 0)
                        {
                            powers[i, j]++;
                            t = t / p;
                        }
                        else
                        {
                            j++;
                            done = true;
                        }
                    }
                }
            }

            // 3 Define LCM array as int[i] = primes[i] to the power max(powers[*][i]), and multiply product
            double[] lcm_array = new double[primes.Count];
            double ans = 1;
            for (int j = 0; j < primes.Count; j++)
            {
                int tmp = 0;
                for (int i = 0; i < n - 2; i++)
                {
                    if (powers[i, j] > tmp)
                    {
                        tmp = powers[i, j];
                    }
                }

                lcm_array[j] = Math.Pow(primes[j], tmp); // Multiply the prime to the max power
                ans *= lcm_array[j];
            }

            Console.WriteLine(ans.ToString());
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            elapsedTime = string.Format("{0:00}", ts.Milliseconds);
            Console.WriteLine("Solution took " + elapsedTime + "ms");

            return ans.ToString();
        }
    }
}
