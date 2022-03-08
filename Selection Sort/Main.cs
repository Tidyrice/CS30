using System;

public class SelectionSort {

    //test arrays
    private static int[] nums= {10, 70, 30, 100, 40, 45, 90, 80, 85};
    private static string[] words = {"dog","at", "good", "eye", "cat", "ball", "fish"};

    public static void Main(string[] args) {

        //output
        Console.WriteLine("[{0}]", string.Join(", ", SelectionSortIntArray(nums)));
        Console.WriteLine("[{0}]", string.Join(", ", SelectionSortStringArray(words)));

    }

    //selection sort int[]
    private static int[] SelectionSortIntArray(int[] array) {

        //number of passes
        for (int passes = 0; passes < array.Length; passes++) {

            //min value trackers
            int lowestValue = array[passes];
            int lowestValueIndex = passes;

            //first unsorted term
            int firstUnsorted = array[passes];
            int firstUnsortedIndex = passes;


            //loop through each term of array
            for (int i = passes; i < array.Length; i++) {

                //is this term smaller than the minimum recorded?
                if (array[i] < lowestValue) {
                    lowestValue = array[i];
                    lowestValueIndex = i;
                }

            }

            //swap min value with first unsorted term
            array[firstUnsortedIndex] = lowestValue;
            array[lowestValueIndex] = firstUnsorted;

        }

        return array;

    }

    //selection sort string[]
    private static string[] SelectionSortStringArray(string[] array) {

        //number of passes
        for (int passes = 0; passes < array.Length; passes++) {

            //min value trackers
            string lowestValue = array[passes];
            int lowestValueIndex = passes;

            //first unsorted term
            string firstUnsorted = array[passes];
            int firstUnsortedIndex = passes;


            //loop through each term of array
            for (int i = passes; i < array.Length; i++) {

                //is this term smaller than the minimum recorded?
                if (String.Compare(array[i], lowestValue) < 0) {
                    lowestValue = array[i];
                    lowestValueIndex = i;
                }

            }

            //swap min value with first unsorted term
            array[firstUnsortedIndex] = lowestValue;
            array[lowestValueIndex] = firstUnsorted;

        }

        return array;

    }
}