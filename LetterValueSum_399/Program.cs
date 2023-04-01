namespace LetterValueSum_399
{
    /// <summary>
    /// https://old.reddit.com/r/dailyprogrammer/comments/onfehl/20210719_challenge_399_easy_letter_value_sum/
    /// </summary>
    public static class Program
    {
        private static int Main(string[] args)
        {
            try
            {
                var input = GetInput(args);

                if (input == null)
                {
                    return 1;
                }

                var sum = SumLetterValues(input);

                Console.WriteLine($"{input} => {sum}");
            }
            catch (Exception ex)
            {
                var message = $"Error: {ex.Message}";
                System.Diagnostics.Trace.WriteLine(message);
                Console.WriteLine(message);
                return 1;
            }

            return 0;
        }

        private static string? GetInput(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine($"No command line input found.");
                return null;
            }


            return args[0].ToLowerInvariant();
        }

        private static int SumLetterValues(string input)
        {
            var sum = 0;

            foreach (var c in input)
            {
                sum += c - 96;
            }

            return sum;
        }
    }
}