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

                //store the final term
                int temp = array[comparingTerm];

                //put the initial term in the final term's slot
                array[comparingTerm] = array[comparingTerm - 1];

                //check with all previous "sorted" elements
                //int i starts as the index number of the term BEFORE the initial term
                for (int i = comparingTerm - 2; i > -2; i--) {

                    //reached end of array; int temp is smallest term
                    if (i == -1) {
                        array[0] = temp;
                        break;
                    }

                    //are the terms out of order?
                    if (temp < array[i]) {

                        //bring the left term up
                        array[i + 1] = array[i];

                    } else {

                        //if sorted, replace duplpicate with term and exit out of loop
                        array[i + 1] = temp;
                        break;

                    }
                }
            }
        }

        return array;

    }

    //insertion sort string[]
    private static string[] InsertionSortStringArray(string[] array) {

        for (int comparingTerm = 1; comparingTerm < array.Length; comparingTerm++) {

            //is the final term smaller than the initial term? (terms out of order)
            if (String.Compare(array[comparingTerm], array[comparingTerm - 1]) < 0) {

                //store the final term
                string temp = array[comparingTerm];

                //put the initial term in the final term's slot
                array[comparingTerm] = array[comparingTerm - 1];

                //check with all previous "sorted" elements
                //int i starts as the index number of the term BEFORE the initial term
                for (int i = comparingTerm - 2; i > -2; i--) {

                    //reached end of array; int temp is smallest term
                    if (i == -1) {
                        array[0] = temp;
                        break;
                    }

                    //are the terms out of order?
                    if (String.Compare(temp, array[i]) < 0) {

                        //bring the left term up
                        array[i + 1] = array[i];

                    } else {

                        //if sorted, replace duplpicate with term and exit out of loop
                        array[i + 1] = temp;
                        break;

                    }
                }
            }
        }

        return array;

    }
}