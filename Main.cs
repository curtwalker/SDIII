using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Part1CDCollection
{
    class MainClass
    {
        private static SortedDictionary<Album, Track> albums;

        public static void Main()
		{
            albums = new SortedDictionary<Album, Track>();
            string choice;
            string alName;
            string arName;
            string trName;
            int trNumber;
            AlbumCollection _collection = new AlbumCollection();

           do 
            {
                Console.WriteLine("Enter a choice: ");
                choice = Console.ReadLine();
                
                //Menu
                switch (choice)
                { 
                    case "s":
                        _collection.Save();
                        Console.WriteLine("Collection saved successfully.");
                        break;
                    case "l":
                        _collection.Load();
                        Console.WriteLine("You have loaded these albums from file: ");
                        _collection.Display();
                        Console.WriteLine("----------------------------------------------------");
                        break;
                    case "a":
                        Console.WriteLine("Provide an Album name: ");
                        alName = Console.ReadLine();
                        Console.WriteLine("Provide an Artist name: ");
                        arName = Console.ReadLine();
                        _collection.AddAlbum(alName, arName);
                        break;
                    case "d":
                        _collection.Display();
                        break;
                    case "r":
                        Console.WriteLine("Provide the Album name that you wish to remove: ");
                        alName = Console.ReadLine();
                        Console.WriteLine("Provide the corresponding Artist name: ");
                        arName = Console.ReadLine();
                        _collection.DeleteAlbum(alName, arName);
                        break;
                    case "t":
                        Console.WriteLine("Please enter the Album name that you would like to add a track to: ");
                        alName = Console.ReadLine();
                        Console.WriteLine("Please enter the track number: ");
                        trNumber = int.Parse(Console.ReadLine());
                        Console.WriteLine("Please enter the track name: ");
                        trName = Console.ReadLine();
                        _collection.AddTrack(alName, trNumber, trName);
                        break;
                    case "v":
                        
                        break;
                }
            } 
           while (choice != "x");
	    }
    }
}

