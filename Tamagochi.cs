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
                Console.WriteLine("\n" + name + " doesn't know any words, they are stupid :(");
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

        public void Tick(int hungerAmount, int boredomAmount)
        {
            hunger += hungerAmount;
            boredom += boredomAmount;

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

            if (hunger >= 6)
            {
                Console.WriteLine(name + " is hungry, you should feed him something :O\n");
            }
            else if (boredom >= 6)
            {
                Console.WriteLine(name + " is bored, try doing stuff with him :O\n");
            }
            else
            {
                Console.WriteLine(name + " is doing alright! :D\n");
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
                Tick(1, 1);
            }
            else
            {
                int selection = generator.Next(foods.Count);

                Console.WriteLine("\nYou fed " + name + " a " + foods[selection] + ", they seemed to like it :D\n");

                foods.RemoveAt(selection);

                hunger -= 3;

                Tick(0, 2);

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

                Console.WriteLine("Choose what you want to do with " + name + "!\n1)Feed\n2)Teach word\n3)Say word\n4)Go grocery shopping\n5)Check " + name + "'s well being :)\n6)Do Nothing :O\n(Type the number of desired action)");

                while (!int.TryParse(Console.ReadLine(), out option) || (option < 1 || option > 6))
                {
                    Console.WriteLine("Please enter a valid number");
                    Tick(1, 1);
                }

                if (option == 1)
                {
                    Console.Clear();

                    Feed();

                }
                if (option == 2)
                {
                    Console.Clear();

                    Console.WriteLine("\nWrite the word you want " + name + " to learn :D\n");
                    string addword = Console.ReadLine();

                    Console.WriteLine("\nYou taught " + name + " to say " + addword + ". He is now less stupid :O!\n");

                    Teach(addword);
                    Tick(generator.Next(1, 2), 0);
                }
                if (option == 3)
                {
                    Console.Clear();

                    Hi();
                    Tick(generator.Next(1, 2), 0);
                }
                if (option == 4)
                {
                    Console.Clear();

                    Shop();
                    Tick(1, 2);
                }
                if (option == 5)
                {
                    Console.Clear();

                    PrintStats();
                }
                if (option == 6)
                {
                    Console.Clear();

                    Console.WriteLine("You did nothing! How rude! >:(\n");
                    Tick(4, 4);
                }

            }

            Console.WriteLine(name + " died from natural causes, you monster! >:O");
            Console.ReadLine();

        }
    }
}