namespace Instagraph.DataProcessor
{
    using Instagraph.Data;
    using System.Xml.Linq;
    using System.Linq;
    using Newtonsoft.Json;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using Instagraph.Models.ModelDto;

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

            string result = JsonConvert.SerializeObject(uncommentedPosts, Formatting.Indented);

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
                .ThenInclude(p => p.Comments)
                .ToList();

            var selectedUsers = new List<UserPostDto>();

            var xmlDoc = new XDocument(new XElement("users"));

            foreach (var user in users)
            {
                var mostCommentedPostsCount = user.Posts.Select(p => p.Comments.Count).ToArray();

                int mostComments = 0;

                if (mostCommentedPostsCount.Any())
                {
                    mostComments = mostCommentedPostsCount.OrderByDescending(c => c).First();
                }

                var currentUserPostDto = new UserPostDto()
                {
                    Username = user.Username,
                    MostComments = mostComments
                };

                selectedUsers.Add(currentUserPostDto);
            }

            foreach (var user in selectedUsers.OrderByDescending(su => su.MostComments).ThenBy(su => su.Username))
            {
                xmlDoc.Root.Add(new XElement("user",
                                    new XElement("Username", user.Username),
                                    new XElement("MostComments", user.MostComments)));
            }

            string xmlResult = xmlDoc.ToString();

            return xmlResult;
        }
    }
}
