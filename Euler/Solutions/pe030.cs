namespace Euler
{
    using System;

    public class Problem30 : IProblem
    {
        public static int SOFP(int n, int[] fifths) // Given a number-string n, sum the fifth powers of each digit (already stored in int[] fifths) in that number-string 
        {
            string s = n.ToString();
            int x = 0;
            foreach (char c in s)
            {
                x += fifths[Convert.ToInt32(c) - 48];
            }

            return x;
        }

        public void Pose()
        {
            string q = @"
PROBLEM 30:
Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:

1634 = 1^4 + 6^4 + 3^4 + 4^4
8208 = 8^4 + 2^4 + 0^4 + 8^4
9474 = 9^4 + 4^4 + 7^4 + 4^4
As 1 = 14 is not a sum it is not included.

The sum of these numbers is 1634 + 8208 + 9474 = 19316.

Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.
";
            Console.WriteLine(q);
        }

        public string Solve()
        {
            // We create an array of each digit 0-9 to fifth power (stored as a variable so we can try the same to the 6th power etc but variable is called fifths for now)
            int power = 5;
            int[] fifths = new int[10];
            for (int i = 0; i < 10; i++)
            {
                fifths[i] = (int)Math.Pow(i, power);
            }

            // Try numbers
            int sum = 0;
            for (int j = 10; j < 10000000; j++)
            {
                if (SOFP(j, fifths) == j)
                {
                    sum += j;
                }
            }

            return sum.ToString();
        }
    }
}
