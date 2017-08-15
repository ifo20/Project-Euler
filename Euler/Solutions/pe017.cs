namespace Euler
{
    using System;

    public class Problem17 : IProblem
    {
        public void Pose()
        {
            string q = @"
PROBLEM 17:
If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?
NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters.
The use of 'and' when writing out numbers is in compliance with British usage.
";
            Console.WriteLine(q);
        }

        public string Solve()
        {
            int one_to_nine = "onetwothreefourfivesixseveneightnine".Length;
            int tens = "tentwentythirtyfortyfiftysixtyseventyeightyninety".Length;
            int hundred = "hundred".Length;
            int and = "and".Length;

            // one to nine appears 10 times, you have ten instances of each twenty e.g. twenty, twenty one, twenty two...
            int one_to_ninetynine = 10 * (one_to_nine + tens);

            // However, for 11-19 the pattern is different
            // e.g. tenone = eleven, tentwo = twelve, tenthree = thirteen, tenfour = fourteen - 1, tenfive = fifteen, tensix = sixteen - 1
            // tenseven = seventeen - 1, teneight = eighteen, tennine = nineteen - 1
            // You see from the above, in the teens we undercounted by 4 (fourteen,sixteen,seventeen,nineteen all have one more letter than tenfour etc):
            one_to_ninetynine += 4;
            
            // Counting to one thousand, we go through this ten times, using a hundred 900 times and each number (in front of the hundred) 100 times
            // Also, the word 'and' appears 99 times for each hundred and finally we have one thousand itself
            int total = (one_to_ninetynine * 10) + (900 * hundred) + (100 * one_to_nine) + (99 * 9 * and) + "onethousand".Length;

            return total.ToString();
        }
    }
}
