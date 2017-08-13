namespace Euler
{
    using System;

    public class Problem1 : IProblems
    {
        public void Pose()
        {
            string q = @"
PROBLEM 1:
If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9.
The sum of these multiples is 23.
Find the sum of all the multiples of 3 or 5 below 1000.
";
            Console.WriteLine(q);
        }

        public string Solve()
        {
            Console.WriteLine("Here is the solution:");
            int a = 3;
            int b = 5;
            int maxValue = 1000;
            int ans = this.FindSumOfMultiples(a, maxValue) + this.FindSumOfMultiples(b, maxValue) - this.FindSumOfMultiples(a * b, maxValue);
            return ans.ToString();
        }

        public int FindSumOfMultiples(int x, int maxValue)
        {
            int tmp = x;
            int sum = 0;
            while (tmp < maxValue)
            {
                sum += tmp; // Add this value to sum
                tmp += x; // Go to the next multiple
            }

            return sum;
        }
    }
}
