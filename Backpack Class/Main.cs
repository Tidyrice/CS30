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

        //requests
        smallBlue.OpenBag();
        smallBlue.PutIn("lunch");
        smallBlue.PutIn("jacket");
        smallBlue.CloseBag();
        smallBlue.OpenBag();
        smallBlue.TakeOut("jacket");
        smallBlue.CloseBag();

    }

}

public class Backpack {

    public bool isOpen = false;
    public string colour;
    public string size;
    public string[] items = new string[0];

    public void OpenBag() {

        isOpen = true;
        Console.WriteLine(" ");
        Console.WriteLine("The backpack has been opened.");

    }

    public void CloseBag() {

        isOpen = false;
        Console.WriteLine(" ");
        Console.WriteLine("The backpack has been closed.");

    }

    public void PutIn(string item) {
        
        if (isOpen == true) {

            //resize the array
            Array.Resize(ref items, items.Length + 1);
            items[items.Length - 1] = item;

            Console.WriteLine(" ");
            Console.WriteLine("Item has been put in. Current items: " + string.Join(", ", items));


        } else {

            Console.WriteLine(" ");
            Console.WriteLine("The backpack is currently closed.");

        }
    }

    public void TakeOut(string item) {
        
        if (isOpen == true) {

            //resize the array
            Array.Resize(ref items, items.Length - 1);

            Console.WriteLine(" ");
            Console.WriteLine("Item has been removed. Current items: " + string.Join(", ", items));


        } else {

            Console.WriteLine(" ");
            Console.WriteLine("The backpack is currently closed.");

        }
    }

}