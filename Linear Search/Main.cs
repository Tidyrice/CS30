using System;

//LINEAR SEARCH ALGORITHMS
class LinearSearch {

    //test arrays
    private static int[] sortedIntArray = {10, 30, 40, 45, 70, 80, 85, 90, 100};
    private static string[] sortedStringArray = {"at", "ball", "cat", "dog", "eye", "fish", "good"};
    private static int[] unsortedIntArray = {30, 20, 70, 40, 50, 100, 90};

    public static void Main(string[] args) {

        //test cases
        Console.WriteLine(LinearSearchInt(sortedIntArray, 100));
        Console.WriteLine(LinearSearchInt(sortedIntArray, 75));
        Console.WriteLine(LinearSearchString(sortedStringArray, "fish"));
        Console.WriteLine(LinearSearchString(sortedStringArray, "at"));
        Console.WriteLine(LinearSearchInt(unsortedIntArray, 70));

    }

    //linear search algorithm for ints
    private static int LinearSearchInt (int[] array, int term) {

        //loop through all the terms of the array
        for (int i = 0; i < array.Length; i++) {
            if (array[i] == term)
                return i;
        }

        //specified term is not present in array
        return -1;

    }

    //linear search algorithm for strings
    private static int LinearSearchString (string[] array, string term) {

        //loop through all the terms of the array
        for (int i = 0; i < array.Length; i++) {
            if (array[i] == term)
                return i;
        }

        //specified term is not present in array
        return -1;

    }

}