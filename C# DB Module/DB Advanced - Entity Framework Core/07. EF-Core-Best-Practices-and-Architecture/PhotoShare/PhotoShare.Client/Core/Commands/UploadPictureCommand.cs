namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Utilities;
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Linq;

    public class UploadPictureCommand
    {
        // UploadPicture <albumName> <pictureTitle> <pictureFilePath>
        public static string Execute(string[] commandArgs)
        {
            if (commandArgs.Length != 4)
            {
                throw new InvalidOperationException($"Command parameters count not valid!");
            }

            string albumName = commandArgs[1];
            string pictureTitle = commandArgs[2];
            string filePath = commandArgs[3];

            using (var db = new PhotoShareContext())
            {
                ValidateAlbum(albumName, db);

                var userId = Session.User.Id;
                var albumId = db
                    .Albums
                    .First(a => a.Name == albumName)
                    .Id;

                // User can upload picture only if he/she is album owner!
                CredentialsChecker.CheckAlbumOwnership(userId, albumId);

                UploadPicture(albumName, pictureTitle, filePath, db);

                return $"Picture {pictureTitle} added to {albumName}!";
            }
        }

        private static void UploadPicture(string albumName, string pictureTitle, string filePath, PhotoShareContext db)
        {
            var albumId = db
                .Albums
                .First(a => a.Name == albumName)
                .Id;

            var picture = new Picture()
            {
                Path = filePath,
                Title = pictureTitle,
                AlbumId = albumId
            };

            db.Pictures.Add(picture);
            db.SaveChanges();
        }

        private static void ValidateAlbum(string albumName, PhotoShareContext db)
        {
            var album = db
                .Albums
                .FirstOrDefault(a => a.Name == albumName);

            if (album == null)
            {
                throw new ArgumentException($"Album {albumName} not found!");
            }
        }
    }
}
