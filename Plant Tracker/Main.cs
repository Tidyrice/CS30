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

        //loop until the user exits
        while (true) {

            Console.WriteLine(" ");
            Console.WriteLine("Welcome! It is " + DateTime.Now.ToString());
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

                PlantScreen(choice);

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
    private static void PlantScreen(int userIndex) {

        //get the current user
        User currentUser = users[userIndex];

        Console.WriteLine(" ");
        Console.WriteLine("Welcome, " + currentUser.username);

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

            //*****BONUS: MAKE IT ILLEGAL TO HAVE DUPLICATE USERS*****

        }

        //add new user to the array
        users.Add(new User(username));

        SaveData();

    }

    private static void DeleteUser() {
        
        //COMPLETE THIS SECTION

        SaveData();

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

    //empty default constructor
    public Plant() {}

    //creating plant constructor
    public Plant(string Name) {

        name = Name;
        datePlanted = DateTime.Now;

    }

    //water plant
    public void WaterPlant() {

        lastWatered = DateTime.Now;

    }

    //fertilize plant
    public void FertilizePlant() {

        lastFertilized = DateTime.Now;

    }

    //new journal entry

    //delete journal entry

    //view journal entries

}

public class User {

    public string username;
    public List<Plant> plants;

    //empty default constructor
    public User() {}
    
    //new user constructor
    public User(string name) {

        username = name;

    }

}