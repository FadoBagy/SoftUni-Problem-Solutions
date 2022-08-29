using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    class Trainer
    {
        public Trainer(string name, Pokemon pokemon)
        {
            Name = name;
            ColectionOfPokemons.Add(pokemon);
        }
        public Trainer()
        {

        }
        public string Name { get; set; }
        public int NumberOfBadges { get; set; } = 0;
        public List<Pokemon> ColectionOfPokemons = new List<Pokemon>();
    }
}
