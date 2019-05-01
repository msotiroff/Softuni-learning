namespace P01_StudentSystemDbInitializer.Generators
{
    using System;
    using System.Linq;
    using P01_StudentSystem.Data.Models;
    using P01_StudentSystem.Data;

    public class ResouceGenerator
    {
        private static Random rnd = new Random();

        private static string[] resourceNames =
        {
            "Data Structures - AA-Trees and AVL Trees",
            "Data Structures - Basic Tree Data Structures",
            "Data Structures - Binary Search Trees",
            "Data Structures - B-Trees and Red-Black Trees",
            "Data Structures - Combining Data Structures",
            "Data Structures - Exercises Linear Data Structures",
            "Data Structures - Hash Tables",
            "Data Structures - Heaps and Priority Queue",
            "Data Structures - Linear Data Structures",
            "Data Structures - Quad Trees",
            "Data Structures - Rope and Trie",
            "Алгоритми - Recursion",
            "Алгоритми - Combinatorial Algorithms",
            "Алгоритми - Greedy Algorithms",
            "Алгоритми - Dynamic Programming",
            "Алгоритми - Graphs and Graph Algorithms",
            "Алгоритми - Advanced Graph Algorithms",
            "Алгоритми - Problem Solving Methodology"
        };

        private static ResourceType[] types =
        {
            ResourceType.Presentation,
            ResourceType.Video,
            ResourceType.Document,
            ResourceType.Other
        };

        internal static void InitialResourseSeed(StudentSystemContext db)
        {
            var coursesIds = db
                .Courses
                .Select(c => c.CourseId)
                .ToArray();

            for (int i = 0; i < resourceNames.Length; i++)
            {
                var resource = new Resource()
                {
                    Name = resourceNames[i],
                    Url = "D:\\Resources\\" + resourceNames[i],
                    ResourceType = types[rnd.Next(0, types.Length)],
                    CourseId = coursesIds[rnd.Next(0, coursesIds.Length)]
                };

                db.Resources.Add(resource);

                db.SaveChanges();
            }
        }
    }
}
