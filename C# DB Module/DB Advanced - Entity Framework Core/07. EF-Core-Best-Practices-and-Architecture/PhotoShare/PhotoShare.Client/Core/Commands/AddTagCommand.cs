namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;

    using Models;
    using Data;
    using Utilities;   

    public class AddTagCommand
    {
        // AddTag <tag>
        public static string Execute(string[] commandArgs)
        {
            if (commandArgs.Length != 2)
            {
                throw new InvalidOperationException($"Command parameters count not valid!");
            }

            CredentialsChecker.CheckLogin();

            string tag = commandArgs[1].ValidateOrTransform();

            using (var db = new PhotoShareContext())
            {
                var isTagExisting = db
                    .Tags
                    .Any(t => t.Name == tag);

                if (isTagExisting)
                {
                    throw new ArgumentException($"Tag {tag} exists!");
                }

                db.Tags.Add(new Tag
                {
                    Name = tag
                });

                db.SaveChanges();
            }

            return $"Tag {tag} was added successfully!";
        }
    }
}
