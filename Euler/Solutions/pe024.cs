namespace Euler
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Problem24 : IProblem
    {
        public static int Factorial(int n)
        {
            int x = 1;
            for (int i = 2; i < n + 1; i++)
            {
                x *= i;
            }
            return x;
        }

        public void Pose()
        {
            string q = @"
PROBLEM 24:
A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4.
If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:
012   021   102   120   201   210
What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
";
            Console.WriteLine(q);
        }

        public string Solve()
        {

            // Easiest to explain what this program does by an example:
            // There are 10! = 3,628,800 permutations of 0-9
            // In lexicographic order, the first 362,880 (9!) begin with 0, the next 362,880 with 1, etc
            // 362,880 x 2 = 725,760 therefore the permutations beginning with 2 begin from the 725,761th permutation and encompass the millionth mark (since 725,761 + 362,880 > 1e6
            // So we only consider these (e.g. 2013456789). We want the 274,240th (1,000,000 - 725,761 + 1)
            // The first 40,320 (8!) begin with 0 ..... the first 241,920 (40,320 x 6) begin with 0,1,3,4,5,6
            // So we only consider beginning with 27 ... we want the (274,340 - 241,920)th i.e. 32,320th
            // 7! is 5,040 so we can do 6 (30,240) of these: 0,1,3,4,5,6, then next is 8 and then we want 2,080th
            // 6! is 720 so we can do two: 1,440 = 278 < 0,1,> so we want 2783 .... 640th position
            // 5! is 120 ..... 5 x = 600 2783<0,1,4,5,6> 27839 .... 40th position
            // 4! is 24 ...... 1x so now 278391 .. 16th position
            // 3! is 6 ...... 2x so now 2783915 .... 4th position
            // 2! is 2 ..... 1x so now 2th position from 27839154
            // 1! is 1 .... 1x so 2783915460

            // The below code formalises this approach

            // Which permuation are we looking for? The millionth!
            int n = 1000000;

            // Initialise digits array 
            int[] digits = new int[10]; // digits is an array storing the digits used in our permutation in the appropriate order
            for (int i = 0; i < 10; i++)
            {
                digits[i] = 0;
            }

            // used_digits stores the digits already used in our permutation (separate from the array 'digits' to avoid the problem of already using 0)
            List<int> used_digits = new List<int>(); 

            // Enter loop; we start with the first digit
            for (int x = 9; x >= 0; x--)
            {
                if (n > Factorial(x))
                {
                    // This digit is not in the first group (e.g. first digit isn't 0)
                    // We can skip groups of factorials as they will all begin with the same first digit - so we 'fast-forward' until we figure out the first digit
                    while (n > Factorial(x)) 
                    {
                        n -= Factorial(x);
                        digits[9 - x]++;
                        while (used_digits.IndexOf(digits[9 - x]) != -1)
                        {
                            digits[9 - x]++;
                        }
                        for (int i = 0; i < 10; i++)
                        {
                            Console.Write(digits[i].ToString());
                        }
                        Console.WriteLine("");

                        if (n <= Factorial(x))
                        {
                            used_digits.Add(digits[9 - x]);
                        }
                    }
                }
                else
                {
                    // We can't skip any 'batches' so leave as lowest number possible
                    while (used_digits.IndexOf(digits[9 - x]) != -1)
                    {
                        digits[9 - x]++;
                    }
                    used_digits.Add(digits[9 - x]);
                }
            }

            string ans = string.Empty;
            for (int i = 0; i < 10; i++)
            {
                ans += digits[i].ToString();
            }

            return ans;
        }
    }
}
