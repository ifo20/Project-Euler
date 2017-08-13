namespace Euler
{
    using System;

    public class Problem6 : IProblem
    {
        public static int FindSum(int n) // sum of 1 to n = 1/2 * n * (n+1)
        {
            return n * (n + 1) / 2;
        }

        public static int FindSumOfSquares(int n) // sum of n squared from 1 to n = n*(n+1)*(2n+1)/6
        {
            return n * (n + 1) * ((2 * n) + 1) / 6;
        }

        public void Pose()
        {
            string q = @"
PROBLEM 6:
The sum of the squares of the first ten natural numbers is,
1^2 + 2^2 + ... + 10^2 = 385
The square of the sum of the first ten natural numbers is,
(1 + 2 + ... + 10)^2 = 55^2 = 3025
Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 - 385 = 2640.
Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
";
            Console.WriteLine(q);
        }

        public string Solve()
        {
            int n = 100;
            int a = FindSum(n) * FindSum(n);
            int b = FindSumOfSquares(n);
            Console.WriteLine("Sum of squares: " + b.ToString());
            Console.WriteLine("Square of the sum: " + a.ToString());
            return (a - b).ToString();
        }
    }
}
