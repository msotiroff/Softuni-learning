namespace P01_BillsPaymentSystem.App
{
    using System;
    using P03_UserDetailsMenu;
    using P02_BillsPaymentDbInitializer;
    using P04_BillPayer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            DatabaseInitializer.ResetDatabase();

            StartOptionsMenu();
        }

        private static void InvalidInputMsg()
        {
            Console.Clear();
            Console.WriteLine("Please, enter a valid option!");
            Console.WriteLine("-----------------------------");
        }

        private static void StartOptionsMenu()
        {
            while (true)
            {
                Console.WriteLine("Options:");
                Console.WriteLine("For user details: enter '1'");
                Console.WriteLine("For paying bills: enter '2'");
                Console.WriteLine("For exit: enter '0'");
                Console.Write("Make your choice: ");

                string input = Console.ReadLine();
                Console.WriteLine(new string('-', 20));
                int chosenOption;

                if (int.TryParse(input, out chosenOption))
                {
                    switch (chosenOption)
                    {
                        case 1:
                            UserDeatailsRetriever.Run();
                            break;
                        case 2:
                            BillPayer.Run();
                            break;
                        case 0:
                            Environment.Exit(0);
                            break;
                        default:
                            InvalidInputMsg();
                            break;
                    }
                }
                else
                {
                    InvalidInputMsg();
                }
            }
        }
    }
}
