namespace ComputeUtility.Tests
{
    public class Tests
    {
        [TestCase(0.0, 0.0, 20, 0.0)]
        [TestCase(10.0, 0.0, 20, 10.0)]
        [TestCase(0.0, 10.0, 20, 0.0)]
        [TestCase(5.0, 10.0, 20, 0.0)]
        [TestCase(10.0, 5.0, 20, 5.0)]
        [TestCase(20.0, 5.0, 20, 15.0)]
        public void CreateOutputBasedOnInputAndThrehold(double input, double threshold, double limit, double expected_output)
        {
            double[] outputs = Compute.Run(new double[] { input }, threshold, limit);

            Assert.That(outputs[0], Is.EqualTo(expected_output));
        }

        [TestCase(new double[] { 19.0, 0.0, 1000, 1001.5, 20000, 25000000.0 }, 1000, 20000000, new double[] { 0.0, 0.0, 0.0, 1.5, 19000.0, 19980998.5, 20000000.0 })]
        [TestCase(new double[] { 0.0, 10.0, 50.0, 50.0, 10.0, 20.0 }, 0.0, 100, new double[] { 0.0, 10.0, 50.0, 40.0, 0.0, 0.0, 100.0 })]
        public void CheckTheCompleteOutput(double[] inputList, double threshold, double limit, double[] expected_outputList)
        {
            double[] outputs = Compute.Run(inputList, threshold, limit);

            Assert.That(outputs, Is.EquivalentTo(expected_outputList));
        }
    }
}