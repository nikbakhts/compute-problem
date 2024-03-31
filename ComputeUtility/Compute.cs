namespace ComputeUtility
{
    public class Compute
    {
        public static double[] Run(double[] input, double threshold, double limit)
        {
            double[] output = new double[input.Length + 1];

            //sum of all output items
            double sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                double output_item = input[i] <= threshold ? 0.0 : input[i] - threshold;
                var diff = limit - (output_item + sum);

                if (diff <= 0)
                    output_item = output_item - Math.Abs(diff);

                sum += output_item;
                output[i] = output_item;
            }
            //add sum of all output items to output
            output[input.Length] = sum;

            return output;
        }
    }
}