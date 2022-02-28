//*****TO RUN THIS PROGRAM, OPEN A POWER SHELL WINDOW IN THE FOLDER THIS FILE IS LOCATED IN.*****
//THEN, RUN THE COMMAND (excluding the quotation marks): ".\\Main.exe"

//dependecies
using System;

//STUDENT GRADES ASSIGNMENT
public class StudentGrades {

    //minimum and maximum grades allowed
    public static int minimumGrade = 0;
    public static int maximumGrade = 100;

    //global array with grades (uninitialized)
    private static int[] studentGrades;

    public static void Main(string[] args) {

        //initialize the global array to hold 50 values
        studentGrades = new int[50];

        //random
        Random random = new Random();

        //random number generator to populate the studentGrades array
        for (int i = 0; i < studentGrades.Length; i++) {
            studentGrades[i] = (int) Math.Floor( (decimal) random.Next(0, maximumGrade + 1));
        }

        //list the menu and record the user input
        int option = WhichOption();

        //keep executing until the user inputs 5 (EXIT)
        while (option != 5) {

            //dumbcheck
            while (option < 1 || option > 5) {
                Console.WriteLine("Invalid option!");
                option = WhichOption();

            }

            //execute code based on what the user chose
            switch (option) {

                case 1: //DISPLAY ALL GRADES
                    Console.WriteLine(" ");
                    Console.WriteLine("Student Grades:");
                    for (int i = 0; i < studentGrades.Length; i++) {
                        Console.WriteLine(studentGrades[i] + "%");
                    }
                    Console.WriteLine(" ");
                    break;

                case 2: //RANDOMIZE GRADES

                    for (int i = 0; i < studentGrades.Length; i++) {
                        studentGrades[i] = (int) Math.Floor( (decimal) random.Next(0, maximumGrade + 1));
                    }
                    Console.WriteLine(" ");
                    Console.WriteLine("Grades Randomized.");
                    Console.WriteLine(" ");
                    break;

                case 3: //STATS
                    Console.WriteLine(" ");
                    Console.WriteLine("STATS:");
                    Console.WriteLine("Highest Grade: " + HighestGrade() + "%");
                    Console.WriteLine("Lowest Grade: " + LowestGrade() + "%");
                    Console.WriteLine("Average Grade: " + AverageGrade() + "%");
                    Console.WriteLine(" ");
                    break;

                case 4: //COUNT HONOURS
                    Console.WriteLine(" ");
                    Console.WriteLine("Honours: " + CountHonours());
                    Console.WriteLine("Honours with Distinction: " + CountHonoursWithDistinction());
                    Console.WriteLine(" ");
                    break;

                case 5: //EXIT
                    return;
            }

            //list the menu and record the user input
            option = WhichOption();
        }
    }

    private static int WhichOption() {

        //random nickname or list all nicknames?
        Console.WriteLine("Main Menu:");
        Console.WriteLine("  [1] Display All Grades");
        Console.WriteLine("  [2] Randomize Grades");
        Console.WriteLine("  [3] Stats");
        Console.WriteLine("  [4] Count Honours");
        Console.WriteLine("  [5] Exit");

        int option = Int32.Parse(Console.ReadLine());
        return option;

    }

    private static int HighestGrade() {

        int highestGrade = minimumGrade;

        for (int i = 0; i < studentGrades.Length; i++) {
            //if there is a grade higher than the current highest grade, replace the variable with the new highest grade
            if (studentGrades[i] > highestGrade)
                highestGrade = studentGrades[i];
        }

        return highestGrade;

    }

    private static int LowestGrade() {

        int lowestGrade = maximumGrade;

        for (int i = 0; i < studentGrades.Length; i++) {
            //if there is a grade lower than the current lowest grade, replace the variable with the new lowest grade
            if (studentGrades[i] < lowestGrade)
                lowestGrade = studentGrades[i];
        }

        return lowestGrade;

    }

    private static int AverageGrade() {

        int sumOfGrades = 0;

        for (int i = 0; i < studentGrades.Length; i++) {
            //add up all the grades
            sumOfGrades += studentGrades[i];
        }

        //divide the sum by the total number of terms
        int averageGrade = sumOfGrades / studentGrades.Length;

        return averageGrade;

    }

    private static int CountHonours() {

        int numberOfHonours = 0;

        for (int i = 0; i < studentGrades.Length; i++) {
            //if there is a grade above or equal to 80, but below 90, add a count to the numberOfHonours variable
            if (studentGrades[i] >= 80 && studentGrades[i] < 90)
                numberOfHonours++;
        }

        return numberOfHonours;
    }

    private static int CountHonoursWithDistinction() {

        int numberOfDistinctions = 0;

        for (int i = 0; i < studentGrades.Length; i++) {
            //if there is a grade above or equal to 90, add a count to the numberOfDistinctions variable
            if (studentGrades[i] >= 90)
                numberOfDistinctions++;
        }

        return numberOfDistinctions;
    }


}