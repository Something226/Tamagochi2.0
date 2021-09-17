using System.ComponentModel.Design;
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
        private List<string> foods = new List<string>();

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
            if (words.Count == 0)
            {
                Console.WriteLine("\n" + name + " doesn't know any words, he stupid :(");
            }
            else
            {
                Console.WriteLine(name + " Says: " + words[generator.Next(words.Count)] + "\n");
                ReduceBoredom();
            }
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

        public void Shop()
        {
            int option = 0;

            Console.WriteLine("\nChoose what food you want to buy!\n1)Chocolate Bar\n2)Salad\n3)Burger\n(Type the number of desired food)");

            while (!int.TryParse(Console.ReadLine(), out option) || (option < 1 || option > 3))
            {
                Console.WriteLine("Please enter a valid number");
            }

            if (option == 1)
            {
                foods.Add("Chocolate Bar");
                Console.WriteLine("\nYou bought a Chocolate Bar, Sweet :P\n");
            }
            if (option == 2)
            {
                foods.Add("Salad");
                Console.WriteLine("\nYou bought a Salad, Healthy :O\n");
            }
            if (option == 3)
            {
                foods.Add("Burger");
                Console.WriteLine("\nYou bought a Burger, Tasty :D\n");
            }
        }

        public void Feed()
        {
            if (foods.Count == 0)
            {
                Console.WriteLine("\nYou don't own any food! Even the fridge is empty! :O\n");
            }
            else
            {
                int selection = generator.Next(foods.Count);

                Console.WriteLine("\nYou fed " + name + " a " + foods[selection] + ", they seemed to like it :D\n");

                foods.RemoveAt(selection);

                hunger -= 3;

                if (hunger <= 0)
                {
                    hunger = 0;
                }
            }
        }

        public void Play()
        {
            while (IsAlive())
            {
                int option = 0;

                Console.WriteLine("Choose what you want to do with " + name + "!\n1)Feed\n2)Teach word\n3)Say word\n4)Go grocery shopping\n5)Check " + name + "'s well being :)\n(Type the number of desired action)");

                while (!int.TryParse(Console.ReadLine(), out option) || (option < 1 || option > 5))
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

                    Console.WriteLine("\nYou taught " + name + " to say " + addword + ". He is now less stupid :O!\n");

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
                    Shop();
                }
                if (option == 5)
                {
                    PrintStats();
                }

            }

            Console.WriteLine(name + " died from natural causes, you monster! >:O");
            Console.ReadLine();

        }
    }
}