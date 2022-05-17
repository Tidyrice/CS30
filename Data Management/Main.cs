using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Linq;

public class DataManagement {

    public static List<User> users;
    public static List<Song> songs;

    public static void Main(string[] args) {

        //load song library
        string json = System.IO.File.ReadAllText(@"users.json");
        songs = new JavaScriptSerializer().Deserialize<List<Song>>(json);

        //save file exists
        if (System.IO.File.Exists(@"users.json")) 
        {

            users = LoadData();
            HomeScreen();

        }

        //save file does not exist
        else 
        {

            users = new List<User>();
            HomeScreen();

        }

        /*
        order = new List<Song>();
        order = songs.OrderBy(o=>o.artist).ToList();
        */

    }

    //HOMESCREEN
    public static void HomeScreen() {
        
        int choice = -1;

        //loop until the user exits
        while (true) {

            Console.WriteLine(" ");
            Console.WriteLine("Please select a user or add a user");

            //list the users
            for (int i = 0; i < users.Count; i++) {

                Console.WriteLine("[" + i + "] " + users[i].username);

            }

            //add user option
            Console.WriteLine("[" + users.Count + "] Add user");

            //delete user option
            Console.WriteLine("[" + (users.Count + 1) + "] Delete user");

            //exit application option
            Console.WriteLine("[" + (users.Count + 2) + "] Exit");

            //take input
            choice = Int32.Parse(Console.ReadLine());

            //an existing user is selected
            if (choice >= 0 && choice < users.Count) {

                LoadUser(choice);

            }

            //user selects the "add user" option
            else if (choice == users.Count) {

                AddUser();

            }

            else if (choice == users.Count + 1) {

                DeleteUser();

            }
            
            //user selects the "exit option
            else if (choice == users.Count + 2) {

                return;

            }

        //end of while loop
        }

    }

    //load existing user
    private static void LoadUser(int userIndex) {

        //get the current user
        User currentUser = users[userIndex];

        Console.WriteLine(" ");
        Console.WriteLine("Welcome, " + currentUser.username + "!");

        //options
        while (true) {

            Console.WriteLine(" ");
            Console.WriteLine("Please select an option");

            Console.WriteLine("[1] Display all songs");
            Console.WriteLine("[2] Filter songs");
            Console.WriteLine("[3] Add songs to favourites list");
            Console.WriteLine("[4] Remove songs from favourite list");
            Console.WriteLine("[5] Display favourites list");

        }

    }

    //add user
    private static void AddUser() {

        string username = "";

        //wait until they input an actual username
        while (String.IsNullOrWhiteSpace(username) == true || username == "Add user" || username == "Delete user" || username == "Exit") {

            Console.WriteLine(" ");
            Console.WriteLine("Please provide a username for the new user");

            //get the username
            username = Console.ReadLine();

        }

        //add new user to the array
        users.Add(new User(username));

        SaveData();

    }

    private static void DeleteUser() {
        
        //are there any users to delete?
        if (users.Count == 0) {

            Console.WriteLine(" ");
            Console.WriteLine("There are no users to delete.");
            return;

        }

        int choice = -1;

        while (true) {

            Console.WriteLine(" ");
            Console.WriteLine("Please select a user to delete.");

            //list the users
            for (int i = 0; i < users.Count; i++) {

                Console.WriteLine("[" + i + "] " + users[i].username);

            }

            //take input
            choice = Int32.Parse(Console.ReadLine());

            if (choice >= 0 && choice < users.Count) {

                users.RemoveAt(choice);
                SaveData();
                return;

            }

        }

    }

    //save the users and their plants to a JSON
    private static void SaveData() {

        string json = new JavaScriptSerializer().Serialize(users);
        System.IO.File.WriteAllText(@"users.json", json);

    }

    //load the saved data
    private static List<User> LoadData() {

        string json = System.IO.File.ReadAllText(@"users.json");
        List<User> users = new JavaScriptSerializer().Deserialize<List<User>>(json);

        return users;

    }

}

public class Song {

    public string title;
    public string artist;
    public string genre;
    public int yearPublished;

    //empty default constructor
    public Song() {}

    //new song constructor
    public Song (string title, string artist, string genre, int yearPublished) {

        this.title = title;
        this.artist = artist;
        this.genre = genre;
        this.yearPublished = yearPublished;

    }

}

public class User {

    public string username;
    public List<Song> favourites;

    //empty default constructor
    public User() {}
    
    //new user constructor
    public User(string username) {

        this.username = username;

    }

    //add a song to favourites
    public void AddFavourite(Song song) {

        favourites.Add(song);

    }

    public void DisplayFavourites() {

        for (int i = 0; i < favourites.Count; i++) {

            Console.Write((i + 1) + ". " + favourites[i].title + ", by " + favourites[i].artist);

        }

    }

}