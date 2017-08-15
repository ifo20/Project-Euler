namespace Euler
{
    using System;
    using System.IO;

    public class Problem18 : IProblem
    {
        public void Pose()
        {
            string q = @"
PROBLEM 18:
By starting at the top of the triangle below and moving to adjacent numbers on the row below, the maximum total from top to bottom is 23.

	3
	7 4
	2 4 6
	8 5 9 3

That is, 3 + 7 + 4 + 9 = 23.

Find the maximum total from top to bottom of the triangle below:

	75
	95 64
	17 47 82
	18 35 87 10
	20 04 82 47 65
	19 01 23 75 03 34
	88 02 77 73 07 63 67
	99 65 04 28 06 16 70 92
	41 41 26 56 83 40 80 70 33
	41 48 72 33 47 32 37 16 94 29
	53 71 44 65 25 43 91 52 97 51 14
	70 11 33 28 77 73 17 78 39 68 17 57
	91 71 52 38 17 14 91 43 58 50 27 29 48
	63 66 04 68 89 53 67 30 73 16 69 87 40 31
	04 62 98 27 23 09 70 98 73 93 38 53 60 04 23

NOTE: As there are only 16384 routes, it is possible to solve this problem by trying every route.
However, Problem 67, is the same challenge with a triangle containing one-hundred rows; it cannot be solved by brute force, and requires a clever method! ;o)
";
            Console.WriteLine(q);
        }

        public string Solve()
        {
            // We create a copy of the triangle and fill it in from the bottom. 
            // The number in this triangle (called 'sums') represents the greatest possible total at that point
            // I.e. the greatest total possible from all routes that start at that point and go down to the bottom
            string[] text = File.ReadAllLines(@"Resources/pe018-tri.txt");
            int rows = text.Length;

            // Initialising triangles
            int[][] triangle = new int[rows][];
            int[][] sums = new int[rows][];
            for (int r = 0; r < rows; r++)
            {
                triangle[r] = new int[r + 1];
                sums[r] = new int[r + 1];
                string[] tmp = text[r].Split(' ');
                for (int c = 0; c < r + 1; c++)
                {
                    triangle[r][c] = Convert.ToInt32(tmp[c]);
                    sums[r][c] = 0;
                }
            }

            // Populate sum table. Start second-from-bottom row, take triangle number + max of choice
            // First populate bottom row 
            for (int c = 0; c < rows; c++)
            {
                sums[rows - 1][c] = triangle[rows - 1][c];
            }

            // Now take triangle number + max choice below (c0 chooses c0,c1 .. c1 chooses c1,c2 etc)
            for (int r = rows - 2; r >= 0; r--)
            {
                for (int c = 0; c < r + 1; c++)
                {
                    sums[r][c] = triangle[r][c] + Math.Max(sums[r + 1][c], sums[r + 1][c + 1]);
                }
            }

            return sums[0][0].ToString();
        }
    }
}
