using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_04
{
    public class Evolution
    {
        public string Type { get; set; }
        public int Index { get; set; }
    }
    class PokemonEvolution
    {
        static void Main(string[] args)
        {
            //        Name          typesAndIndexes
            Dictionary<string, List<Evolution>> allPokemons = new Dictionary<string, List<Evolution>>();

            string inputLine = Console.ReadLine();

            while (inputLine != "wubbalubbadubdub")
            {
                string[] inputParameters = inputLine
                    .Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string currentPokemonName = inputParameters[0];
                string currentPokemonEvoType = string.Empty;
                int currentPokemonIndex = -1;
                Evolution currentEvolution = new Evolution();

                if (inputParameters.Length > 1)
                {
                    currentPokemonEvoType = inputParameters[1];
                    currentPokemonIndex = int.Parse(inputParameters[2]);
                    
                    currentEvolution.Type = currentPokemonEvoType;
                    currentEvolution.Index = currentPokemonIndex;
                }
                else
                {
                    if (allPokemons.ContainsKey(currentPokemonName))
                    {
                        Console.WriteLine($"# {currentPokemonName}");

                        if (allPokemons[currentPokemonName].Count > 0)
                        {
                            foreach (var evo in allPokemons[currentPokemonName])
                            {
                                Console.WriteLine($"{evo.Type} <-> {evo.Index}");
                            }
                        }
                    }
                }
                if (! allPokemons.ContainsKey(currentPokemonName))
                {
                    if (inputParameters.Length > 1)
                    {
                        allPokemons[currentPokemonName] = new List<Evolution>();
                    }
                }
                if (inputParameters.Length > 1)
                {
                    allPokemons[currentPokemonName].Add(currentEvolution);
                }


                inputLine = Console.ReadLine();
            }


            foreach (var pokemon in allPokemons)
            {
                Console.WriteLine($"# {pokemon.Key}");

                foreach (var evo in pokemon.Value.OrderByDescending(e => e.Index))
                {
                    Console.WriteLine($"{evo.Type} <-> {evo.Index}");
                }
            }


        }
    }
}
