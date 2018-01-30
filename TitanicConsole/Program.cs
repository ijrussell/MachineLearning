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
            var passengers = LoadTrainData().ToList();

            Console.WriteLine($"There are {passengers.Count()} passengers in the file");

            //TODO: Use training data to build an algorithm to determine if a passenger survived or not.

            var testData = LoadTestData().ToList();

            foreach (var passenger in testData)
            {
                passenger.Survived = Survived(passenger);
            }

            var path = @"c:\temp\export.csv";

            ExportTestResults(testData, path);

            Console.WriteLine($"Saved to {path}");
            Console.ReadLine();
        }

        private static bool Survived(Passenger passenger)
        {
            return false;
        }

        private static IEnumerable<Passenger> LoadTrainData()
        {
            using (var parser = new TextFieldParser(@"Data\train.csv"))
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

        private static IEnumerable<Passenger> LoadTestData()
        {
            using (var parser = new TextFieldParser(@"Data\test.csv"))
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
                        Name = line[2],
                        Sex = line[3],
                        Age = !string.IsNullOrWhiteSpace(line[4]) ? decimal.Parse(line[4]) : 0m,
                        SibSp = int.Parse(line[5]),
                        Parch = int.Parse(line[6]),
                        Ticket = line[7],
                        Fare = !string.IsNullOrWhiteSpace(line[8]) ? decimal.Parse(line[8]) : 0m,
                        Cabin = line[9],
                        Embarked = line[10]
                    };
                }
            }
        }

        private static void ExportTestResults(List<Passenger> data, string path)
        {
            var result = new List<string> {"PassengerId,Survived"};

            result.AddRange(data.Select(item => $"{item.PassengerId},{(item.Survived ? 1 : 0)}"));

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            File.AppendAllLines(path, result);
        }
    }
}
