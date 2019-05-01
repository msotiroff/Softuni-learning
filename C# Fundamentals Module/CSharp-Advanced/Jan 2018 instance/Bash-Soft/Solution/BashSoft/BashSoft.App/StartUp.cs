namespace BashSoft.App
{
    using IO;
    using Core;
    using BashSoft.App.Repositories;
    using BashSoft.App.SimpleJudge;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var commandInterpreter = new CommandInterpreter();

            var inputReader = new InputReader(commandInterpreter);
            inputReader.StartReadingCommands();

            // TESTS:

            //IOManager.ChangeCurrentDirectoryAbsolute("C:\\Windows");
            //IOManager.TraverseDirectory(20);
            //IOManager.CreateDirectoryInCurrentFolder("InvalidSymbol -> *");

            //StudentRepository.InitializeData();
            //StudentRepository.GetAllStudentsFromCourse("Unity");
            //StudentRepository.GetStudentScoresFromCourse("Unity", "Ivan");

            //Tester.CompareContent(@"IO\Files\test2.txt", @"IO\Files\test3.txt");
            //Tester.CompareContent(@"D:\UnexsistentDirectory\UnexistentFile.txt", @"D:\AnotherUnexsistentDirectory\AnotherUnexistentFile.txt");
        }
    }
}
