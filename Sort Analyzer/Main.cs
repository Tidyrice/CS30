// Sort Analyzer Start Code

using System;
using System.IO;
using System.Diagnostics;

class SortAnalyzer {
    public static void Main (string[] args) {
        // LOAD DATA FILES INTO ARRAYS
        int[] randomData = loadDataArray("data-files/random-values.txt");
        int[] reversedData = loadDataArray("data-files/reversed-values.txt");
        int[] nearlySortedData = loadDataArray("data-files/nearly-sorted-values.txt");
        int[] fewUniqueData = loadDataArray("data-files/few-unique-values.txt");
        
        //stopwatch
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        //stop timer
        stopwatch.Stop();

        //output
        Console.WriteLine(stopwatch.Elapsed.TotalMilliseconds + " milliseconds");
    }

    /*private static void WhichOption() {

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
    }*/

    //bubble sort int[]
    private static int[] BubbleSortIntArray(int[] intArray) {

        //maximum number of passes it needs
        for (int i = 0; i < intArray.Length - 1; i++) {

            //was there a swap in this pass?
            bool swaped = false;

            //number of swaps per pass
            for (int j = 0; j < intArray.Length - 1 - i; j++) {

                //terms to compare
                int first = intArray[j];
                int second = intArray[j + 1];

                //not sorted
                if (first > second) {

                    //swap values
                    intArray[j] = second;
                    intArray[j + 1] = first;

                    //a swap has occured
                    swaped = true;

                }

            }

            //no swaps occured in this pass: array is sorted
            if (!swaped)
                return intArray;

        }

        //something weird happened
        return null;

    }

    //selection sort int[]
    private static int[] SelectionSortIntArray(int[] array) {

        //number of passes
        for (int fillSlot = 0; fillSlot < array.Length - 1; fillSlot++) {

            //min value tracker
            int lowestValueIndex = fillSlot;

            //loop through each term of array
            for (int i = fillSlot + 1; i < array.Length; i++) {

                //is this term smaller than the minimum recorded?
                if (array[i] < array[lowestValueIndex]) {
                    lowestValueIndex = i;
                }

            }

            //swap min value with first unsorted term
            int temp = array[fillSlot];
            array[fillSlot] = array[lowestValueIndex];
            array[lowestValueIndex] = temp;

        }

        return array;

    }

    //insertion sort int[]
    private static int[] InsertionSortIntArray(int[] array) {

        for (int i = 1; i < array.Length; i++) {

            //value to insert
            int term = array[i];

            //insert position
            int pos = i;

            //there are elements to the left of the insert position and the test element to the left is > value to insert
            //array[pos - 1] is the test element
            while (pos > 0 && array[pos - 1] > term) {
                
                //slide the test element to the right
                array[pos] = array[pos - 1];

                //decrease the insert position
                pos--;

            }

            //the value to insert is in the right position
            array[pos] = term;

        }
        
        return array;

    }

    // Function to create an array of integers from provided data file
    public static int[] loadDataArray(string fileName) {

        // Read Text File by Line 
        string[] lines = File.ReadAllLines(fileName);

        // Create Array of Integers
        int[] tempData = new int[lines.Length];

        for (int i = 0; i < lines.Length; i++) {
            tempData[i] = Convert.ToInt32(lines[i]);
        }

        // Return Array of Integers
        return tempData;

    }

}