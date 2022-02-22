using System;
using System.Text.RegularExpressions;
using Searches;

class Program
{
    public static void Main(string[] args)
    {
        // Load data files into arrays
        String[] dictionary = System.IO.File.ReadAllLines(@"data-files/dictionary.txt");
        String aliceText = System.IO.File.ReadAllText(@"data-files/AliceInWonderLand.txt");
        String[] aliceWords = Regex.Split(aliceText, @"\s+");

        //PART A
        Console.WriteLine("Please input a word to be checked");
        string inputWord = Console.ReadLine();

        //user picks linear or binary search
        
    }

    public static void printStringArray(String[] array, int start, int stop)
    {
        // Print out array elements at index values from start to stop 
        for (int i = start; i < stop; i++)
        {
            Console.WriteLine(array[i]);
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
            
            //the amount of iterations to GUARANTEE finding the term in a SORTED ARRAY is logbase2(length of array)
            for (int i = 0; i < Math.Ceiling(Math.Log(sortedArray.Length) / Math.Log(2)); i++) {

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
                } 

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