namespace LetterValueSum_399
{
    public class LetterValueSum
    {
        public LetterValueSum()
        {
        }

        public int Sum(string? input)
        {
            if (input == null)
            {
                throw new ArgumentException("Input string was null.", nameof(input));
            }

            return SumLetterValues(input);
        }

        private static int SumLetterValues(string input)
        {
            var sum = 0;

            foreach (var c in input)
            {
                if (c < 'a' || c > 'z')
                {
                    throw new ArgumentException($"Allowable characters are only 'a' through 'z'.");
                }

                sum += c - 'a' + 1;
            }

            return sum;
        }
    }
}
