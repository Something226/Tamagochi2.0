using System.Collections.Generic;
using System;

namespace Tamagochi
{
    public class Tamagochi
    {
        //tamagochi values
        private int hunger = 0;
        private int boredom = 0;

        private List<string> words = new List<string>();

        private bool isAlive = true;

        private Random generator = new Random();

        public string name;


        //methods
        /*public void Name()
        {

        }
        */
        public void Hi()
        {

            Console.WriteLine(name + "Says: " + words[generator.Next(words.Count)] + "\n");
            ReduceBoredom();
        }

        public void Teach(string word)
        {
            words.Add(word);
            ReduceBoredom();
        }

        public void Tick()
        {
            hunger++;
            boredom++;

            if (hunger > 10 || boredom > 10)
            {
                isAlive = false;
            }
        }

        public void PrintStats()
        {
            Console.WriteLine("\nHunger:" + hunger);
            Console.WriteLine("Boredom:" + boredom);

            if (isAlive)
            {
                Console.WriteLine(name + " is alive! :D\n");
            }
            else
            {
                Console.WriteLine(name + " is ded :(\n");
            }
        }

        public bool IsAlive()
        {
            return isAlive;
        }

        private void ReduceBoredom()
        {
            boredom -= 2;

            if (boredom <= 0)
            {
                boredom = 0;
            }
        }

        public void Feed()
        {
            Console.WriteLine("\nYou fed " + name + ", they seemed to like it :D\n");

            hunger -= 3;

            if (hunger <= 0)
            {
                hunger = 0;
            }
        }

        public void Play()
        {
            while (IsAlive())
            {

                int option = 0;

                Console.WriteLine("\nChoose what you want to do with " + name + "!\n1)Feed\n2)Teach word\n3)Say word\n4)Check " + name + "'s well being :)\n(Type the number of desired action)");

                while (!int.TryParse(Console.ReadLine(), out option) || (option < 1 || option > 4))
                {
                    Console.WriteLine("Please enter a valid number");
                    Tick();
                }

                if (option == 1)
                {
                    Feed();
                    Tick();
                }
                if (option == 2)
                {
                    Console.WriteLine("\nWrite the word you want " + name + " to learn :D\n");
                    string addword = Console.ReadLine();

                    Teach(addword);
                    Tick();
                }
                if (option == 3)
                {
                    Hi();
                    Tick();
                }
                if (option == 4)
                {
                    PrintStats();
                    Tick();
                }

            }

            Console.WriteLine(name + " died from natural causes, you monster! >:O");
            Console.ReadLine();

        }
    }
}