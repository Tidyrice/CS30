using System;

public class InsertionSort {

    //test arrays
    private static int[] nums= {10, 70, 30, 100, 40, 45, 90, 80, 85};
    private static string[] words = {"dog","at", "good", "eye", "cat", "ball", "fish"};

    public static void Main(string[] args) {

        //output
        Console.WriteLine("[{0}]", string.Join(", ", InsertionSortIntArray(nums)));
        Console.WriteLine("[{0}]", string.Join(", ", InsertionSortStringArray(words)));

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

    //insertion sort string[]
    private static string[] InsertionSortStringArray(string[] array) {

        for (int i = 1; i < array.Length; i++) {

            //value to insert
            string term = array[i];

            //insert position
            int pos = i;

            //there are elements to the left of the insert position and the test element to the left is > value to insert
            //array[pos - 1] is the test element
            while (pos > 0 && string.Compare(term, array[pos - 1]) < 1) {
                
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
}