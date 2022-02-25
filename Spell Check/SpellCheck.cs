using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Searches;

class Program
{
    //global variables
    static String[] dictionary;
    static String aliceText;
    static String[] aliceWords;

    public static void Main(string[] args)
    {

        // Load data files into arrays
        dictionary = System.IO.File.ReadAllLines(@"data-files/dictionary.txt");
        aliceText = System.IO.File.ReadAllText(@"data-files/AliceInWonderLand.txt");
        aliceWords = Regex.Split(aliceText, @"\s+");

        WhichOption();
        
    }

    private static void WhichOption() {

        int option = -1;

        while (option != 5) {
            //take user input
            Console.WriteLine(" ");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("  [1] Spell check single word (linear search)");
            Console.WriteLine("  [2] Spell check single word (binary search)");
            Console.WriteLine("  [3] Spell check Alice in Wonderland (linear search)");
            Console.WriteLine("  [4] Spell check Alice in Wonderland (binary search)");
            Console.WriteLine("  [5] Exit");
            option = Int32.Parse(Console.ReadLine());

            //check one word (linear)
            if (option == 1) {
                SingleWordCheck("linear");
            }
            //check one word (binary)
            else if (option == 2) 
            {
                SingleWordCheck("binary");
            }
            //check alice in wonderland (linear)
            else if (option == 3) 
            {
                AliceInWonderlandCheck("linear");
            }
            //check alice in wonderland (binary)
            else if (option == 4) 
            {
                AliceInWonderlandCheck("binary");
            }
        }
    }

    //user inputs one word
    private static void SingleWordCheck(string typeOfSearch) {
        
        //take user input
        Console.WriteLine(" ");
        Console.WriteLine("Word to be checked:");
        string word = Console.ReadLine().ToLower();

        //stopwatch
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        int index = 0;

        if (typeOfSearch == "linear") {

            index = Searches.Searches.LinearSearchString(dictionary, word);

        } else {

            index = Searches.Searches.BinarySearchString(dictionary, word);

        }

        //stop timer
        stopwatch.Stop();

        //output
        Console.WriteLine(" ");
        Console.WriteLine("\""+ word + "\" is in the dictionary at index " + index);
        Console.WriteLine("Time elapsed (" + typeOfSearch + " search): " + stopwatch.Elapsed.TotalMilliseconds + " milliseconds");
    }

    //check the whole alice in wonderland script
    private static void AliceInWonderlandCheck(string typeOfSearch) {

        //stopwatch
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        int wordsNotFound = 0;

        if (typeOfSearch == "linear") {

            for (int i = 0; i < aliceWords.Length; i++) {
                //if word is not present in dictionary, add count to wordsNotFound
                if (Searches.Searches.LinearSearchString(dictionary, aliceWords[i].ToLower()) == -1)
                    wordsNotFound++;
            }

        } else {

            for (int i = 0; i < aliceWords.Length; i++) {
                //if word is not present in dictionary, add count to wordsNotFound
                if (Searches.Searches.BinarySearchString(dictionary, aliceWords[i].ToLower()) == -1)
                    wordsNotFound++;
            }

        }

        //stop timer
        stopwatch.Stop();

        //output
        Console.WriteLine(" ");
        Console.WriteLine("Number of words not found in dictionary: " + wordsNotFound);
        Console.WriteLine("Time elapsed (" + typeOfSearch + " search): " + stopwatch.Elapsed.TotalMilliseconds + " milliseconds");
    }
}

//Linear and Binary searches
namespace Searches {

    public class Searches {

        //linear search algorithm for strings
        public static int LinearSearchString (string[] sortedArray, string term) {

            //loop through all the terms of the array
            for (int i = 0; i < sortedArray.Length; i++) {
                if (sortedArray[i] == term)
                    return i;
            }

            //specified term is not present in array
            return -1;

        }

        //binary search algorithm for strings
        public static int BinarySearchString (string[] sortedArray, string term) {

            int lowerBound = 0;
            int upperBound = sortedArray.Length - 1;

            //the amount of iterations to GUARANTEE finding the term in a SORTED ARRAY is logbase2(length of array)
            while (lowerBound <= upperBound) {

                //middleterm of the array in the bounds
                int middleTermIndex = (int) Math.Floor((upperBound + lowerBound) / (decimal) 2);
                string middleTerm = sortedArray[middleTermIndex];

                //comparing value
                int comparison = String.Compare(middleTerm, term);

                //is the array's middle term the one we're trying to find?
                if (comparison == 0)
                    return middleTermIndex;

                //middle term PRECEEDS wanted term
                if (comparison < 0) {
                    lowerBound = middleTermIndex + 1;
                    continue;
                } 

                //middle term FOLLOWS wanted term
                if (comparison > 0) {
                    upperBound = middleTermIndex - 1;
                    continue;
                }
            }

            //specified term is not present in array OR array is unsorted
            return -1;

        }
    }
}