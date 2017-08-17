namespace Euler
{
    using System;
    using System.Collections.Generic;

    public class Problem26 : IProblem
    {
        public void Pose()
        {
            string q = @"
PROBLEM 26:
A unit fraction contains 1 in the numerator. The decimal representation of the unit fractions with denominators 2 to 10 are given:

1/2	= 	0.5
1/3	= 	0.(3)
1/4	= 	0.25
1/5	= 	0.2
1/6	= 	0.1(6)
1/7	= 	0.(142857)
1/8	= 	0.125
1/9	= 	0.(1)
1/10	= 	0.1
Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. It can be seen that 1/7 has a 6-digit recurring cycle.

Find the value of d < 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.
";
            Console.WriteLine(q);
        }

        public string Solve()
        {
            int max = 6;

            // Loop through unit fractions 1/i
            for (int i = 7; i < 1000; i++)
            {
                // Try 10 divided by i, Add quotient to digits, r*10 , divide by i
                // else, Add 0 to digits, r*=10, divide by i
                bool done = false;
                int r = 10;
                List<int> digits = new List<int>();
                List<int> rs = new List<int>();
                while (!done)
                {
                    int q = (int)Math.Floor((decimal)r / i);
                    r = r % i;
                    int chk = rs.IndexOf(r);
                    
                    if (chk == -1) // Digit not yet found in sequence
                    {
                        digits.Add(q);
                        rs.Add(r);
                        r *= 10;
                        if (r == 0)
                        {
                            done = true;
                        }
                    }
                    else // Repeat digit found - what is the length of the recurring cycle? Found by comparing the positions of the two numbers i.e. how long since it appeared last?
                    { 
                        int clength = rs.Count - chk;
                        if (clength > max)
                        {
                            Console.WriteLine("fraction 1/" + i.ToString() + " has a cycle of " + clength.ToString());
                            max = clength;
                        }

                        done = true;
                    }
                }
            }

            return max.ToString();
        }
    }
}
