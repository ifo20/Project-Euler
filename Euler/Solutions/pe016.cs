namespace Euler
{
    using System;

    public class Problem16 : IProblem
    {
        public void Pose()
        {
            string q = @"
PROBLEM 16:
215 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.
What is the sum of the digits of the number 2 to the power 1000?
";
            Console.WriteLine(q);
        }

        public string Solve()
        {
            // We solve the large number problem by creating an array with enough digits (we need 308)
            // We then mutlipy each digit by 2 and carry remainders over , a repeat 1000x
            int length = 308;
            int sum = 0;
            int[] numbers_array = new int[length];
            int[] remainders_array = new int[length];
            numbers_array[length - 1] = 1;
            remainders_array[length - 1] = 0;
            for (int i = 0; i < length - 1; i++)
            {
                numbers_array[i] = 0;
                remainders_array[i] = 0;
            }

            // Multiply the array (currently 000....001) by 2 one thousand times
            for (int i = 0; i < 1000; i++) 
            {
                for (int j = length - 1; j > 0; j--)
                {
                    numbers_array[j] *= 2;
                    if (numbers_array[j] > 9)
                    {
                        numbers_array[j] -= 10;
                        remainders_array[j - 1] = 1;
                    }
                    else
                    {
                        remainders_array[j - 1] = 0;
                    }

                    // Now add carry-overs from before
                    numbers_array[j] += remainders_array[j];
                }
            }

            for (int i = 0; i < length; i++)
            {
                sum += numbers_array[i];
            }

            return sum.ToString();
        }
    }
}
