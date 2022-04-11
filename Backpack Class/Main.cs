using System;

public class BackpackClass {

    public static void Main(string[] args) {

        //small blue backpack
        Backpack smallBlue = new Backpack() {

            colour = "blue",
            size = "small"

        };

        //medium red backpack
        Backpack mediumRed = new Backpack() {

            colour = "red",
            size = "medium"

        };

        //large green backpack
        Backpack largeGreen = new Backpack() {

            colour = "green",
            size = "large"

        };

        OpenBag(smallBlue);
        PutIn(smallBlue, "lunch");
        PutIn(smallBlue, "jacket");
        CloseBag(smallBlue);
        OpenBag(smallBlue);
        TakeOut(smallBlue, "jacket");
        CloseBag(smallBlue);




    }

    private static void OpenBag(Backpack backpack) {

        backpack.isOpen = true;
        Console.WriteLine(" ");
        Console.WriteLine("The backpack has been opened.");

    }

    private static void CloseBag(Backpack backpack) {

        backpack.isOpen = false;
        Console.WriteLine(" ");
        Console.WriteLine("The backpack has been closed.");

    }

    private static void PutIn(Backpack backpack, string item) {
        
        if (backpack.isOpen == true) {

            //resize the array
            Array.Resize(ref backpack.items, backpack.items.Length + 1);
            backpack.items[backpack.items.Length - 1] = item;

            Console.WriteLine(" ");
            Console.WriteLine("Item has been put in. Current items: " + string.Join(", ", backpack.items));


        } else {

            Console.WriteLine(" ");
            Console.WriteLine("The backpack is currently closed.");

        }
    }

    private static void TakeOut(Backpack backpack, string item) {
        
        if (backpack.isOpen == true) {

            //resize the array
            Array.Resize(ref backpack.items, backpack.items.Length - 1);

            Console.WriteLine(" ");
            Console.WriteLine("Item has been removed. Current items: " + string.Join(", ", backpack.items));


        } else {

            Console.WriteLine(" ");
            Console.WriteLine("The backpack is currently closed.");

        }
    }

}

public class Backpack {

    public bool isOpen = false;
    public string colour;
    public string size;
    public string[] items = new string[0];

}