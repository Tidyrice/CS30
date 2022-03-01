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
    private static int[] SelectionSortIntArray(int[] intArray) {

        //put into list
        ArrayList unsortedList = nums.ToList();
        ArrayList sortedList = new ArrayList();



    }

    //selection sort string[]

    }
}