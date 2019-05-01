namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using PhotoShare.Data;
    using PhotoShare.Models;
    using PhotoShare.Client.Utilities;

    public class CreateAlbumCommand
    {
        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public static string Execute(string[] commandArgs)
        {
            if (commandArgs.Length < 4)
            {
                throw new InvalidOperationException($"Command parameters count not valid!");
            }

            CredentialsChecker.CheckLogin();

            string userName = commandArgs[1];
            string albumTitle = commandArgs[2];
            string colorName = commandArgs[3];

            CredentialsChecker.CheckUserCredentials(userName);

            using (var db = new PhotoShareContext())
            {
                CheckUser(userName, db);

                CheckAlbum(albumTitle, db);

                Color backGroundColor = CheckColor(colorName);

                CheckForInvalidTags(commandArgs, db);

                CreateBasicAlbum(albumTitle, db, backGroundColor);

                /* 
                 * By condition of current task Logged in user can share an album (only if he is owner of the album),
                 * so when create an album, we set the creater as first owner!
                 */
                SetOwnerToAlbum(db, albumTitle);

                if (commandArgs.Length > 4)
                {
                    List<string> tagNames = GetTagNames(commandArgs);

                    AddTagsToAlbum(albumTitle, tagNames, db);
                }

                return $"Album {albumTitle} successfully created!";
            }
        }

        private static void SetOwnerToAlbum(PhotoShareContext db, string albumTitle)
        {
            var albumId = db
                    .Albums
                    .First(a => a.Name == albumTitle)
                    .Id;

            var albumRole = new AlbumRole()
            {
                AlbumId = albumId,
                UserId = Session.User.Id,
                Role = Role.Owner
            };

            db.AlbumRoles.Add(albumRole);
            db.SaveChanges();
        }

        private static List<string> GetTagNames(string[] commandArgs)
        {
            List<string> tagNames = new List<string>();

            for (int i = 4; i < commandArgs.Length; i++)
            {
                tagNames.Add(commandArgs[i].ValidateOrTransform());
            }

            return tagNames;
        }

        private static void AddTagsToAlbum(string albumTitte, List<string> tagNames, PhotoShareContext db)
        {
            var albumToAddTags = db
                .Albums
                .First(a => a.Name == albumTitte)
                .Id;

            var tagsIds = db
                .Tags
                .Where(t => tagNames.Contains(t.Name))
                .Select(t => t.Id)
                .ToList();

            List<AlbumTag> tagsToBeAdded = new List<AlbumTag>();

            for (int i = 0; i < tagsIds.Count; i++)
            {
                var currentAlbumTag = new AlbumTag()
                {
                    AlbumId = albumToAddTags,
                    TagId = tagsIds[i]
                };

                tagsToBeAdded.Add(currentAlbumTag);
            }

            db.AlbumTags.AddRange(tagsToBeAdded);
            db.SaveChanges();
        }

        private static void CreateBasicAlbum(string albumTitte, PhotoShareContext db, Color backGroundColor)
        {
            var album = new Album();

            album.Name = albumTitte;
            album.BackgroundColor = backGroundColor;

            db.Albums.Add(album);
            db.SaveChanges();
        }

        private static void CheckForInvalidTags(string[] commandArgs, PhotoShareContext db)
        {
            var isThereInvalidTag = false;

            var allTags = db
                .Tags
                .Select(t => t.Name)
                .ToList();

            for (int i = 4; i < commandArgs.Length; i++)
            {
                string tagToBeChecked = commandArgs[i].ValidateOrTransform();

                if (!allTags.Contains(tagToBeChecked))
                {
                    isThereInvalidTag = true;
                    break;
                }
            }

            if (isThereInvalidTag)
            {
                throw new ArgumentException($"Invalid tags!");
            }
        }

        private static Color CheckColor(string colorName)
        {
            Color color;

            var isColorExisting = Enum.TryParse(colorName, true, out color);

            if (!isColorExisting)
            {
                throw new ArgumentException($"Color {colorName} not found!");
            }

            return color;
        }

        private static void CheckAlbum(string albumTitte, PhotoShareContext db)
        {
            var isAlbumExisting = db
                    .Albums
                    .Any(a => a.Name == albumTitte);

            if (isAlbumExisting)
            {
                throw new ArgumentException($"Album {albumTitte} exists!");
            }
        }

        private static void CheckUser(string userName, PhotoShareContext db)
        {
            var user = db
                .Users
                .FirstOrDefault(u => u.Username == userName);

            if (user == null)
            {
                throw new ArgumentException($"User {userName} not found!");
            }
        }
    }
}
