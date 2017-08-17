namespace Euler
{
    using System;
    using System.Collections.Generic;

    public class Problem27 : IProblem
    {
        public static int Quadratic(int n, int a, int b)
        {
            return (n * n) + (n * a) + b;
        }

        public static bool IsPrime(int p)
        {
            for (int i = 2; i < p / 2; i++)
            {
                if (p % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static List<int> FindPrimes(int n)
        {
            List<int> primes = new List<int>();
            primes.Add(2);
            int a = 3;
            for (int i = a; i < n; i++)
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
                    else
                    {
                        //possibly prime
                    }
                }

                if (isprime)
                {
                    primes.Add(i);
                }
            }

            return primes;
        }

        public void Pose()
        {
            string q = @"
PROBLEM 27:
Euler discovered the remarkable quadratic formula:

n^2 + n + 41

It turns out that the formula will produce 40 primes for the consecutive integer values 0 <= n <= 39.
However, when n = 40, 40^2 + 40 + 41 = 40(40 + 1) + 41 is divisible by 41, and certainly when n = 41, 41^2 + 41 + 41 is clearly divisible by 41.

The incredible formula n^2 - 79n + 1601 was discovered, which produces 80 primes for the consecutive values 0 ≤ n ≤ 79.
The product of the coefficients, −79 and 1601, is −126479.

Considering quadratics of the form:

n^2 + an + b, where |a| < 1000 and |b| ≤ 1000

where |n| is the modulus/absolute value of n
e.g. |11| = 11 and |-4| = 4

Find the product of the coefficients, a and b, for the quadratic expression that produces the maximum number of primes for consecutive values of n, starting with n=0.
";
            Console.WriteLine(q);
        }

        public string Solve()
        {
            // n^2 + a*n + b
            // n = (b-a) --> not prime (a*a + b*b -2ab + ab - a*a + b = b*b - ab + b = b*(b-a+1) not prime)
            // n = b --> not prime
            // Hence consecutive primes limited by b - a or b
            // n^2 - 79n  + 1601 --> 80 primes n <= 79
            // b must be prime

            // When n = |a| (a negative), ans = b (prime) but then n > |a| gives e.g. 80*80 - 79*80 = 1*80 + b, 2*80 + b etc ...  

            // n^2 + an + b is minimum at n = -a/2 .... a^2 over 4 - a^2 over 2 + b = b - a^2 over 4 so a^2 must < 4b.

            // METHOD: We use the above logic to limit our possible scenarios, and iterate over these possible scenarios.

            // Find all primes < 1000 .... b can be + any of these primes
            List<int> primes = FindPrimes(1000);
            Console.WriteLine("Found " + primes.Count + " primes");
            int max = 0;
            int product = 0;
            foreach (int p in primes)
            {
                int b = p;
                for (int a = (int)-Math.Pow(4 * b, 0.5); a < 0; a++)
                {
                    int consecutive_primes = 0;
                    for (int n = 0; n < b; n++)
                    {
                        if (IsPrime(Quadratic(n, a, b)))
                        {
                            consecutive_primes++;
                        }
                        else
                        {
                            // Not prime, skip unless we have a new max number of consecutive primes
                            if (consecutive_primes > max)
                            {
                                max = consecutive_primes;
                                Console.WriteLine("A/B: " + a.ToString() + "/" + b.ToString() + " has " + consecutive_primes.ToString() + " consecutive primes");
                                Console.WriteLine("Product is " + (a * b).ToString());
                                product = a * b;
                            }

                            break;
                        }
                    }
                }
            }

            return product.ToString();
        }
    }
}
