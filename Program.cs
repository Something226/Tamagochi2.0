using System.Buffers;
using System;

namespace Tamagochi

{
    class Program

    {
        static void Main(string[] args)
        {
            bool named = false;
            Tamagochi tama1 = new Tamagochi();


            Console.WriteLine("Hello! Welcome to your Tamagochi!");

            while (named != true)
            {
                Console.WriteLine("\nPlease name your Tamagochi:");
                tama1.name = Console.ReadLine();

                string answer = "";
                while (answer != "y" && answer != "n")
                {
                    Console.WriteLine("\nYour selected name is: " + tama1.name + ", correct?\ny/n\n");
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

            tama1.Play();

        }

    }
}

