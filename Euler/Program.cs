namespace Euler
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello User!");
            bool finished = false;
            while (!finished)
            {
                bool success = false;
                int id = 0;
                string input = string.Empty;
                while (!success)
                {
                    Console.WriteLine("Which Project Euler problem would you like to see? Enter the number only, or q to quit");

                    input = Console.ReadLine();
                    if (input == "q")
                    {
                        Environment.Exit(0);
                    }

                    try
                    {
                        id = int.Parse(input);
                        success = true;
                    }
                    catch
                    {
                        Console.WriteLine("Apologies. I don't think that was an integer. Please try again:");
                    }
                }

                IProblem problem = new Problem1();
                try
                {
                    problem = (IProblem)CreateSpecificInstance("Problem" + id.ToString());
                }
                catch
                {
                    Console.WriteLine("Apologies. I don't seem to have problem {0} in my library. I will exit this program in shame", id);
                    Environment.Exit(1);
                }

                problem.Pose();

                Console.WriteLine("Press y to see solution, q to quit, or any other key to see another problem");
                input = Console.ReadLine();

                if (input == "q")
                {
                    Environment.Exit(1);
                }

                string result;
                if (input == "y")
                {
                    result = problem.Solve();
                    Console.WriteLine("Answer: " + result);
                }
            }
        }

        private static object CreateSpecificInstance(string className)
        {
            var assembly = Assembly.GetEntryAssembly();

            var type = assembly.GetTypes().First(t => t.Name == className);

            return Activator.CreateInstance(type);
        }
    }
}