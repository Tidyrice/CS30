//BINARY SEARCH FUNCTION

public class Main {

    public static int[] sortedArray = {10, 30, 40, 45, 70, 80, 85, 90, 100};

    public static void main(String[] args) {

        System.out.println(BinarySearchInt(sortedArray, 90));

    }

    //binary search algorithm for integers
    private static int BinarySearchInt (int[] sortedArray, int term) {

        int lowerBound = 0;
        int upperBound = sortedArray.length - 1;
        
        //the amount of iterations to GUARANTEE finding the term in a SORTED ARRAY is logbase2(length of array)
        for (int i = 0; i < Math.ceil(Math.log(sortedArray.length) / Math.log(2)); i++) {

            //middleterm of the array in the bounds
            int middleTermIndex = (int) Math.floor((upperBound + lowerBound) / 2);
            int middleTerm = sortedArray[middleTermIndex];

            //is the array's middle term the one we're trying to find?
            if (middleTerm == term)
                return middleTermIndex;

            //the array's middle term is LARGER than the term in question (term is in bottom half of array)
            if (middleTerm > term) {
                upperBound = middleTermIndex - 1;
                continue;
            } 

            //the array's middle term is SMALLER than the term in question (term is in top half of array)
            if (middleTerm < term) {
                lowerBound = middleTermIndex + 1;
                continue;
            }
        }

        //specified term is not present in array OR array is unsorted
        return -1;

    }

    //binary search algorithm for strings
    //private static int BinarySearchString (String[] sortedArray, String term) {}
}