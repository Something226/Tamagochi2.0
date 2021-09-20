using System.Buffers;
using System;

namespace Tamagochi

{
    class Program

    {
        static void Main(string[] args)
        {
            bool named = false;
            Tamagochi tama = new Tamagochi();


            Console.WriteLine("Hello! Welcome to your Tamagochi!");

            while (named != true)
            {
                Console.WriteLine("\nPlease name your Tamagochi:");
                tama.name = Console.ReadLine();

                string answer = "";
                while (answer != "y" && answer != "n")
                {
                    Console.WriteLine("\nYour selected name is: " + tama.name + ", correct?\ny/n");
                    answer = Console.ReadLine();
                    answer = answer.ToLower();

                    if (answer != "y" && answer != "n")
                    {
                        Console.WriteLine("\nPlease enter a valid answer (y/n)\n");

                    }
                }

                if (answer == "y")
                {
                    named = true;
                }

            }
            Console.Clear();

            tama.Play();

        }

    }
}

