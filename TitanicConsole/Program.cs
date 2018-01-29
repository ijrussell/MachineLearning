using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic.FileIO;

namespace TitanicConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var passengers = LoadRawData(@"Data\train.csv");

            Console.WriteLine($"There are {passengers.Count()} passengers in the file");
            Console.ReadLine();
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
    }
}
