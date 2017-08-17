namespace Euler
{
    using System;

    public class Problem28 : IProblem
    {
        public void Pose()
        {
            string q = @"
PROBLEM 28:
Starting with the number 1 and moving to the right in a clockwise direction a 5 by 5 spiral is formed as follows:

        21 22 23 24 25
        20  7  8  9 10
        19  6  1  2 11
        18  5  4  3 12
        17 16 15 14 13

It can be verified that the sum of the numbers on the diagonals is 101.

What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral formed in the same way?
";
            Console.WriteLine(q);
        }

        public string Solve()
        {
            // Sequence is 	1,  			+0,+2
            //				3,5,7,9			+2,+4      	j=1    3x3
            //				13,17,21,25		+4,+6		j=2		5x5
            //				31,37,43,49 	+6,+8		j=3		7x7
            //				57,65,73,81		+8,+10		j=4		9x9
            // etc

            // Each cycle adds an Arithmetic sequence length 4, diff 2j
            // j = y --> spiral is a (2y+1)x(2y+1) hence j = 500 --> 1001x1001
            int n = 500;
            int a = 3;
            double sum = 1;
            for (int j = 1; j <= n; j++)
            {
                // Add numbers from this sequence
                for (int i = 0; i < 4; i++)
                {
                    sum += (double)a;
                    a += 2 * j;
                }

                a += 2;
            }

            return sum.ToString();
        }
    }
}
