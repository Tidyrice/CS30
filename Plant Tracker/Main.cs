using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class PlantTracker {

    public static void Main(string[] args) {

        // Load data into array
        User[] users = LoadData();


    }

    //save the users and their plants to a JSON
    public static void SaveData(User[] users) {

        string json = JsonSerializer.Serialize(users);
        File.WriteAllText(@"data/users.json", json);

    }

    //load the saved data
    public static User[] LoadData() {

        string json = File.ReadAllText(@"data/users.json");
        User[] users = JsonSerializer.Deserialize<User[]>(json);

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