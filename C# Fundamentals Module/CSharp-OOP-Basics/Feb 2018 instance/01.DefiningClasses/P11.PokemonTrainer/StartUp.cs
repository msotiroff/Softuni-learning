namespace P11.PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var allPokemons = new List<Pokemon>();
            var allTrainers = new HashSet<Trainer>();

            string command;
            while ((command = Console.ReadLine()) != "Tournament")
            {
                // Input format: <TrainerName> <PokemonName> <PokemonElement> <PokemonHealth>
                var cmdParams = command.Split();

                var trainerName = cmdParams[0];
                var pokemonName = cmdParams[1];
                var pokemonElement = cmdParams[2];
                var pokemonHealth = int.Parse(cmdParams[3]);

                var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                allPokemons.Add(pokemon);

                var trainer = allTrainers
                    .FirstOrDefault(t => t.Name == trainerName);

                if (trainer == null)
                {
                    trainer = new Trainer(trainerName);
                    trainer.Pokemons.Add(pokemon);
                    allTrainers.Add(trainer);
                }
                else
                {
                    trainer.Pokemons.Add(pokemon);
                }
            }

            string element;
            while ((element = Console.ReadLine()) != "End")
            {
                foreach (var trainer in allTrainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == element))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        trainer.Pokemons.Select(p => p.Health -= 10).ToList();
                        trainer.Pokemons.RemoveAll(p => p.Health <= 0);
                    }
                }
            }

            foreach (var trainer in allTrainers.OrderByDescending(t => t.Badges))
            {
                Console.WriteLine(trainer);
            }
        }
    }
}
