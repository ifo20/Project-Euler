namespace Euler
{
    using System;

    public class Problem25 : IProblem
    {
        public void Pose()
        {
            string q = @"
PROBLEM 25:
The Fibonacci sequence is defined by the recurrence relation:
Fn = Fn-1 + Fn-2, where F1 = 1 and F2 = 1.
Hence the first 12 terms will be:

F1 = 1
F2 = 1
F3 = 2
F4 = 3
F5 = 5
F6 = 8
F7 = 13
F8 = 21
F9 = 34
F10 = 55
F11 = 89
F12 = 144

The 12th term, F12, is the first term to contain three digits.

What is the index of the first term in the Fibonacci sequence to contain 1000 digits?
";
            Console.WriteLine(q);
        }

        public string Solve()
        {
            // We will need approx 1,000 digits
            int digits = 1000;
            int max_try = 4800;
            int[] a = new int[digits];
            int[] b = new int[digits];
            int[] tmp = new int[digits];
            for (int i = 0; i < digits; i++)
            {
                a[i] = 0;
                b[i] = 0;
                tmp[i] = 0;
            }

            a[digits - 1] = 1;
            b[digits - 1] = 1;

            // Add up manually
            for (int i = 3; i < max_try; i++)
            {
                // Calculate F_i by adding b and a 
                // Set tmp to be b
                for (int z = 0; z < digits; z++)
                {
                    tmp[z] = b[z];
                }

                for (int j = digits - 1; j > -1; j--)
                {
                    b[j] += a[j];
                    while (b[j] > 9)
                    {
                        b[j] -= 10;
                        b[j - 1]++;

                        // As soon as any number > 0 appears in the first column (i.e. reached one thousandth digit) then we are done
                        if (b[0] > 0)
                        {
                            return i.ToString();
                        }
                    }
                }

                // Set a to be tmp
                for (int z = 0; z < digits; z++)
                {
                    a[z] = tmp[z];
                }
            }

            return "No answer found - please check code in file pe025.cs";
        }
    }
}
