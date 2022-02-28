//*****TO RUN THIS PROGRAM, OPEN A POWER SHELL WINDOW IN THE FOLDER THIS FILE IS LOCATED IN.*****
//THEN, RUN THE COMMAND (excluding the quotation marks): "java main.java"

//dependecies
import java.util.*;
import java.io.*;

//STUDENT GRADES ASSIGNMENT
public class Main {

    //minimum and maximum grades allowed
    public static int minimumGrade = 0;
    public static int maximumGrade = 100;

    //global array with grades (uninitialized)
    private static int[] studentGrades;

    public static void main(String[] args) {

        //initialize the global array to hold 50 values
        studentGrades = new int[50];

        //random number generator to populate the studentGrades array
        for (int i = 0; i < studentGrades.length; i++) {
            studentGrades[i] = (int) Math.floor(Math.random() * maximumGrade + 1);
        }

        //Scanner to get input
        Scanner input = new Scanner(System.in);

        //list the menu and record the user input
        int option = WhichOption(input);

        //keep executing until the user inputs 5 (EXIT)
        while (option != 5) {

            //dumbcheck
            while (option < 1 || option > 5) {
                System.out.println("Invalid option!");
                option = WhichOption(input);
            }

            //execute code based on what the user chose
            switch (option) {

                case 1: //DISPLAY ALL GRADES
                    System.out.println(" ");
                    System.out.println("Student Grades:");
                    for (int i = 0; i < studentGrades.length; i++) {
                        System.out.println(studentGrades[i] + "%");
                    }
                    System.out.println(" ");
                    break;

                case 2: //RANDOMIZE GRADES

                    for (int i = 0; i < studentGrades.length; i++) {
                        studentGrades[i] = (int) Math.floor(Math.random() * maximumGrade + 1);
                    }
                    System.out.println(" ");
                    System.out.println("Grades Randomized.");
                    System.out.println(" ");
                    break;

                case 3: //STATS
                    System.out.println(" ");
                    System.out.println("STATS:");
                    System.out.println("Highest Grade: " + HighestGrade() + "%");
                    System.out.println("Lowest Grade: " + LowestGrade() + "%");
                    System.out.println("Average Grade: " + AverageGrade() + "%");
                    System.out.println(" ");
                    break;

                case 4: //COUNT HONOURS
                    System.out.println(" ");
                    System.out.println("Honours: " + CountHonours());
                    System.out.println("Honours with Distinction: " + CountHonoursWithDistinction());
                    System.out.println(" ");
                    break;

                case 5: //EXIT
                    return;
            }

            //list the menu and record the user input
            option = WhichOption(input);
        }
    }

    private static int WhichOption(Scanner input) {

        //random nickname or list all nicknames?
        System.out.println("Main Menu:");
        System.out.println("  [1] Display All Grades");
        System.out.println("  [2] Randomize Grades");
        System.out.println("  [3] Stats");
        System.out.println("  [4] Count Honours");
        System.out.println("  [5] Exit");

        int option = input.nextInt();
        return option;

    }

    private static int HighestGrade() {

        int highestGrade = minimumGrade;

        for (int i = 0; i < studentGrades.length; i++) {
            //if there is a grade higher than the current highest grade, replace the variable with the new highest grade
            if (studentGrades[i] > highestGrade)
                highestGrade = studentGrades[i];
        }

        return highestGrade;

    }

    private static int LowestGrade() {

        int lowestGrade = maximumGrade;

        for (int i = 0; i < studentGrades.length; i++) {
            //if there is a grade lower than the current lowest grade, replace the variable with the new lowest grade
            if (studentGrades[i] < lowestGrade)
                lowestGrade = studentGrades[i];
        }

        return lowestGrade;

    }

    private static int AverageGrade() {

        int sumOfGrades = 0;

        for (int i = 0; i < studentGrades.length; i++) {
            //add up all the grades
            sumOfGrades += studentGrades[i];
        }

        //divide the sum by the total number of terms
        int averageGrade = sumOfGrades / studentGrades.length;

        return averageGrade;

    }

    private static int CountHonours() {

        int numberOfHonours = 0;

        for (int i = 0; i < studentGrades.length; i++) {
            //if there is a grade above or equal to 80, but below 90, add a count to the numberOfHonours variable
            if (studentGrades[i] >= 80 && studentGrades[i] < 90)
                numberOfHonours++;
        }

        return numberOfHonours;
    }

    private static int CountHonoursWithDistinction() {

        int numberOfDistinctions = 0;

        for (int i = 0; i < studentGrades.length; i++) {
            //if there is a grade above or equal to 90, add a count to the numberOfDistinctions variable
            if (studentGrades[i] >= 90)
                numberOfDistinctions++;
        }

        return numberOfDistinctions;
    }


}