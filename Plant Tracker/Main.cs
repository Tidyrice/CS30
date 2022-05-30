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
            Console.WriteLine("It is " + DateTime.Now.ToString("f"));
            Console.WriteLine("Please select a user or add a user.");

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

            //user selects the "delete user" option
            else if (choice == users.Count + 1) {

                DeleteUser();

            }
            
            //user selects the "exit" option
            else if (choice == users.Count + 2) {

                return;

            }

        //end of while loop
        }

    }

    //load existing user
    private static void LoadUser(int userIndex) {

        //get the current user
        User user = users[userIndex];

        Console.WriteLine(" ");
        Console.WriteLine("Welcome, " + user.username + "!");

        //login
        Console.WriteLine("Please enter your password");
        string password = Console.ReadLine();

        //verification
        if (password != user.password) {

            Console.WriteLine(" ");
            Console.WriteLine("Incorrect password!");
            return;

        }

        Console.WriteLine(" ");
        Console.WriteLine("Verification successful.");

        //options
        while (true) {

            Console.WriteLine(" ");
            Console.WriteLine("Please select a plant or add a new plant");

            //list the user's plants
            for (int i = 0; i < user.plants.Count; i++) {

                Console.WriteLine("[" + i + "] " + user.plants[i].name);

            }

            //add user option
            Console.WriteLine("[" + user.plants.Count + "] Add plant");

            //delete user option
            Console.WriteLine("[" + (user.plants.Count + 1) + "] Delete plant");

            //logout
            Console.WriteLine("[" + (user.plants.Count + 2) + "] Logout");

            //take input
            int choice = Int32.Parse(Console.ReadLine());

            //an existing plant is selected
            if (choice >= 0 && choice < user.plants.Count) {



            }

            //user selects the "add plant" option
            else if (choice == user.plants.Count) {



            }

            //user selects the "delete plant" option
            else if (choice == user.plants.Count + 1) {



            }
            
            //user selects the "logout" option
            else if (choice == user.plants.Count + 2) {

                return;

            }

        //end of while loop
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

        string password = "";

        //wait until they input an actual password
        while (String.IsNullOrWhiteSpace(password) == true) {

            Console.WriteLine(" ");
            Console.WriteLine("Please provide a password for " + username);

            //get the username
            password = Console.ReadLine();

        }


        //add new user to the array
        users.Add(new User(username, password));

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

                Console.WriteLine(" ");
                Console.WriteLine("User deleted.");

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

public class Plant {

    public string name;
    public string type;
    public DateTime datePlanted;
    public DateTime lastWatered;
    public DateTime lastFertilized;
    public List<Journal> journal;

    //empty default constructor
    public Plant() {}

    //creating new plant constructor
    public Plant(string name, string type) {

        this.name = name;
        this.type = type;
        datePlanted = DateTime.Now;
        journal = new List<Journal>();

    }

    //list the plant details
    public void PlantDetails() {

        Console.WriteLine(" ");
        Console.WriteLine(name + " - " + type + " plant"); //name
        Console.WriteLine("Date planted: " + datePlanted.ToString("D")); //date planted
        Console.WriteLine("Last watered: " + lastWatered.ToString("f")); //last watered
        Console.WriteLine("Last fertilized: " + lastFertilized.ToString("f")); //last fertilized
        Console.WriteLine("Number of journal entries: " + journal.Count); //number of journal entries
        Console.WriteLine("Last journal entry: " + journal[journal.Count - 1].date.ToString("D")); //date of last journal entry

    }

    //water plant
    public void WaterPlant() {

        lastWatered = DateTime.Now;
        Console.WriteLine(" ");
        Console.WriteLine("Watering time recorded.");

    }

    //fertilize plant
    public void FertilizePlant() {

        lastFertilized = DateTime.Now;
        Console.WriteLine(" ");
        Console.WriteLine("Fertilizing time recorded.");

    }

    //new journal entry
    public void NewJournalEntry() {

        Console.WriteLine(" ");
        Console.WriteLine("Please begin typing your new journal entry:");

        //collect user input
        string content = Console.ReadLine();

        journal.Add(new Journal(content));
        Console.WriteLine("Entry saved.");

    }

    //delete journal entry
    public void DeleteJournalEntry() {

    }

    //view journal entries
    public void ViewJournalEntries() {

    }

}

public class Journal {

    public DateTime date;
    public string content;

    //empty default constructor
    public Journal() {}

    //creating new journal entry constructor
    public Journal(string content) {

        date = DateTime.Now;
        this.content = content;

    }

}

public class User {

    public string username;
    public string password;
    public List<Plant> plants;

    //empty default constructor
    public User() {}
    
    //new user constructor
    public User(string username, string password) {

        this.username = username;
        this.password = password;
        plants = new List<Plant>();

    }

    //add a plant
    public void NewPlant(Plant plant) {

        plants.Add(plant);

    }

}