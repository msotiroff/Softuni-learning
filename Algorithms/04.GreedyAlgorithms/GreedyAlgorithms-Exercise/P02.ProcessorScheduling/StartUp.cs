namespace P02.ProcessorScheduling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var allTasks = new List<Task>();

            var tasksCount = int.Parse(Console.ReadLine().Split().Last());
            int lastDeadline = -1;

            for (int i = 0; i < tasksCount; i++)
            {
                var currentTaskArgs = Console.ReadLine()
                    .Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var value = currentTaskArgs[0];
                var deadLine = currentTaskArgs[1];

                if (lastDeadline < deadLine)
                {
                    lastDeadline = deadLine;
                }

                var task = new Task(value, deadLine);

                allTasks.Add(task);
            }

            var resultTasks = new List<Task>();
            var totalValue = 0;

            for (int currentDeadline = 0; currentDeadline < lastDeadline; currentDeadline++)
            {
                var mostProducingTask = allTasks
                    .Where(t => !t.IsCompleted && t.DeadLine > currentDeadline)
                    .OrderByDescending(t => t.Value / (t.DeadLine - currentDeadline))
                    .First();

                mostProducingTask.IsCompleted = true;
                totalValue += mostProducingTask.Value;

                resultTasks.Add(mostProducingTask);
            }

            Console.WriteLine($"Optimal schedule: {string.Join(" -> ", resultTasks.Select(t => t.TaskId))}");
            Console.WriteLine($"Total value: {totalValue}");
        }
    }
}
