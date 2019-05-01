namespace Instagraph.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using System.Linq;
    
    using Newtonsoft.Json;
    using Microsoft.EntityFrameworkCore;

    using Instagraph.Data;
    using Instagraph.DataProcessor.Dto.Export;

    public class Serializer
    {
        public static string ExportUncommentedPosts(InstagraphContext context)
        {
            var uncommentedPosts = context
                .Posts
                .Where(p => p.Comments.Count == 0)
                .Select(p => new
                {
                    Id = p.Id,
                    Picture = p.Picture.Path,
                    User = p.User.Username
                })
                .OrderBy(x => x.Id)
                .ToArray();

            var result = JsonConvert.SerializeObject(uncommentedPosts, Formatting.Indented);

            Console.WriteLine(result);

            return result;
        }

        public static string ExportPopularUsers(InstagraphContext context)
        {
            var popularUsers = context
                .Users
                .Where(u => u.Posts
                    .Any(p => p.Comments
                        .Any(c => u.Followers
                            .Any(uf => uf.FollowerId == c.UserId))))
                .OrderBy(u => u.Id)
                .Select(u => new
                {
                    Username = u.Username,
                    Followers = u.Followers.Count
                })
                .ToArray();

            var result = JsonConvert.SerializeObject(popularUsers, Formatting.Indented);

            return result;
        }

        public static string ExportCommentsOnPosts(InstagraphContext context)
        {
            var users = context
                .Users
                .Include(u => u.Posts)
                .Include(u => u.Comments)
                .ToArray();

            

            var selectedUsers = new List<UserDto>();

            foreach (var user in users)
            {
                int? mostCommentedPost = user.Posts
                        .Select(p => p.Comments.Count)
                        .OrderByDescending(p => p)
                        .FirstOrDefault();

                if (mostCommentedPost == null)
                {
                    mostCommentedPost = 0;
                }

                var selectedUser = new UserDto()
                {
                    Username = user.Username,
                    MostComments = mostCommentedPost.Value
                };

                selectedUsers.Add(selectedUser);
            }


            var xmlDoc = new XDocument(new XElement("users"));

            foreach (var user in selectedUsers.OrderByDescending(u => u.MostComments).ThenBy(u => u.Username))
            {
                xmlDoc.Root.Add(new XElement("user",
                            new XElement("Username", user.Username),
                            new XElement("MostComments", user.MostComments)));
            }

            var result = xmlDoc.ToString();

            return result;
        }
    }
}
