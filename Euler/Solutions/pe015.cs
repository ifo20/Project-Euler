namespace Euler
{
    using System;

    public class Problem15 : IProblem
    {
        public void Pose()
        {
            string q = @"
PROBLEM 15:
Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.
How many such routes are there through a 20×20 grid?
";
            Console.WriteLine(q);
        }

        public string Solve()
        {
            // Lattice structure ..... there are 6 routes to traverse a 2x2 lattice, how many for 20x20?
            // We have 40 steps to take, 20 rights and 20 downs. The positions of downs is given by the spaces left once the rights are positioned
            // Therefore we have to choose n spots from 2n spots .... there are (2n)! over (n!)*(n!)
            int n = 20;
            double total = 1;
            for (int i = 2 * n; i > n; i--)
            {
                total = total * i;
            }

            // This gives (2n)! over (n!) .. now to divide by other (n!)
            for (int i = n; i > 1; i--)
            {
                total = total / i;
            }

            return total.ToString();
        }
    }
}
