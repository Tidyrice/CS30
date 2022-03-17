// Sort Analyzer Start Code

using System;
using System.IO;
using System.Diagnostics;

class SortAnalyzer {

    static int[] randomData;
    static int[] reversedData;
    static int[] nearlySortedData;
    static int[] fewUniqueData;

    public static void Main (string[] args) {

        //LOAD DATA FILES INTO ARRAYS
        randomData = loadDataArray("data-files/random-values.txt");
        reversedData = loadDataArray("data-files/reversed-values.txt");
        nearlySortedData = loadDataArray("data-files/nearly-sorted-values.txt");
        fewUniqueData = loadDataArray("data-files/few-unique-values.txt");
        
        //run tests
        testBubble();
        testSelection();
        testInsertion();
        
    }

    private static void testBubble() {
        
        Console.WriteLine("");
        Console.WriteLine("Bubble Sort");

        double time = 0;

        for (int i = 0; i < 10; i++) {
            //deep copy of array
            int[] array = new int[randomData.Length];
            Array.Copy(randomData, array, randomData.Length);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            BubbleSortIntArray(array);

            stopwatch.Stop();
            time += stopwatch.Elapsed.TotalMilliseconds;
        }

        time = time / 10;
        Console.WriteLine("Random array: average " + time + " milliseconds");
        time = 0;

        for (int i = 0; i < 10; i++) {
            int[] array = new int[randomData.Length];
            Array.Copy(reversedData, array, randomData.Length);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            BubbleSortIntArray(array);

            stopwatch.Stop();
            time += stopwatch.Elapsed.TotalMilliseconds;
        }

        time = time / 10;
        Console.WriteLine("Reversed array: average " + time + " milliseconds");
        time = 0;

        for (int i = 0; i < 10; i++) {
            int[] array = new int[randomData.Length];
            Array.Copy(nearlySortedData, array, randomData.Length);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            BubbleSortIntArray(array);

            stopwatch.Stop();
            time += stopwatch.Elapsed.TotalMilliseconds;
        }

        time = time / 10;
        Console.WriteLine("Nearly sorted array: average " + time + " milliseconds");
        time = 0;

        for (int i = 0; i < 10; i++) {
            int[] array = new int[randomData.Length];
            Array.Copy(fewUniqueData, array, randomData.Length);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            BubbleSortIntArray(array);

            stopwatch.Stop();
            time += stopwatch.Elapsed.TotalMilliseconds;
        }

        time = time / 10;
        Console.WriteLine("Few unique array: average " + time + " milliseconds");
        time = 0;

    }

    private static void testSelection() {
        
        Console.WriteLine("");
        Console.WriteLine("Selection Sort");

        double time = 0;

        for (int i = 0; i < 10; i++) {
            int[] array = new int[randomData.Length];
            Array.Copy(randomData, array, randomData.Length);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            SelectionSortIntArray(array);

            stopwatch.Stop();
            time += stopwatch.Elapsed.TotalMilliseconds;
        }

        time = time / 10;
        Console.WriteLine("Random array: average " + time + " milliseconds");
        time = 0;

        for (int i = 0; i < 10; i++) {
            int[] array = new int[randomData.Length];
            Array.Copy(reversedData, array, randomData.Length);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            SelectionSortIntArray(array);

            stopwatch.Stop();
            time += stopwatch.Elapsed.TotalMilliseconds;
        }

        time = time / 10;
        Console.WriteLine("Reversed array: average " + time + " milliseconds");
        time = 0;

        for (int i = 0; i < 10; i++) {
            int[] array = new int[randomData.Length];
            Array.Copy(nearlySortedData, array, randomData.Length);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            SelectionSortIntArray(array);

            stopwatch.Stop();
            time += stopwatch.Elapsed.TotalMilliseconds;
        }

        time = time / 10;
        Console.WriteLine("Nearly sorted array: average " + time + " milliseconds");
        time = 0;

        for (int i = 0; i < 10; i++) {
            int[] array = new int[randomData.Length];
            Array.Copy(fewUniqueData, array, randomData.Length);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            SelectionSortIntArray(array);

            stopwatch.Stop();
            time += stopwatch.Elapsed.TotalMilliseconds;
        }

        time = time / 10;
        Console.WriteLine("Few unique array: average " + time + " milliseconds");
        time = 0;

    }

    private static void testInsertion() {
        
        Console.WriteLine("");
        Console.WriteLine("Insertion Sort");

        double time = 0;

        for (int i = 0; i < 10; i++) {
            int[] array = new int[randomData.Length];
            Array.Copy(randomData, array, randomData.Length);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            InsertionSortIntArray(array);

            stopwatch.Stop();
            time += stopwatch.Elapsed.TotalMilliseconds;
        }

        time = time / 10;
        Console.WriteLine("Random array: average " + time + " milliseconds");
        time = 0;

        for (int i = 0; i < 10; i++) {
            int[] array = new int[randomData.Length];
            Array.Copy(reversedData, array, randomData.Length);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            InsertionSortIntArray(array);

            stopwatch.Stop();
            time += stopwatch.Elapsed.TotalMilliseconds;
        }

        time = time / 10;
        Console.WriteLine("Reversed array: average " + time + " milliseconds");
        time = 0;

        for (int i = 0; i < 10; i++) {
            int[] array = new int[randomData.Length];
            Array.Copy(nearlySortedData, array, randomData.Length);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            InsertionSortIntArray(array);

            stopwatch.Stop();
            time += stopwatch.Elapsed.TotalMilliseconds;
        }

        time = time / 10;
        Console.WriteLine("Nearly sorted array: average " + time + " milliseconds");
        time = 0;

        for (int i = 0; i < 10; i++) {
            int[] array = new int[randomData.Length];
            Array.Copy(fewUniqueData, array, randomData.Length);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            InsertionSortIntArray(array);

            stopwatch.Stop();
            time += stopwatch.Elapsed.TotalMilliseconds;
        }

        time = time / 10;
        Console.WriteLine("Few unique array: average " + time + " milliseconds");
        time = 0;

    }

    //bubble sort int[]
    private static int[] BubbleSortIntArray(int[] intArray) {

        //maximum number of passes it needs
        for (int i = 0; i < intArray.Length - 1; i++) {

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

                }
            }
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