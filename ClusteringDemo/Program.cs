namespace ClusteringDemo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

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

        private static List<Vector2> GetRawData()
        {
            return new List<Vector2>
            {
                new Vector2(73, 72.6f),
                new Vector2(61, 54.4f),
                new Vector2(67, 99.9f),
                new Vector2(68, 97.3f),
                new Vector2(62, 59.0f),
                new Vector2(75, 81.6f),
                new Vector2(74, 77.1f),
                new Vector2(66, 97.3f),
                new Vector2(68, 93.3f),
                new Vector2(61, 59.0f)
            };
        }

        private static Vector2 CalculateCentroid(List<Vector2> items)
        {
            var result = items.Aggregate(Vector2.Zero, (current, point) => current + point);
            result /= items.Count;

            return result;
        }

        private static int[] GetRandomStart()
        {
            var rand = new Random();
            var rtnlist = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                rtnlist.Add(rand.Next(3));
            }
            return rtnlist.ToArray();
        }
    }
}
