namespace ClusteringDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //k-Means clustering with 3 centroids
            //randomly assign all data items to a cluster
            //loop until no change in cluster assignments
            //  compute centroids for each cluster
            //  reassign each data item to cluster of closest centroid
            //end

            //Expected results { 67.3, 97.0 }, { 74.0, 77.1 }, { 61.3, 57.5 }
        }

        private static double[][] GetRawData()
        {
            var rawData = new double[10][];
            rawData[0] = new double[] { 73, 72.6 };
            rawData[1] = new double[] { 61, 54.4 };
            rawData[2] = new double[] { 67, 99.9 };
            rawData[3] = new double[] { 68, 97.3 };
            rawData[4] = new double[] { 62, 59.0 };
            rawData[5] = new double[] { 75, 81.6 };
            rawData[6] = new double[] { 74, 77.1 };
            rawData[7] = new double[] { 66, 97.3 };
            rawData[8] = new double[] { 68, 93.3 };
            rawData[9] = new double[] { 61, 59.0 };
            return rawData;
        }
    }
}
