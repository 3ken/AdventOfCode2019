using System;
using System.Collections.Generic;
using System.Linq;

namespace Fourth
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfPossiblePasswords = 0;
            for (var i = 130254; i <= 678275; i++)
            {
                if (CanBePassword(i))
                    numberOfPossiblePasswords++;
            }
            
            Console.WriteLine(numberOfPossiblePasswords);
            Console.ReadLine();
        }

        private static bool CanBePassword(int number)
        {
            var numberArray = number.ToString().ToCharArray().Select(Convert.ToInt32).ToArray();
            return IsSixDigits(numberArray)
                   && OnlyIncreasesOrStayTheSame(numberArray)
                   && GotTwoAdjacentDigitsThatAreTheSame(numberArray);
        }

        private static bool IsSixDigits(IReadOnlyCollection<int> numbers)
        {
            return numbers.Count == 6;
        }

        private static bool GotTwoAdjacentDigitsThatAreTheSame(IReadOnlyCollection<int> numbers)
        {
            var distinctNumbers = numbers.Distinct().ToList();
            return distinctNumbers.Count < 6 
                   && distinctNumbers.Any(distinctNumber => numbers.Count(number => number == distinctNumber) == 2);
        }

        private static bool OnlyIncreasesOrStayTheSame(IReadOnlyList<int> numbers)
        {
            for (var i = 0; i < 6; i++)
            {
                if (i == 5)
                    return true;
                if (numbers[i] > numbers[i + 1])
                    return false;
            }

            return true;
        }

        private static bool TwoAdjacentMatchingDigitsAreNotPartOfALargerGroupOfMatchingDigits(
            int[] numbers)
        {
            for (var i = 0; i < 6; i++)
            {
                if (i == 3)
                    return false;
                if (numbers[i] == numbers[i + 1] && numbers[i] != numbers[i + 2])
                {
                    var index = i + 2;
                    return GotTwoAdjacentDigitsThatAreTheSame(numbers[index..]);
                }
            }

            return false;
        }
    }
}