namespace Euler
{
    using System;

    public class Problem4 : IProblem
    {
        public static bool CheckPalindrome(int n) // Checks if a number is a palindrome
        {
            string s = n.ToString();
            int len = s.Length;
            for (int i = 0; i < len; i++)
            {
                char p = s[i]; // 1st, 2nd, 3rd, ... character
                char q = s[len - i - 1]; // Last, 2nd Last, 3rd Last, ... character
                if (p != q)
                {
                    return false;
                }
            }

            return true;
        }

        public void Pose()
        {
            string q = @"
PROBLEM 4:
A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 x 99.
Find the largest palindrome made from the product of two 3-digit numbers.
";
            Console.WriteLine(q);
        }

        public string Solve()
        {
            Console.WriteLine("Here is the solution:");
            int max = 0;
            int d = 3; // number of digits
            int lower_limit = (int)Math.Pow(10, d - 1) - 1;     // 99 for d = 3
            int upper_limit = (int)Math.Pow(10, d) - 1;     // 999 for d = 3
            for (int a = upper_limit; a > lower_limit; a--)
            {
                for (int b = upper_limit; b > lower_limit; b--)
                {
                    if (CheckPalindrome(a * b))
                    {
                        int ans = a * b;
                        if (ans > max)
                        {
                            max = ans;
                        }
                    }
                }
            }
            
            return max.ToString();
        }
    }
}
