//BINARY SEARCH ALGORITHM
//RUN THIS FILE USING: .\\Main.exe
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BinarySearch {

    //test arrays
    private static int[] sortedIntArray = {10, 30, 40, 45, 70, 80, 85, 90, 100};
    private static string[] sortedStringArray = {"at", "ball", "cat", "dog", "eye", "fish", "good"};
    private static int[] unsortedIntArray = {30, 20, 70, 40, 50, 100, 90};

    static void Main(string[] args) {

        //test cases
        Console.WriteLine(BinarySearchInt(sortedIntArray, 100));
        Console.WriteLine(BinarySearchInt(sortedIntArray, 75));
        Console.WriteLine(BinarySearchString(sortedStringArray, "fish"));
        Console.WriteLine(BinarySearchString(sortedStringArray, "at"));
        Console.WriteLine(BinarySearchInt(unsortedIntArray, 70));

    }

    //binary search algorithm for integers
    private static int BinarySearchInt (int[] sortedArray, int term) {

        int lowerBound = 0;
        int upperBound = sortedArray.Length - 1;
        
        //the amount of iterations to GUARANTEE finding the term in a SORTED ARRAY is logbase2(length of array)
        for (int i = 0; i < Math.Ceiling(Math.Log(sortedArray.Length) / Math.Log(2)); i++) {

            //middleterm of the array in the bounds
            int middleTermIndex = (int) Math.Floor((upperBound + lowerBound) / (decimal) 2);
            int middleTerm = sortedArray[middleTermIndex];

            //is the array's middle term the one we're trying to find?
            if (middleTerm == term)
                return middleTermIndex;

            //the array's middle term is LARGER than the term in question (term is in bottom half of array)
            if (middleTerm > term) {
                upperBound = middleTermIndex - 1;
                continue;
            } 

            //the array's middle term is SMALLER than the term in question (term is in top half of array)
            if (middleTerm < term) {
                lowerBound = middleTermIndex + 1;
                continue;
            }
        }

        //specified term is not present in array OR array is unsorted
        return -1;

    }

    //binary search algorithm for strings
    private static int BinarySearchString (string[] sortedArray, string term) {

        int lowerBound = 0;
        int upperBound = sortedArray.Length - 1;
        
        //the amount of iterations to GUARANTEE finding the term in a SORTED ARRAY is logbase2(length of array)
        for (int i = 0; i < Math.Ceiling(Math.Log(sortedArray.Length) / Math.Log(2)); i++) {

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