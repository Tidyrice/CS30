using System;
using System.Diagnostics;
using System.Web.Script.Serialization;

public class PlantTracker {

    public static User[] users;

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

            users = new User[0];
            HomeScreen();

        }

        
    }

    //HOMESCREEN
    public static void HomeScreen() {
        
        int choice = -1;

        //if the choice number does not match any of the options, repeat
        while (choice < 0 || choice > users.Length + 1) {

            Console.WriteLine(" ");
            Console.WriteLine("Please select a user or add a user");

            //list the users
            for (int i = 0; i < users.Length; i++) {

                Console.WriteLine("[" + i + "] " + users[i].username);

            }

            //add user option
            Console.WriteLine("[" + users.Length + "] Add user");

            //exit application option
            Console.WriteLine("[" + (users.Length + 1) + "] Exit");

            //take input
            choice = Int32.Parse(Console.ReadLine());

            //user selects the "add user" option
            if (choice == users.Length) {

                AddUser();

            } 
            
            //user selects the "exit option
            else if (choice == users.Length + 1) {

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
        while (username == "") {

            Console.WriteLine(" ");
            Console.WriteLine("Please provide a username for the new user");

            //get the username
            username = Console.ReadLine();

            //*****BONUS: MAKE IT ILLEGAL TO HAVE DUPLICATE USERS*****

        }

        //resize users array
        Array.Resize(ref users, users.Length + 1);

        //put new user into last position
        users[users.Length - 1] = new User {

            username = username

        };

        SaveData();
        HomeScreen();

    }

    //save the users and their plants to a JSON
    private static void SaveData() {

        string json = new JavaScriptSerializer().Serialize(users);
        System.IO.File.WriteAllText(@"users.json", json);

    }

    //load the saved data
    private static User[] LoadData() {

        string json = System.IO.File.ReadAllText(@"users.json");
        User[] users = new JavaScriptSerializer().Deserialize<User[]>(json);

        return users;

    }

}

public class Plant {

    public string name;
    public DateTime datePlanted;
    public DateTime lastWatered;
    public DateTime lastFertilized;
    public string[][] journal;

}

public class User {

    public string username;
    public Plant[] plants;

}