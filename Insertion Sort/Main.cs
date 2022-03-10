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

        for (int comparingTerm = 1; comparingTerm < array.Length; comparingTerm++) {

            //is the final term smaller than the initial term? (terms out of order)
            if (array[comparingTerm] < array[comparingTerm - 1]) {

                //swap the terms (array[comparingterm] is now in position array[comparingterm - 1]")
                int temp = array[comparingTerm];
                array[comparingTerm] = array[comparingTerm + 1];
                array[comparingTerm + 1] = temp;

                //check with all previous "sorted" elements
                for (int i = comparingTerm - 1; i > -1; i--) {

                    //are the terms out of order?
                    if (array[i] < array[i - 1]) {

                        //swap the terms
                        temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;

                    } else {

                        //if sorted, exit out of loop
                        break;

                    }
                    
                }

            }
            
        }

        return array;

    }

    //insertion sort string[]
    private static string[] InsertionSortStringArray(string[] array) {



        return array;

    }
}