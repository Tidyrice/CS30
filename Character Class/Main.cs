using System;

public class CharacterClass {

    public static void Main(string[] args) {

        //initiate first character
        Character ezreal = new Character("Ezreal", "You belong in a museum!", "CRIMSON COBALT!!!", 18);

        //initiate second character
        Character brayden = new Character("Brayden", "*cough cough sputter sputter*", "I don't SAY THAT.", 1);

        //requests
        ezreal.Speak(2);
        brayden.Speak(1);
        brayden.SetLevel(68);

    }

}

public class Character {

    public string name;
    public string phrase1;
    public string phrase2;
    public int level;

    //constructor
    public Character (string nameConstructor, string phrase1Constructor, string phrase2Constructor, int levelConstructor) {

        name = nameConstructor;
        phrase1 = phrase1Constructor;
        phrase2 = phrase2Constructor;
        level = levelConstructor;

    }

    public void Speak(int phraseNum) {

        if (phraseNum == 1) {

            Console.WriteLine(name + ": " + phrase1);

        } else if (phraseNum == 2) {

            Console.WriteLine(name + ": " + phrase2);

        } else {
            
            Console.WriteLine("No such phrase number");

        }

    }

    public void SetLevel(int newLevel) {

        level = newLevel;

        Console.WriteLine("New level for " + name + ": " + level);

    }

}