namespace Euler
{
    using System;

    public class Problem9 : IProblem
    {
        public void Pose()
        {
            string q = @"
PROBLEM 9:
A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
a^2 + b^2 = c^2
For example, 3^2 + 4^2 = 9 + 16 = 25 = 52.
There exists exactly one Pythagorean triplet for which a + b + c = 1000.
Find the product abc.
";
            Console.WriteLine(q);
        }

        public string Solve()
        {
            int n = 1000;
            for (int b = 1; b < n; b++)
            {
                for (int a = 1; a < b; a++)
                {
                    int c = n - a - b;
                    if ((a * a) + (b * b) == (c * c))
                    {
                        return (a * b * c).ToString();
                    }
                }
            }

            return "No triplet found";
        }
    }
}
