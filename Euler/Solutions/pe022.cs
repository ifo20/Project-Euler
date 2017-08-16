namespace Euler
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class Problem22 : IProblem
    {
        public void Pose()
        {
            string q = @"
PROBLEM 22:
Using names.txt, a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order.
Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.

For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. 
So, COLIN would obtain a score of 938 x 53 = 49714.

What is the total of all the name scores in the file?
";
            Console.WriteLine(q);
        }

        public string Solve()
        {
            string text;
            StreamReader reader;
            using (var fs = new FileStream(@"Resources/pe022-names.txt", FileMode.Open, FileAccess.Read))
            using (reader = new StreamReader(fs))
            {
                text = reader.ReadToEnd();
            }
            
            List<string> names = new List<string>();
            string name = string.Empty;
            foreach (char ch in text)
            {
                if (ch == ',')
                {
                    // Reset
                    names.Add(name);
                    name = string.Empty;
                }
                else if (ch == '"')
                {
                    // Do nothing
                }
                else
                {
                    // Add ch->int to current name int list
                    name = name + ch;
                }
            }

            // Last name won't have comma after it, so won't get added in the do while loop, hence we add it here
            names.Add(name);
            names.Sort();
            int t = 0;
            int n = names.Count;
            for (int i = 0; i < n; i++)
            {
                // Calculate score and add to total
                int score = 0;
                foreach (char c in names[i])
                {
                    score += Convert.ToInt32(c) - 64;
                }

                score *= i + 1;
                t += score;
            }

            return t.ToString();
        }
    }
}
