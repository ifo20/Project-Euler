namespace Euler
{
    using System;

    public class Problem4 : IProblems
    {
        public void Pose()
        {
            string q = @"
PROBLEM 3:
The prime factors of 13195 are 5, 7, 13 and 29. What is the largest prime factor of the number 600851475143 ?
";
            Console.WriteLine(q);
        }

        public string Solve()
        {
            Console.WriteLine("Here is the solution:");
            string ans = "answer";
            return ans.ToString();
        }
    }
}
