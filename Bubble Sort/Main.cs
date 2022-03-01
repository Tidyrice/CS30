using System;

//BUBBLE SORT ALGORITHM
class BubbleSort {

    //test arrays
    private static int[] nums= {10, 70, 30, 100, 40, 45, 90, 80, 85};
    private static string[] words = {"dog","at", "good", "eye", "cat", "ball", "fish"};

    public static void Main(string[] args) {

        //output
        Console.WriteLine("[{0}]", string.Join(", ", BubbleSortIntArray(nums)));
        Console.WriteLine("[{0}]", string.Join(", ", BubbleSortStringArray(words)));

    }

    //bubble sort for int arrays
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

                //already sorted
                if (first < second)
                    continue;

                //not sorted, swap values
                intArray[j] = second;
                intArray[j + 1] = first;

                //a swap has occured
                swaped = true;

            }

            //no swaps occured in this pass: array is sorted
            if (!swaped)
                return intArray;

        }

        //something weird happened
        return null;

    }

    //bubble sort for string arrays
    private static string[] BubbleSortStringArray(string[] stringArray) {

        //maximum number of passes it needs
        for (int i = 0; i < stringArray.Length - 1; i++) {

            //was there a swap in this pass?
            bool swaped = false;

            //number of swaps per pass
            for (int j = 0; j < stringArray.Length - 1 - i; j++) {

                //terms to compare
                string first = stringArray[j];
                string second = stringArray[j + 1];

                //already sorted
                if (String.Compare(first, second) < 0)
                    continue;

                //not sorted, swap values
                stringArray[j] = second;
                stringArray[j + 1] = first;

                //a swap has occured
                swaped = true;

            }

            //no swaps occured in this pass: array is sorted
            if (!swaped)
                return stringArray;

        }

        //something weird happened (e.g. non-ASCII character present)
        return null;

    }
}