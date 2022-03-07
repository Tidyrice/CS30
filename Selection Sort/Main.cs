using System;

public class SelectionSort {

    //test arrays
    private static int[] nums= {10, 70, 30, 100, 40, 45, 90, 80, 85};
    private static string[] words = {"dog","at", "good", "eye", "cat", "ball", "fish"};

    public static void Main(string[] args) {

        //output
        Console.WriteLine("[{0}]", string.Join(", ", SelectionSortIntArray(nums)));
        //Console.WriteLine("[{0}]", string.Join(", ", SelectionSortStringArray(words)));

    }

    //selection sort int[]
    private static int[] SelectionSortIntArray(int[] intArray) {
Console.WriteLine(string.Join(", ", intArray));
        int timesIterated = 0;

        while (timesIterated < intArray.Length) {

            //min value trackers
            int lowestValue = intArray[timesIterated];
            int lowestValueIndex = timesIterated;

            //first unsorted term
            int firstUnsorted = intArray[timesIterated];
            int firstUnsortedIndex = timesIterated;


            //loop through each term of array
            for (int i = timesIterated; i < intArray.Length; i++) {

                //is this term smaller than the minimum recorded?
                if (intArray[i] < lowestValue) {
                    lowestValue = intArray[i];
                    lowestValueIndex = i;
                }

                //swap min value with first unsorted term
                intArray[firstUnsortedIndex] = lowestValue;
                intArray[lowestValueIndex] = firstUnsorted;

            }
Console.WriteLine(string.Join(", ", intArray));
            timesIterated++;

        }

        return intArray;

    }

    //selection sort string[]

}