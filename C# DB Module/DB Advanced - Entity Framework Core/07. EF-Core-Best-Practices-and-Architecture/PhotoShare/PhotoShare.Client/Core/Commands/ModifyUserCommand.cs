namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Utilities;
    using PhotoShare.Data;
    using System;
    using System.Linq;

    public class ModifyUserCommand
    {
        // ModifyUser <username> <property> <new value>

        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public static string Execute(string[] commandArgs)
        {
            if (commandArgs.Length != 4)
            {
                throw new InvalidOperationException($"Command parameters count not valid!");
            }

            string output;

            string userName = commandArgs[1];
            string propertyToModify = commandArgs[2];
            string newValue = commandArgs[3];

            using (var db = new PhotoShareContext())
            {
                var isValidUser = db
                    .Users
                    .Any(u => u.Username == userName);

                if (!isValidUser)
                {
                    throw new ArgumentException($"User {userName} not found!");
                }

                CredentialsChecker.CheckUserCredentials(userName);

                switch (propertyToModify)
                {
                    case "Password":
                        output = ModifyPassword(db, userName, newValue);
                        break;
                    case "BornTown":
                        output = ModifyBornTown(db, userName, newValue);
                        break;
                    case "CurrentTown":
                        output = ModifyCurrentTown(db, userName, newValue);
                        break;
                    default: throw new ArgumentException($"Property {propertyToModify} not supported!");
                }

                return output;
            }
        }

        private static string ModifyCurrentTown(PhotoShareContext db, string userName, string newValue)
        {
            var isNewTownValid = db
                .Towns
                .Any(t => t.Name == newValue);

            if (!isNewTownValid)
            {
                throw new ArgumentException($"Value {newValue} not valid. {Environment.NewLine}Town {newValue} not found!");
            }

            var userToModifyTown = db
                .Users
                .First(u => u.Username == userName);

            var newTownId = db
                .Towns
                .First(t => t.Name == newValue)
                .Id;

            userToModifyTown.CurrentTownId = newTownId;
            db.SaveChanges();

            return $"User {userName} CurrnetTown is {newValue}.";
        }

        private static string ModifyBornTown(PhotoShareContext db, string userName, string newValue)
        {
            var isNewTownValid = db
                .Towns
                .Any(t => t.Name == newValue);

            if (!isNewTownValid)
            {
                throw new ArgumentException($"Value {newValue} not valid. {Environment.NewLine}Town {newValue} not found!");
            }

            var userToModifyTown = db
                .Users
                .First(u => u.Username == userName);

            var newTownId = db
                .Towns
                .First(t => t.Name == newValue)
                .Id;

            userToModifyTown.BornTownId = newTownId;
            db.SaveChanges();

            return $"User {userName} BornTown is {newValue}.";
        }

        private static string ModifyPassword(PhotoShareContext db, string userName, string newValue)
        {
            if (newValue.Any(v => Char.IsDigit(v)) && newValue.Any(v => Char.IsLower(v)))
            {
                var userToChangePassword = db
                .Users
                .First(u => u.Username == userName);

                userToChangePassword.Password = newValue;
                db.SaveChanges();

                return $"User {userName} password is {newValue}.";
            }
            else
            {
                throw new ArgumentException($"Value {newValue} not valid. {Environment.NewLine}Invalid Password");
            }
        }
    }
}
