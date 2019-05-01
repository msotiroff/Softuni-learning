namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Utilities;
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Linq;

    public class ShareAlbumCommand
    {
        // ShareAlbum <albumId> <username> <permission>
        // For example:
        // ShareAlbum 4 dragon321 Owner
        // ShareAlbum 4 dragon11 Viewer
        public static string Execute(string[] commandArgs)
        {
            if (commandArgs.Length != 4)
            {
                throw new InvalidOperationException($"Command parameters count not valid!");
            }

            var albumId = int.Parse(commandArgs[1]);
            var userName = commandArgs[2];
            var permission = commandArgs[3];

            using (var db = new PhotoShareContext())
            {
                ValidateAlbum(albumId, db);
                ValidateUser(userName, db);
                Role role = ValidateRole(permission);

                int userId = db
                    .Users
                    .First(u => u.Username == userName)
                    .Id;


                CredentialsChecker.CheckLogin();
                int loggedUserId = Session.User.Id;

                CredentialsChecker.CheckAlbumOwnership(loggedUserId, albumId);

                ShareAlbum(albumId, db, role, userId);

                var albumName = db
                    .Albums
                    .First(a => a.Id == albumId)
                    .Name;

                return $"Username {userName} added to album {albumName} ({permission})";
            }
        }

        private static void ShareAlbum(int albumId, PhotoShareContext db, Role role, int userId)
        {
            AlbumRole currentAlbumRole = new AlbumRole()
            {
                AlbumId = albumId,
                UserId = userId,
                Role = role
            };

            db.AlbumRoles.Add(currentAlbumRole);
            db.SaveChanges();
        }

        private static Role ValidateRole(string permission)
        {
            Role role;

            var isRoleValid = Enum.TryParse(permission, true, out role);

            if (!isRoleValid)
            {
                throw new ArgumentException("Permission must be either “Owner” or “Viewer”!");
            }

            return role;
        }

        private static void ValidateUser(string userName, PhotoShareContext db)
        {
            var isUserExisting = db
                                .Users
                                .Any(u => u.Username == userName);

            if (!isUserExisting)
            {
                throw new ArgumentException($"User {userName} not found!");
            }
        }

        private static void ValidateAlbum(int albumId, PhotoShareContext db)
        {
            var isAlbumExisting = db
                                .Albums
                                .Any(a => a.Id == albumId);

            if (!isAlbumExisting)
            {
                throw new ArgumentException($"Album {albumId} not found!");
            }
        }
    }
}
