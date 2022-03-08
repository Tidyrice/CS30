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

    //selection sort string[]
    private static string[] SelectionSortStringArray(string[] array) {

        //number of passes
        for (int fillSlot = 0; fillSlot < array.Length - 1; fillSlot++) {

            //min value tracker
            int lowestValueIndex = fillSlot;

            //loop through each term of array
            for (int i = fillSlot + 1; i < array.Length; i++) {

                //is this term smaller than the minimum recorded?
                if (String.Compare(array[i], array[lowestValueIndex]) < 0) {
                    lowestValueIndex = i;
                }

            }

            //swap min value with first unsorted term
            string temp = array[fillSlot];
            array[fillSlot] = array[lowestValueIndex];
            array[lowestValueIndex] = temp;

        }

        return array;

    }
}