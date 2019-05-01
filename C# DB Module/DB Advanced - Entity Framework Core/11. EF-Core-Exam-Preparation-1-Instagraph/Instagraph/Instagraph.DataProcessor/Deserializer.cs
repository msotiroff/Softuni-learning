namespace Instagraph.DataProcessor
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    using System.Xml.Linq;

    using Newtonsoft.Json;

    using Instagraph.Data;
    using Instagraph.Models;
    using Instagraph.Models.ModelDto;

    public class Deserializer
    {
        private static string errorMessage = "Error: Invalid data.";


        public static string ImportPictures(InstagraphContext context, string jsonString)
        {
            var picturesFromJson = JsonConvert.DeserializeObject<Picture[]>(jsonString);

            var result = new StringBuilder();

            var validPictures = new List<Picture>();

            foreach (var picture in picturesFromJson)
            {
                string currentPath = picture.Path;
                decimal currentSize = picture.Size;

                var isPathValid = validPictures.All(p => p.Path != currentPath) && !String.IsNullOrWhiteSpace(currentPath);

                var isSizeValid = currentSize > 0;

                if (!isPathValid || !isSizeValid)
                {
                    result.AppendLine(errorMessage);
                }
                else
                {
                    var currentPicture = new Picture()
                    {
                        Path = currentPath,
                        Size = currentSize
                    };

                    validPictures.Add(currentPicture);

                    result.AppendLine($"Successfully imported Picture {currentPath}.");
                }
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

            foreach (var user in usersFromJson)
            {
                string currentUserName = user.UserName;
                string currentPassword = user.Password;
                string currentImagePath = user.ProfilePicture;

                var isUsernameInvalid =
                    String.IsNullOrWhiteSpace(currentUserName)
                    || validUsers.Any(u => u.Username == currentUserName) 
                    || currentUserName.Length > 30;

                var isPasswordInvalid = 
                    String.IsNullOrWhiteSpace(currentPassword) 
                    || currentPassword.Length > 20;

                var isPictureInvalid = 
                    String.IsNullOrWhiteSpace(currentPassword) 
                    || !context.Pictures.Any(p => p.Path == currentImagePath);

                if (isUsernameInvalid || isPasswordInvalid || isPictureInvalid)
                {
                    result.AppendLine(errorMessage);
                }
                else
                {
                    var currentUser = new User()
                    {
                        Username = currentUserName,
                        Password = currentPassword,
                        ProfilePictureId = context.Pictures.First(p => p.Path == currentImagePath).Id
                    };

                    validUsers.Add(currentUser);

                    result.AppendLine($"Successfully imported User {currentUserName}.");
                }
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportFollowers(InstagraphContext context, string jsonString)
        {
            var friendsFromJson = JsonConvert.DeserializeObject<UserFollowerDto[]>(jsonString);

            var result = new StringBuilder();

            var validFollowers = new List<UserFollower>();

            foreach (var obj in friendsFromJson)
            {
                int? userId = context.Users.FirstOrDefault(u => u.Username == obj.User)?.Id;
                int? followerId = context.Users.FirstOrDefault(u => u.Username == obj.Follower)?.Id;

                var isUserValid = userId != null;
                var isFollowerValid = followerId != null;
                var isAlreadyFollower = validFollowers
                            .Any(f => f.UserId == userId && f.FollowerId == followerId);

                if (isUserValid && isFollowerValid && !isAlreadyFollower)
                {
                    var currUserId = userId.Value;
                    var currFollowerId = followerId.Value;

                    var currentUserFollower = new UserFollower()
                    {
                        UserId = currUserId,
                        FollowerId = currFollowerId
                    };

                    validFollowers.Add(currentUserFollower);
                    result.AppendLine($"Successfully imported Follower {obj.Follower} to User {obj.User}.");
                }
                else
                {
                    result.AppendLine(errorMessage);
                }
            }

            context.UsersFollowers.AddRange(validFollowers);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportPosts(InstagraphContext context, string xmlString)
        {
            var result = new StringBuilder();

            var xmlDoc = XDocument.Parse(xmlString);

            var elements = xmlDoc.Root.Elements();

            var validPosts = new List<Post>();

            foreach (var element in elements)
            {
                string currCaption = element.Element("caption")?.Value;
                string currUserName = element.Element("user")?.Value;
                string currPicturePath = element.Element("picture")?.Value;

                int? userId = context.Users.FirstOrDefault(u => u.Username == currUserName)?.Id;
                int? pictureId = context.Pictures.FirstOrDefault(p => p.Path == currPicturePath)?.Id;

                if (userId != null && pictureId != null && !String.IsNullOrWhiteSpace(currCaption))
                {
                    var currentPost = new Post()
                    {
                        Caption = currCaption,
                        UserId = userId.Value,
                        PictureId = pictureId.Value
                    };

                    validPosts.Add(currentPost);
                    result.AppendLine($"Successfully imported Post {currCaption}.");
                }
                else
                {
                    result.AppendLine(errorMessage);
                }
            }

            context.Posts.AddRange(validPosts);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        public static string ImportComments(InstagraphContext context, string xmlString)
        {
            var result = new StringBuilder();

            var xmlDoc = XDocument.Parse(xmlString);

            var elements = xmlDoc.Root.Elements();

            var validComments = new List<Comment>();

            foreach (var element in elements)
            {
                string currContent = element.Element("content")?.Value;
                string currUserName = element.Element("user")?.Value;
                string currPostIdAsString = element.Element("post")?.Attribute("id")?.Value;
                int currPostId;
                if (!String.IsNullOrWhiteSpace(currContent) 
                    && !String.IsNullOrWhiteSpace(currUserName) 
                    && !String.IsNullOrWhiteSpace(currPostIdAsString)
                    && int.TryParse(currPostIdAsString, out currPostId))
                {
                    var userExist = context.Users.Any(u => u.Username == currUserName);
                    var postExist = context.Posts.Any(p => p.Id == currPostId);

                    if (userExist && postExist)
                    {
                        var newComment = new Comment()
                        {
                            UserId = context.Users.First(u => u.Username == currUserName).Id,
                            PostId = currPostId,
                            Content = currContent
                        };

                        validComments.Add(newComment);
                        result.AppendLine($"Successfully imported Comment {currContent}.");
                    }
                    else
                    {
                        result.AppendLine(errorMessage);
                    }
                }
                else
                {
                    result.AppendLine(errorMessage);
                }
            }

            context.Comments.AddRange(validComments);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }
    }
}
