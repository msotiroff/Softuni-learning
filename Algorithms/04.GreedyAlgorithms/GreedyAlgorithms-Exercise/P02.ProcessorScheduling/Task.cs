namespace P02.ProcessorScheduling
{
    public class Task
    {
        private static int IdCounter = 1;

        public Task(int value, int deadline)
        {
            this.TaskId = IdCounter++;
            this.Value = value;
            this.DeadLine = deadline;
            this.IsCompleted = false;
        }

        public int TaskId { get; private set; }

        public int Value { get; private set; }

        public int DeadLine { get; private set; }

        public bool IsCompleted { get; set; }
    }
}
