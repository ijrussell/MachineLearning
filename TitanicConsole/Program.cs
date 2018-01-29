using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace TitanicConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var passengers = LoadRawData(@"Data\train.csv").ToList();

            Console.WriteLine($"There are {passengers.Count()} passengers in the file");

            var results = new List<Tuple<int, bool>>();

            foreach (var passenger in passengers)
            {
                results.Add(new Tuple<int, bool>(passenger.PassengerId, Survived(passenger)));
            }

            var path = @"c:\temp\export.csv";

            ExportTestResults(results, path);

            Console.WriteLine($"Saved to {path}");
            Console.ReadLine();
        }

        private static bool Survived(Passenger passenger)
        {
            return false;
        }

        private static IEnumerable<Passenger> LoadRawData(string path)
        {
            using (var parser = new TextFieldParser(path))
            {
                parser.SetDelimiters(new string[] { "," });
                parser.HasFieldsEnclosedInQuotes = true;

                // Skip over header line.
                parser.ReadLine();
                while (!parser.EndOfData)
                {
                    var line = parser.ReadFields();
                    yield return new Passenger
                    {
                        PassengerId = int.Parse(line[0]),
                        Pclass = int.Parse(line[1]),
                        Survived = int.Parse(line[2]) == 1,
                        Name = line[3],
                        Sex = line[4],
                        Age = !string.IsNullOrWhiteSpace(line[5]) ? decimal.Parse(line[5]) : 0m,
                        SibSp = int.Parse(line[6]),
                        Parch = int.Parse(line[7]),
                        Ticket = line[8],
                        Fare = !string.IsNullOrWhiteSpace(line[9]) ? decimal.Parse(line[9]) : 0m,
                        Cabin = line[10],
                        Embarked = line[11]
                    };
                }
            }
        }

        private static void ExportTestResults(List<Tuple<int, bool>> data, string path)
        {
            var result = new List<string> {"PassengerId,Survived"};

            result.AddRange(data.Select(item => $"{item.Item1},{(item.Item2 ? 1 : 0)}"));

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            File.AppendAllLines(path, result);
        }
    }
}
