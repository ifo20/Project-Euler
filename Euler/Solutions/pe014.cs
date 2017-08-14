namespace Euler
{
    using System;

    public class Problem14 : IProblem
    {
        public void Pose()
        {
            string q = @"
PROBLEM 14:
The following iterative sequence is defined for the set of positive integers:

	n -> n/2 (n is even)
	n -> 3n + 1 (n is odd)

Using the rule above and starting with 13, we generate the following sequence:

	13 -> 40 -> 20 -> 10 -> 5 -> 16 -> 8 -> 4 -> 2 -> 1

It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms.
Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.

Which starting number, under one million, produces the longest chain?

NOTE: Once the chain starts the terms are allowed to go above one million.
";
            Console.WriteLine(q);
        }

        public string Solve()
        {
            int max = 0;
            int ans = 0;
            int[] cache = new int[1000000];
            for (int a = 1; a < 1000000; a++)
            {
                int length = 1;

                // We now find the length of the chain starting at a.
                double m = (double)a;
                while (m > 1 && m >= a)
                {
                    if (m % 2 == 0)
                    {
                        m = m / 2;
                    }
                    else
                    {
                        m = (3 * m) + 1;
                    }

                    length++;
                }

                // We have exited the while loop. Hence m is now below our starting point
                // i.e. we must have already stored the answer in previous iterations
                // Then, the length of this chain is given by .. 
                // e.g. if we have taken 3 steps to get to 13 (whose chain is of length 10) then the chain length is given by 3 + 10:
                cache[a] = length + cache[(int)m];
                if (cache[a] > max)
                {
                    max = cache[a];
                    ans = a;
                }
            }

            return ans.ToString();
        }
    }
}
