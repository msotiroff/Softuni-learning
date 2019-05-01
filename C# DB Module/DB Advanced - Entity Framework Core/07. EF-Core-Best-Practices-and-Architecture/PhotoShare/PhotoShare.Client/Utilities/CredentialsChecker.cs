namespace PhotoShare.Client.Utilities
{
    using System;
    using PhotoShare.Client.Core;
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System.Linq;

    public class CredentialsChecker
    {
        public static void CheckUserCredentials(string userName)
        {
            if (Session.User.Username != userName)
            {
                throw new InvalidOperationException("Invalid credentials!");
            }
        }

        public static void CheckLogin()
        {
            if (Session.User == null)
            {
                throw new InvalidOperationException("Invalid credentials!");
            }
        }

        public static void CheckLogout()
        {
            if (Session.User != null)
            {
                throw new InvalidOperationException("Invalid credentials!");
            }
        }

        public static void CheckAlbumOwnership(int userId, int albumId)
        {
            using (var db = new PhotoShareContext())
            {
                var neededRole = db
                .AlbumRoles
                .FirstOrDefault(ar => ar.UserId == userId && ar.AlbumId == albumId && ar.Role == Role.Owner);

                if (neededRole == null)
                {
                    throw new InvalidOperationException("Invalid credentials!");
                }
            }
        }
    }
}
