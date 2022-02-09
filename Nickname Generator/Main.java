//dependecies
import java.util.*;
import java.io.*;

//NICKNAME GENERATOR
public class Main {

    public static void main(String[] args) {

        //array with nickanmes
        String[] nicknames = {"The Shadow", "Babe", "Honey", "Baby Bruiser", "Sexy Dog", "Lame Goldfish", "Coolboy", "Major", "Grandmother", "Papa", "Mama", "Smurf", "Alpha", "Breadmaker", "Bully", "Cereal Killer", "Nutjob", "Turnip King", "Guillotine", "Nerd", "Explicit Substance Dealer", "Cowboy"};

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
    }

    private static void Random() {

    }

    private static void ListAll() {

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