//*****TO RUN THIS PROGRAM, OPEN A POWER SHELL WINDOW IN THE FOLDER THIS FILE IS LOCATED IN.*****
//THEN, RUN THE COMMAND (excluding the quotation marks): "java main.java"

//dependecies
import java.util.*;
import java.io.*;

//NICKNAME GENERATOR
public class Main {

    //global array with nickanmes
    private static String[] nicknames = {"The Shadow", "Babe", "Honey", "Baby Bruiser", "Sexy Dog", "Lame Goldfish", "Coolboy", "Major", "Grandmother", "Papa", "Mama", "Smurf", "Alpha", "Breadmaker", "Bully", "Cereal Killer", "Nutjob", "Turnip King", "Guillotine", "Nerd", "Explicit Substance Dealer", "Cowboy"};

    public static void main(String[] args) {

        //Scanner to get input
        Scanner input = new Scanner(System.in);

        //get first name
        System.out.print("First name: ");
        String firstName = input.next();

        //get last name
        System.out.print("Last name: ");
        String lastName = input.next();

        int option = WhichOption(input);

        //dumbcheck
        while (option != 1 && option != 2) {
            System.out.println("Invalid option!");
            option = WhichOption(input);
        }

        if (option == 1) {
            Random(firstName, lastName);
        } else {
            ListAll(firstName, lastName);
        }
    }

    private static void Random(String firstName, String lastName) {

        //random number generator
        int index = (int) Math.floor(Math.random() * nicknames.length);

        //put the names together
        String nickname = firstName + " \"" + nicknames[index] + "\" " + lastName;

        //output
        System.out.println("Your random nickname:");
        System.out.println(nickname);

    }

    private static void ListAll(String firstName, String lastName) {

        System.out.println("All nicknames:");

        //loop to list all nicknames
        for (int i = 0; i < nicknames.length ; i++) {
            System.out.println(firstName + " \"" + nicknames[i] + "\" " + lastName);
        }

    }

    private static int WhichOption(Scanner input) {

        //random nickname or list all nicknames?
        System.out.println("Please choose an option:");
        System.out.println("(1) Random nickname");
        System.out.println("(2) List all nicknames");

        int option = input.nextInt();
        return option;

    }
}