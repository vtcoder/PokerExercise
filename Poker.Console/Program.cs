using Poker.Domain.Entities;
using Poker.Domain.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Console
{
    class Program
    {
        private const string INVALID_FILE_ARG_MESSAGE = "A valid file path must be specified.";

        static void Main(string[] args)
        {
            System.Console.WriteLine("Poker Score Calculator");

            try
            {
                string filePath = GetFilePath(args);

                CardParser parser = new CardParser();
                IEnumerable<Card> cards = parser.LoadCardsFromFile(filePath);

                ScoreCalculator scoreCalculator = new ScoreCalculator();
                Score score = scoreCalculator.CalculateScore(cards);

                System.Console.WriteLine("\nThe calculated poker score was:");
                System.Console.WriteLine(score);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("\nAn error occurred while attempting to calculate the score: {0}", ex.Message);
            }

            System.Console.WriteLine("\nPress any key to quit.");
            System.Console.ReadKey();
        }

        static string GetFilePath(string[] args)
        {
            if (args == null || args.Length < 1 || string.IsNullOrWhiteSpace(args[0]))
                throw new ArgumentException(INVALID_FILE_ARG_MESSAGE);

            string filePath = args[0];
            if (!File.Exists(filePath))
                throw new ArgumentException(INVALID_FILE_ARG_MESSAGE);

            return filePath;
        }
    }
}
