namespace Euler
{
    using System;

    public class Problem3 : IProblems
    {
        public void Pose()
        {
            string q = @"
PROBLEM 3:
The prime factors of 13195 are 5, 7, 13 and 29. What is the largest prime factor of the number 600851475143 ?
";
            Console.WriteLine(q);
        }

        public string Solve()
        {
            Console.WriteLine("Here is the solution:");
            double n = 600851475143;
            return this.HPF(n).ToString();
        }

        public int HPF(double n)
        {
            double t = n;
            double d = 2;
            while (t > 1)
            {
                if (t % d == 0)
                {
                    // then d is a factor of n; we can divide by it. once t reaches 1, we will have found all factors, and last factor = d
                    t = t / d;
                }
                else
                {
                    d++;
                }
            }

            return (int)d; // Returns the highest prime factor of n
        }
    }
}
