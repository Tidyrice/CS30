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
        Speak(ezreal, 2);
        Speak(brayden, 1);
        SetLevel(brayden, 68);

    }

    private static void Speak(Character character, int phraseNum) {

        if (phraseNum == 1) {

            Console.WriteLine(character.name + ": " + character.phrase1);

        } else if (phraseNum == 2) {

            Console.WriteLine(character.name + ": " + character.phrase2);

        } else {
            
            Console.WriteLine("No such phrase number");

        }
    }

    private static void SetLevel(Character character, int newLevel) {

        character.level = newLevel;

        Console.WriteLine("New level for " + character.name + ": " + character.level);
    }

}

public class Character {

    public string name;
    public string phrase1;
    public string phrase2;
    public int level;

}