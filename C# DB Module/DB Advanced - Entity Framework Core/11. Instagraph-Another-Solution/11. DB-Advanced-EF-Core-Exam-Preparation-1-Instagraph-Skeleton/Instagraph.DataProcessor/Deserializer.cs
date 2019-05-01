namespace Instagraph.DataProcessor
{
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using System.IO;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    using Instagraph.Data;
    using Instagraph.Models;
    using Instagraph.DataProcessor.Dto.Import;

    public class Deserializer
    {
        private static string ErrorMessage = "Error: Invalid data.";

        public static string ImportPictures(InstagraphContext context, string jsonString)
        {
            var picturesFromJson = JsonConvert.DeserializeObject<PictureDto[]>(jsonString);

            var result = new StringBuilder();

            var validPictures = new List<Picture>();

            foreach (var pictureDto in picturesFromJson)
            {
                if (!IsValid(pictureDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var isPathValid = validPictures.All(p => p.Path != pictureDto.Path)
                                                        && !string.IsNullOrEmpty(pictureDto.Path);

                if (pictureDto.Size <= 0 || !isPathValid)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var picture = new Picture()
                {
                    Path = pictureDto.Path,
                    Size = pictureDto.Size.Value
                };

                validPictures.Add(picture);
                result.AppendLine($"Successfully imported Picture {pictureDto.Path}.");
            }

            context.Pictures.AddRange(validPictures);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportUsers(InstagraphContext context, string jsonString)
        {
            var usersFromJson = JsonConvert.DeserializeObject<UserDto[]>(jsonString);

            var result = new StringBuilder();

            var validUsers = new List<User>();

            foreach (var userDto in usersFromJson)
            {
                if (!IsValid(userDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var profilePicture = context.Pictures.FirstOrDefault(p => p.Path == userDto.ProfilePicture);

                if (profilePicture == null)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var currentUser = new User()
                {
                    Username = userDto.Username,
                    Password = userDto.Password,
                    ProfilePicture = profilePicture
                };

                validUsers.Add(currentUser);
                result.AppendLine($"Successfully imported User {userDto.Username}.");
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportFollowers(InstagraphContext context, string jsonString)
        {
            var followersFromJson = JsonConvert.DeserializeObject<FollowerDto[]>(jsonString);

            var result = new StringBuilder();

            var validFollowers = new List<UserFollower>();

            foreach (var followerDto in followersFromJson)
            {
                if (!IsValid(followerDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var user = context.Users.FirstOrDefault(u => u.Username == followerDto.User);

                var follower = context.Users.FirstOrDefault(u => u.Username == followerDto.Follower);

                if (user == null || follower == null)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var isAlreadyFollower = validFollowers.Any(f => f.UserId == user.Id && f.FollowerId == follower.Id);

                if (isAlreadyFollower)
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var userFollower = new UserFollower()
                {
                    UserId = user.Id,
                    FollowerId = follower.Id
                };

                validFollowers.Add(userFollower);
                result.AppendLine($"Successfully imported Follower {followerDto.Follower} to User {followerDto.User}.");
            }

            context.UsersFollowers.AddRange(validFollowers);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportPosts(InstagraphContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(PostDto[]), new XmlRootAttribute("posts"));
            var deserializedPosts = (PostDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var result = new StringBuilder();

            var validPosts = new List<Post>();

            foreach (var postDto in deserializedPosts)
            {
                if (!IsValid(postDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var user = context.Users.FirstOrDefault(u => u.Username == postDto.User);
                var picture = context.Pictures.FirstOrDefault(p => p.Path == postDto.Picture);

                if (user == null || picture == null || string.IsNullOrWhiteSpace(postDto.Caption))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var post = new Post()
                {
                    Caption = postDto.Caption,
                    User = user,
                    Picture = picture
                };

                validPosts.Add(post);
                result.AppendLine($"Successfully imported Post {postDto.Caption}.");
            }

            context.Posts.AddRange(validPosts);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportComments(InstagraphContext context, string xmlString)
        {
            var xmlDoc = XDocument.Parse(xmlString);

            var elements = xmlDoc.Root.Elements();

            var result = new StringBuilder();

            var validComments = new List<Comment>();

            foreach (var element in elements)
            {
                var commentDto = new CommentDto()
                {
                    Content = element.Element("content")?.Value,
                    User = element.Element("user")?.Value,
                    PostId = element.Element("post")?.Attribute("id")?.Value
                };

                if (!IsValid(commentDto))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var user = context.Users.FirstOrDefault(u => u.Username == commentDto.User);
                var post = context.Posts.FirstOrDefault(p => p.Id.ToString() == commentDto.PostId);

                if (user == null || post == null || string.IsNullOrEmpty(commentDto.Content))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var comment = new Comment()
                {
                    Content = commentDto.Content,
                    User = user,
                    Post = post
                };

                validComments.Add(comment);
                result.AppendLine($"Successfully imported Comment {comment.Content}.");
            }

            context.Comments.AddRange(validComments);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
            return isValid;
        }
    }
}
