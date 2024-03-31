namespace ComputeUtility
{
    public class Program
    {
        const double MinValue = 0;
        const double MaxValue = 1000000000;
        public static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.Out.WriteLine("Usage: compute <threshold> <limit>");
                Environment.Exit(1);
            }

            //threshold is a number between 0.0 and 1,000,000,000.0
            double threshold;
            if (!Double.TryParse(args[0], out threshold) || !IsInRange(threshold))
            {
                Console.Out.WriteLine("Threshold must be a number between " + MinValue + " and " + MaxValue);
                Environment.Exit(1);
            }

            //limit is a number between 0.0 and 1,000,000,000.0
            double limit;
            if (!Double.TryParse(args[1], out limit) || !IsInRange(limit))
            {
                Console.Out.WriteLine("Limit must be a number between " + MinValue + " and " + MaxValue);
                Environment.Exit(1);
            }

            var inputs = ReadInputs();
            var output = Compute.Run(inputs.ToArray(), threshold, limit);
            foreach(var outputItem in output)
            {
                Console.WriteLine(outputItem.ToString("F1"));
            }
        }

        private static bool IsInRange(double num)
        { 
            return num >= MinValue || num <= MaxValue;
        }

        private static List<double> ReadInputs()
        {
            var inputs = new List<double>();

            for (int i = 0; i < 100; i++)
            {
                string? line;

                if (string.IsNullOrEmpty(line = Console.ReadLine()))
                    break;

                if (!double.TryParse(line, out double input) || !IsInRange(input))
                {
                    Console.WriteLine("Input must be a number between " + MinValue + " and " + MaxValue);
                    Environment.Exit(1);
                }

                inputs.Add(input);
            }

            return inputs;
        }
    }
}