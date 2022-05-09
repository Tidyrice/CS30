using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Script.Serialization;

public class PlantTracker {

    public static List<User> users;

    public static void Main(string[] args) {

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

        
    }

    //HOMESCREEN
    public static void HomeScreen() {
        
        int choice = -1;

        //if the choice number does not match any of the options, repeat
        while (choice < 0 || choice > users.Count + 1) {

            Console.WriteLine(" ");
            Console.WriteLine("Please select a user or add a user");

            //list the users
            for (int i = 0; i < users.Count; i++) {

                Console.WriteLine("[" + i + "] " + users[i].username);

            }

            //add user option
            Console.WriteLine("[" + users.Count + "] Add user");

            //exit application option
            Console.WriteLine("[" + (users.Count + 1) + "] Exit");

            //take input
            choice = Int32.Parse(Console.ReadLine());

            //is this a bogus input?
            if (choice < 0 || choice > users.Count + 1)
                continue;

            //user selects the "add user" option
            if (choice == users.Count) {

                AddUser();

            } 
            
            //user selects the "exit option
            else if (choice == users.Count + 1) {

                return;

            }

            //an existing user is selected
            else {

                PlantScreen(choice);

            }

        //end of while loop
        }

    }

    //load existing user
    private static void PlantScreen(int userIndex) {

        //get the current user
        User currentUser = users[userIndex];

        

    }

    //add user
    private static void AddUser() {

        string username = "";

        //wait until they input an actual username
        while (String.IsNullOrWhiteSpace(username) == true) {

            Console.WriteLine(" ");
            Console.WriteLine("Please provide a username for the new user");

            //get the username
            username = Console.ReadLine();

            //*****BONUS: MAKE IT ILLEGAL TO HAVE DUPLICATE USERS*****

        }

        //add new user to the array
        users.Add(new User(username));

        SaveData();
        HomeScreen();

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

public class Plant {

    public string name;
    public DateTime datePlanted;
    public DateTime lastWatered;
    public DateTime lastFertilized;
    public string[][] journal;

    //constructor
    public Plant() {

    }

}

public class User {

    public string username;
    public Plant[] plants;

    //empty default constructor
    public User() {}
    
    //overloaded constructor
    public User(string name) {

        username = name;

    }

}