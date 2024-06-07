// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

namespace NamesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();
            string input;

            Console.WriteLine("Enter names (type 'e' to end):");

            // Read names until 'e' is entered
            while (true)
            {
                input = Console.ReadLine() ?? "";
                if (input.ToLower() == "e")
                {
                    break;
                }
                names.Add(input);
            }

            // Print names in the order they were entered
            Console.WriteLine("\nNames in the order they were entered:");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            // Print names in reversed order
            Console.WriteLine("\nNames in reversed order:");
            for (int i = names.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(names[i]);
            }

            // Remove names from the list while printing
            Console.WriteLine("\nRemoving names from the list while printing:");
            while (names.Count > 0)
            {
                Console.WriteLine(names[0]);
                names.RemoveAt(0);
            }

            // Verify the list is empty
            Console.WriteLine("\nList of names after removal:");
            if (names.Count == 0)
            {
                Console.WriteLine("The list is now empty.");
            }
        }
    }
}