using System;
using System.Text.RegularExpressions;
using Searches;

class Program
{
    //global variables
    String[] dictionary;
    String aliceText;
    String[] aliceWords;

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
            option = Console.ReadLine();

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
        string word = Console.ReadLine();

        //get time
        long beginTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();

        int index = 0;

        if (typeOfSearch == "linear") {
            index = LinearSearchString(dictionary, word);
        } else {
            index = BinarySearchString(dictionary, word);
        }

        //get time
        long endTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();

        //output
        Console.WriteLine(word + " is in the dictionary at index " + index);
        Console.WriteLine("Time elapsed: " + endTime - beginTime + " milliseconds");
    }

    //check the whole alice in wonderland script
    private static void AliceInWonderlandCheck(string typeOfSearch) {

        if (typeOfSearch == "linear") {

        } else {

        }
        
    } 
}





namespace Searches {

    public class Searches {

        //linear search algorithm for strings
        public static int LinearSearchString (string [] sortedArray, string term) {

            //loop through all the terms of the array
            for (int i = 0; i < sortedArray.length; i++) {
                if (sortedArray[i] == term)
                    return i;
            }

            //specified term is not present in array OR array is unsorted
            return -1;

        }

        //binary search algorithm for strings
        public static int BinarySearchString (string[] sortedArray, string term) {

            //convert the string to a decimal
            double decimalValue = StringToDouble(term);

            int lowerBound = 0;
            int upperBound = sortedArray.Length - 1;
            
            //loop until there are no more terms to search
            while (lowerBound <= upperBound) {

                //middleterm of the array in the bounds
                int middleTermIndex = (int) Math.Floor((upperBound + lowerBound) / (decimal) 2);
                double middleTerm = StringToDouble(sortedArray[middleTermIndex]);

                //is the array's middle term the one we're trying to find?
                if (middleTerm == decimalValue)
                    return middleTermIndex;

                //the array's middle term is LARGER than the term in question (term is in bottom half of array)
                if (middleTerm > Math.Floor(decimalValue)) {
                    upperBound = middleTermIndex - 1;
                    continue;
                } else 

                //the array's middle term is SMALLER than the term in question (term is in top half of array)
                if (middleTerm < Math.Floor(decimalValue)) {
                    lowerBound = middleTermIndex + 1;
                    continue;
                }
            }

            //specified term is not present in array OR array is unsorted
            return -1;

        }

        //function to convert string to decimal
        public static double StringToDouble(string text) {

            //split string into an array of characters
            char[] charArray = text.ToCharArray();

            //converts each chararcter to a decimal
            double decimalValue = 0;
            for (int i = 0; i < charArray.Length; i++) {
                decimalValue += charArray[i] * Math.Pow(10, -i);
            }

            return decimalValue;
        }
    }
}