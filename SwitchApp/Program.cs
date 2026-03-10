namespace SwitchApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dayOfWeek = "Monday";

            switch (dayOfWeek) 
            {
                case "Monday":
                    Console.WriteLine("It's Monday!");
                    break;
                case "Tuesday":
                    Console.WriteLine("It's Tuesday!");
                    break;
                case "Wednesday":
                    Console.WriteLine("It's Wednesday!");
                    break;
                case "Thursday":
                    Console.WriteLine("It's Thursday!");
                    break;
                case "Friday":
                    Console.WriteLine("It's Friday!");
                    break;
                case "Saturday":
                    Console.WriteLine("It's Saturday!");
                    break;
                case "Sunday":
                    Console.WriteLine("It's Sunday!");
                    break;
                default:
                    Console.WriteLine("Invalid day of the week.");
                    break;
            }

            // Switch expression
            int day = 2;

            var result = day switch
            {
                1 => "Monday",
                2 => "Tuesday",
                3 => "Wednesday",
                4 => "Thursday",
                5 => "Friday",
                6 => "Saturday",
                7 => "Sunday",
                _ => "Invalid day"
            };

            // pattern matching with switch expression
            int score = 85;

            var grade = score switch
            {
                >= 90 => "A",
                >= 80 => "B",
                >= 70 => "C",
                >= 50 => "D",
                _ => "F"
            };

        }
    }
}
