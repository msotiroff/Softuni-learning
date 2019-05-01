using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Exercises
{
    public class Exercises
    {
        public static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();

            List<Exercise> allExercises = new List<Exercise>();

            while (inputLine != "go go go")
            {
                List<string> inputParameters = inputLine
                    .Split(new[] { '-', '>', ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                FillTheExersizeList(allExercises, inputParameters);

                inputLine = Console.ReadLine();
            }

            PrintResults(allExercises);
        }

        public static void PrintResults(List<Exercise> allExercises)
        {
            foreach (var exersice in allExercises)
            {
                Console.WriteLine($"Exercises: {exersice.Topic}");
                Console.WriteLine($"Problems for exercises and homework for the \"{exersice.Course}\" course @ SoftUni.");
                Console.WriteLine($"Check your solutions here: {exersice.JudgeLink}");
                int counter = 1;
                foreach (var problem in exersice.Problems)
                {
                    Console.WriteLine($"{counter}. {problem}");
                    counter++;
                }
            }
        }

        public static void FillTheExersizeList(List<Exercise> allExercises, List<string> inputParameters)
        {
            Exercise currentExercise = new Exercise
            {
                Topic = inputParameters[0],
                Course = inputParameters[1],
                JudgeLink = inputParameters[2],
                Problems = new List<string>()
            };
            for (int i = 3; i < inputParameters.Count; i++)
            {
                currentExercise.Problems.Add(inputParameters[i]);
            }
            allExercises.Add(currentExercise);
        }
    }
}
