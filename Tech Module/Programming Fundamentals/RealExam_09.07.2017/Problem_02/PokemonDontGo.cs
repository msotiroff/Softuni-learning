using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_02
{
    class PokemonDontGo
    {
        static void Main(string[] args)
        {
            List<long> allPokemons = Console.ReadLine()
                .Split(' ')
                .Select(long.Parse)
                .ToList();

            long sumOfRemovedElements = 0;

            while (allPokemons.Count > 0)
            {
                int currentIndex = int.Parse(Console.ReadLine());

                if (currentIndex < 0)
                {
                    long lastElement = allPokemons.Last();
                    long elementToRemove = allPokemons.First();

                    sumOfRemovedElements += elementToRemove;
                    allPokemons[0] = lastElement;
                    ChangeElements(allPokemons, elementToRemove);
                }
                else if (currentIndex >= allPokemons.Count)
                {
                    long firstElement = allPokemons.First();
                    long elementToRemove = allPokemons.Last();

                    sumOfRemovedElements += elementToRemove;
                    allPokemons[allPokemons.Count - 1] = firstElement;

                    ChangeElements(allPokemons, elementToRemove);
                }
                else
                {
                    long elementToRemove = allPokemons[currentIndex];

                    sumOfRemovedElements += elementToRemove;
                    allPokemons.RemoveAt(currentIndex);

                    ChangeElements(allPokemons, elementToRemove);
                }

            }

            Console.WriteLine(sumOfRemovedElements);
        }

        public static void ChangeElements(List<long> allPokemons, long elementToRemove)
        {
            for (int i = 0; i < allPokemons.Count; i++)
            {
                if (allPokemons[i] <= elementToRemove)
                {
                    allPokemons[i] += elementToRemove;
                }
                else
                {
                    allPokemons[i] -= elementToRemove;
                }
            }
        }
    }
}
