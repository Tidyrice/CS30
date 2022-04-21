using System;
using System.Diagnostics;
using System.Web.Script.Serialization;

public class PlantTracker {

    public static User[] users;

    public static void Main(string[] args) {

        //save file exists
        if (System.IO.File.Exists(@"data/users.json")) 
        {

        }

        //save file does not exist
        else 
        {
            users = new User[0];
            HomeScreen();
        }

        // Load data into array
        //users = LoadData();
        
    }

    //HOMESCREEN
    public static void HomeScreen() {
        
        int choice = -1;

        //if the choice number does not match any of the options, repeat
        while (choice < 0 || choice > users.Length) {

            Console.WriteLine(" ");
            Console.WriteLine("Please select a user or add a user");

            //list the users
            for (int i = 0; i < users.Length; i++) {

                Console.WriteLine("[" + i + "] " + users[i].username);

            }

            //add user option
            Console.WriteLine("[" + users.Length + "] Add user");

            //take input
            choice = Int32.Parse(Console.ReadLine());

            //user selects the "add user" option
            if (choice == users.Length) {

                Console.WriteLine(" ");
                Console.WriteLine("Please provide a username for the new user");

                //get the username
                string username = Console.ReadLine();

                //resize users array
                Array.Resize(ref users, users.Length + 1);

                //put new user into last position
                users[users.Length - 1] = new User {

                    username = username

                };

            }

        //end of while loop
        }

    }

    //save the users and their plants to a JSON
    public static void SaveData(User[] users) {

        string json = new JavaScriptSerializer().Serialize(users);
        System.IO.File.WriteAllText(@"data/users.json", json);

    }

    //load the saved data
    public static User[] LoadData() {

        string json = System.IO.File.ReadAllText(@"data/users.json");
        User[] users = new JavaScriptSerializer().Deserialize<User[]>(json);

        return users;

    }

}

public class Plant {

    public string user;
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