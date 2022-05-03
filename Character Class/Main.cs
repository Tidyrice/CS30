using System;

public class CharacterClass {

    public static void Main(string[] args) {

        //initiate first character
        Character ezreal = new Character {

            name = "Ezreal",
            phrase1 = "You belong in a museum!",
            phrase2 = "CRIMSON COBALT!!!",
            level = 18

        };

        //initiate second character
        Character brayden = new Character {

            name = "Brayden",
            phrase1 = "*cough cough sputter sputter*",
            phrase2 = "I don't SAY THAT.",
            level = -1

        };

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