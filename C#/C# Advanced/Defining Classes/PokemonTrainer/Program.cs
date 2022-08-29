using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            var trainersListHash = new HashSet<string>();
            List<Trainer> trainers = new List<Trainer>();
            while (true)
            {
                string[] input = Console.ReadLine().Split(" ");
                if (input[0] == "Tournament")
                {
                    break;
                }
                if (!trainersListHash.Contains(input[0]) && input[0] != "Tournament")
                {
                    trainersListHash.Add(input[0]);
                    var pokemon = new Pokemon(input[1], input[2], int.Parse(input[3])); 
                    var trainer = new Trainer(input[0], pokemon);
                    trainers.Add(trainer);
                }
                else
                {
                    for (int i = 0; i < trainers.Count; i++)
                    {
                        if (trainers[i].Name == input[0])
                        {
                            var pokemon = new Pokemon(input[1], input[2], int.Parse(input[3]));
                            trainers[i].ColectionOfPokemons.Add(pokemon);
                        }
                    }
                }
            }
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }
                if (command == "Fire")
                {
                    for (int i = 0; i < trainers.Count; i++)
                    {
                        bool hasElement = false;
                        for (int j = 0; j < trainers[i].ColectionOfPokemons.Count; j++)
                        {
                            if (trainers[i].ColectionOfPokemons[j].Element == "Fire")
                            {
                                trainers[i].NumberOfBadges++;
                                hasElement = true;
                            }
                        }
                        if (hasElement == false)
                        {
                            for (int j = 0; j < trainers[i].ColectionOfPokemons.Count; j++)
                            {
                                trainers[i].ColectionOfPokemons[j].Health -= 10;
                                if (trainers[i].ColectionOfPokemons[j].Health <= 0)
                                {
                                    trainers[i].ColectionOfPokemons.Remove(trainers[i].ColectionOfPokemons[j]);
                                }
                            }
                        }
                    }
                }
                else if (command == "Water")
                {
                    for (int i = 0; i < trainers.Count; i++)
                    {
                        bool hasElement = false;
                        for (int j = 0; j < trainers[i].ColectionOfPokemons.Count; j++)
                        {
                            if (trainers[i].ColectionOfPokemons[j].Element == "Water")
                            {
                                trainers[i].NumberOfBadges++;
                                hasElement = true;
                            }
                        }
                        if (hasElement == false)
                        {
                            for (int j = 0; j < trainers[i].ColectionOfPokemons.Count; j++)
                            {
                                trainers[i].ColectionOfPokemons[j].Health -= 10;
                                if (trainers[i].ColectionOfPokemons[j].Health <= 0)
                                {
                                    trainers[i].ColectionOfPokemons.Remove(trainers[i].ColectionOfPokemons[j]);
                                }
                            }
                        }
                    }
                }
                else if (command == "Electricity")
                {
                    for (int i = 0; i < trainers.Count; i++)
                    {
                        bool hasElement = false;
                        for (int j = 0; j < trainers[i].ColectionOfPokemons.Count; j++)
                        {
                            if (trainers[i].ColectionOfPokemons[j].Element == "Electricity")
                            {
                                trainers[i].NumberOfBadges++;
                                hasElement = true;
                            }
                        }
                        if (hasElement == false)
                        {
                            for (int j = 0; j < trainers[i].ColectionOfPokemons.Count; j++)
                            {
                                trainers[i].ColectionOfPokemons[j].Health -= 10;
                                if (trainers[i].ColectionOfPokemons[j].Health <= 0)
                                {
                                    trainers[i].ColectionOfPokemons.Remove(trainers[i].ColectionOfPokemons[j]);
                                }
                            }
                        }
                    }
                }
            }
            
            foreach (var item in trainers.OrderByDescending(t => t.NumberOfBadges))
            {
                Console.WriteLine($"{item.Name} {item.NumberOfBadges} {item.ColectionOfPokemons.Count}");
            }
        }
    }
}
