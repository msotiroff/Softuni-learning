using System.Collections.Generic;

namespace P11.PokemonTrainer.Models
{
    public class Trainer
    {
        // name, number of badges and a collection of pokemon

        public string Name { get; set; }

        public int Badges { get; set; }

        public List<Pokemon> Pokemons { get; set; }

        public Trainer(string name)
        {
            this.Name = name;
            this.Badges = 0;
            this.Pokemons = new List<Pokemon>();
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Badges} {this.Pokemons.Count}";
        }
    }
}
