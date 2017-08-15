namespace Euler
{
    using System;
    using System.IO;

    public class Problem20 : IProblem
    {
        public void Pose()
        {
            string q = @"
PROBLEM 20:
n! means n x (n - 1) x ... x 3 x 2 x 1

For example, 10! = 10 x 9 x ... x 3 x 2 x 1 = 3628800,
and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

Find the sum of the digits in the number 100!
";
            Console.WriteLine(q);
        }

        public string Solve()
        {
            // 158: we require a 158 digit number. We use an array to multiply iteratively, carrying over where necessary
            int n = 158;
            int[] digits_array = new int[n];
            int[] remainders_array = new int[n];
            for (int i = 0; i < n - 1; i++)
            {
                digits_array[i] = 0;
                remainders_array[i] = 0;
            }

            remainders_array[n - 1] = 0;
            digits_array[n - 1] = 6; // this is 3!

            for (int k = 4; k < 101; k++)
            {
                // Times all digits by k
                for (int c = n - 1; c > 0; c--)
                {
                    digits_array[c] *= k;
                }

                for (int c = n - 1; c > 0; c--)
                {
                    // Check where we need to carry over remainders (i.e. digit places where we have 10 or greater)
                    while (digits_array[c] > 9)
                    {
                        digits_array[c] -= 10;
                        digits_array[c - 1]++;
                    }
                }
            }

            // Now store digits of 100!
            int ans = 0;
            for (int i = 0; i < n; i++)
            {
                ans += digits_array[i];
            }

            return ans.ToString();
        }
    }
}
