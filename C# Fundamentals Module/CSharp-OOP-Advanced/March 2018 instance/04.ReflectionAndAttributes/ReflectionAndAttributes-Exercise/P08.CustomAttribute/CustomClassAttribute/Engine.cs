namespace CustomClassAttribute
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class Engine
    {
        private bool isRunning;

        public Engine()
        {
        }

        public void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                var command = Console.ReadLine();
                var weaponType = Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .First(t => t.Name == nameof(Weapon));

                var weaponInfo = weaponType
                    .GetCustomAttribute<WeaponInfoAttribute>();

                var result = string.Empty;

                switch (command)
                {
                    case "Author":
                        result = "Author: " + weaponInfo.Author;
                        break;
                    case "Revision":
                        result = "Revision: " + weaponInfo.Revision.ToString();
                        break;
                    case "Description":
                        result = "Class description: " + weaponInfo.Description;
                        break;
                    case "Reviewers":
                        result = "Reviewers: " + string.Join(", ", weaponInfo.Reviewers);
                        break;
                    case "END":
                        this.isRunning = false;
                        break;
                }

                if (result != string.Empty)
                {
                    Console.WriteLine(result);
                }
            }
        }
    }
}