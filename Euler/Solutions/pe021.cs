namespace Euler
{
    using System;

    public class Problem21 : IProblem
    {
        public static int FindDivisors(int n) // This sums all proper divisors of n
        {
            int sum = 0;
            for (int d = 1; d < n; d++)
            {
                if (n % d == 0)
                {
                    sum += d;
                }
            }

            return sum;
        }

        public void Pose()
        {
            string q = @"
PROBLEM 21:
Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.

For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.

Evaluate the sum of all the amicable numbers under 10000.
";
            Console.WriteLine(q);
        }

        public string Solve()
        {
            int x = 0;
            int tmp;
            for (int i = 1; i < 10000; i++)
            {
                tmp = FindDivisors(i); // This finds the sum of divisors of i
                if (FindDivisors(tmp) == i && tmp != i)
                {
                    // Then the number is amicable; we add to our sum
                    x += i;
                }
            }

            return x.ToString();
        }
    }
}
