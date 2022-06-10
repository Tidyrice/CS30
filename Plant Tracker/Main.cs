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

        SaveData();
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

        UserMenu(user);

    }

    //options menu
    private static void UserMenu(User user) {

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

                PlantMenu(user, choice);

            }

            //user selects the "add plant" option
            else if (choice == user.plants.Count) {

                AddPlant(user);

            }

            //user selects the "delete plant" option
            else if (choice == user.plants.Count + 1) {

                DeletePlant(user);

            }
            
            //user selects the "logout" option
            else if (choice == user.plants.Count + 2) {

                return;

            }
 
        SaveData();
        //end of while loop
        }

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

        }

        string password = "";

        //wait until they input an actual password
        while (String.IsNullOrWhiteSpace(password) == true) {

            Console.WriteLine(" ");
            Console.WriteLine("Please provide a password for " + username);

            //get the password
            password = Console.ReadLine();

        }


        //add new user to the array
        users.Add(new User(username, password));

    }

    //delete user
    private static void DeleteUser() {
        
        //are there any users to delete?
        if (users.Count == 0) {

            Console.WriteLine(" ");
            Console.WriteLine("There are no users to delete.");
            return;

        }

        while (true) {

            Console.WriteLine(" ");
            Console.WriteLine("Please select a user to delete.");

            //list the users
            for (int i = 0; i < users.Count; i++) {

                Console.WriteLine("[" + i + "] " + users[i].username);

            }

            //take input
            int choice = Int32.Parse(Console.ReadLine());

            if (choice >= 0 && choice < users.Count) {

                Console.WriteLine(" ");
                Console.WriteLine("User deleted.");

                users.RemoveAt(choice);
                return;

            }

        }

    }

    //add plant
    private static void AddPlant(User user) {

        string name = "";

        //wait until they input a name
        while (String.IsNullOrWhiteSpace(name) == true) {

            Console.WriteLine(" ");
            Console.WriteLine("Please provide a name for the new plant");

            //get the name
            name = Console.ReadLine();

        }

        string type = "";

        //wait until they input an actual type
        while (String.IsNullOrWhiteSpace(type) == true) {

            Console.WriteLine(" ");
            Console.WriteLine("What type of plant is " + name + "?");

            //get the type
            type = Console.ReadLine();

        }


        //add the plant to the user
        user.NewPlant(new Plant(name, type));

    }

    //delete user
    private static void DeletePlant(User user) {
        
        //are there any users to delete?
        if (user.plants.Count == 0) {

            Console.WriteLine(" ");
            Console.WriteLine("There are no plants to delete.");
            return;

        }

        while (true) {

            Console.WriteLine(" ");
            Console.WriteLine("Please select a user to delete.");

            //list the plants
            for (int i = 0; i < user.plants.Count; i++) {

                Console.WriteLine("[" + i + "] " + user.plants[i].name);

            }

            //take input
            int choice = Int32.Parse(Console.ReadLine());

            if (choice >= 0 && choice < user.plants.Count) {

                Console.WriteLine(" ");
                Console.WriteLine("Plant deleted.");

                user.plants.RemoveAt(choice);
                return;

            }

        }

    }

    //plant menu
    private static void PlantMenu(User user, int plantIndex) {

        //get the current plant
        Plant plant = user.plants[plantIndex];

        //loop until the user exits
        while (true) {

            //plant details
            plant.PlantDetails();

            //options
            Console.WriteLine(" ");
            Console.WriteLine("Please select an option");
            Console.WriteLine("[0] Water the plant");
            Console.WriteLine("[1] Fertilize the plant");
            Console.WriteLine("[2] New journal entry");
            Console.WriteLine("[3] Delete journal entry");
            Console.WriteLine("[4] View journal entries");
            Console.WriteLine("[5] Back");

            //take input
            int choice = Int32.Parse(Console.ReadLine());

            switch (choice) {

                case 0:
                    plant.WaterPlant();
                    break;

                case 1:
                    plant.FertilizePlant();
                    break;

                case 2:
                    plant.NewJournalEntry();
                    break;

                case 3:
                    plant.DeleteJournalEntry();
                    break;

                case 4:
                    plant.ViewJournalEntries();
                    break;

                case 5:
                    //go back
                    return;

                default:
                    break;
            }

        SaveData();
        //end of while loop
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
    public Nullable<DateTime> lastWatered;
    public Nullable<DateTime> lastFertilized;
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

        //has the plant been watered before?
        if (lastWatered != null) {
            Console.WriteLine("Last watered: " + lastWatered.ToString()); //last watered
        } else {
            Console.WriteLine("Last watered: N/A"); 
        }


        //has the plant been fertilized before?
        if (lastFertilized != null) {
            Console.WriteLine("Last fertilized: " + lastFertilized.ToString()); //last fertilized
        } else {
            Console.WriteLine("Last fertilized: N/A");
        }

        Console.WriteLine("Number of journal entries: " + journal.Count); //number of journal entries

        //are there any journal entries?
        if (journal.Count != 0) {
            Console.WriteLine("Last journal entry: " + journal[journal.Count - 1].date.ToString("D")); //date of last journal entry
        } else {
            Console.WriteLine("Last journal entry: N/A");
        }

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

        //are there any journal entries to delete?
        if (journal.Count == 0) {

            Console.WriteLine(" ");
            Console.WriteLine("There are no journal entries to delete.");
            return;

        }

        while (true) {

            Console.WriteLine(" ");
            Console.WriteLine("Please select a journal entry to delete.");

            //list the journal entries
            for (int i = 0; i < journal.Count; i++) {

                Console.WriteLine("[" + i + "] " + journal[i].date.ToString("f"));

            }

            //take input
            int choice = Int32.Parse(Console.ReadLine());

            if (choice >= 0 && choice < journal.Count) {

                Console.WriteLine(" ");
                Console.WriteLine("Journal entry deleted.");

                journal.RemoveAt(choice);
                return;

            }

        }

    }

    //view journal entries
    public void ViewJournalEntries() {

        //are there any journal entries?
        if (journal.Count == 0) {

            Console.WriteLine(" ");
            Console.WriteLine("No journal entries to display.");
            return;

        }

        Console.WriteLine(" ");
        Console.WriteLine("Listing journal entries:");

        //list all entries (oldest --> newest)
        for (int i = 0; i < journal.Count; i++) {

            Console.WriteLine(" ");
            Console.WriteLine(journal[i].date.ToString("f"));
            Console.WriteLine(journal[i].content);

        }

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