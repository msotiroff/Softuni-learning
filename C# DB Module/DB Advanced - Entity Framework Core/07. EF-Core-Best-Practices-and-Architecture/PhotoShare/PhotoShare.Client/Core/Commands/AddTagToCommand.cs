namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Utilities;
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Linq;

    public class AddTagToCommand 
    {
        // AddTagTo <albumName> <tag>
        public static string Execute(string[] commandArgs)
        {
            if (commandArgs.Length != 3)
            {
                throw new InvalidOperationException($"Command parameters count not valid!");
            }

            CredentialsChecker.CheckLogin();

            string albumName = commandArgs[1];
            string tagName = commandArgs[2];

            using (var db = new PhotoShareContext())
            {
                ValidateParameters(albumName, tagName, db);

                var userId = Session.User.Id;

                var albumId = db
                    .Albums
                    .First(a => a.Name == albumName)
                    .Id;

                // Logged user can add tag to album (only if he is owner of the album)
                CredentialsChecker.CheckAlbumOwnership(userId, albumId);

                AddAlbumTag(albumName, tagName, db);

                return $"Tag {tagName} added to {albumName}!";
            }
        }

        private static void AddAlbumTag(string albumName, string tagName, PhotoShareContext db)
        {
            var albumId = db
                .Albums
                .First(a => a.Name == albumName)
                .Id;

            var tagId = db
                .Tags
                .First(t => t.Name == tagName.ValidateOrTransform())
                .Id;

            var currentAlbumTag = new AlbumTag()
            {
                AlbumId = albumId,
                TagId = tagId
            };

            db.AlbumTags.Add(currentAlbumTag);
            db.SaveChanges();
        }

        private static void ValidateParameters(string albumName, string tagName, PhotoShareContext db)
        {
            var isAlbumExisting = db
                    .Albums
                    .Any(a => a.Name == albumName);

            var isTagExisting = db
                .Tags
                .Any(t => t.Name == tagName.ValidateOrTransform());

            if (!isAlbumExisting || !isTagExisting)
            {
                throw new ArgumentException("Either tag or album do not exist!");
            }
        }
    }
}
