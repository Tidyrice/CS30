using System;

public class BackpackClass {

    public static void Main(string[] args) {

        Backpack myBackpack = new Backpack();




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

            //PROBLEM: arrays can not be resized. How do you add an item to the items array?
            Console.WriteLine("")

        } else {

            Console.WriteLine(" ");
            Console.WriteLine("The backpack is currently closed.");

        }
    }

    private static void TakeOut(Backpack backpack, string item) {

    }

}

public class Backpack {

    public bool isOpen = false;
    public string colour;
    public string size;
    public string[] items;

}