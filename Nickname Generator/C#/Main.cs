//*****TO RUN THIS PROGRAM, OPEN A POWER SHELL WINDOW IN THE FOLDER THIS FILE IS LOCATED IN.*****
//THEN, RUN THE COMMAND (excluding the quotation marks): ".\\Main.exe"

//dependecies
using System;

//NICKNAME GENERATOR
public class NicknameGenerator {

    //global array with nickanmes
    private static string[] nicknames = {"The Shadow", "Babe", "Honey", "Baby Bruiser", "Sexy Dog", "Lame Goldfish", "Coolboy", "Major", "Grandmother", "Papa", "Mama", "Smurf", "Alpha", "Breadmaker", "Bully", "Cereal Killer", "Nutjob", "Turnip King", "Guillotine", "Nerd", "Explicit Substance Dealer", "Cowboy"};

    public static void Main(string[] args) {

        //get first name
        Console.WriteLine("First name: ");
        string firstName = Console.ReadLine();

        //get last name
        Console.WriteLine("Last name: ");
        string lastName = Console.ReadLine();

        int option = WhichOption();

        //dumbcheck
        while (option != 1 && option != 2) {
            Console.WriteLine("Invalid option!");
            option = WhichOption();
        }

        if (option == 1) {
            Random(firstName, lastName);
        } else {
            ListAll(firstName, lastName);
        }
    }

    private static void Random(string firstName, string lastName) {

        //random number generator
        Random random = new Random();
        int index = (int) Math.Floor( (decimal) random.Next(0, nicknames.Length));

        //put the names together
        string nickname = firstName + " \"" + nicknames[index] + "\" " + lastName;

        //output
        Console.WriteLine("Your random nickname:");
        Console.WriteLine(nickname);

    }

    private static void ListAll(string firstName, string lastName) {

        Console.WriteLine("All nicknames:");

        //loop to list all nicknames
        for (int i = 0; i < nicknames.Length ; i++) {
            Console.WriteLine(firstName + " \"" + nicknames[i] + "\" " + lastName);
        }

    }

    private static int WhichOption() {

        //random nickname or list all nicknames?
        Console.WriteLine("Please choose an option:");
        Console.WriteLine("(1) Random nickname");
        Console.WriteLine("(2) List all nicknames");

        int option = Int32.Parse(Console.ReadLine());
        return option;

    }
}