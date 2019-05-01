using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Social_Media_Posts
{
    class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> socialMedia =
                new Dictionary<string, Dictionary<string, List<string>>>();


            string[] input = Console.ReadLine().Split(' ').ToArray();

            while (input[0] != "drop")
            {
                string currentCommand = input[0];
                string currentPost = input[1];

                if (currentCommand == "post")
                {
                    if (!socialMedia.ContainsKey(currentPost))
                    {
                        socialMedia[currentPost] = new Dictionary<string, List<string>>();
                        socialMedia[currentPost]["Likes"] = new List<string>();
                        socialMedia[currentPost]["Dislikes"] = new List<string>();
                    }
                }
                else if (currentCommand == "like")
                {
                    socialMedia[currentPost]["Likes"].Add("likeOnce");
                }
                else if (currentCommand == "dislike")
                {
                    socialMedia[currentPost]["Dislikes"].Add("dislikeOnce");
                }
                else if (currentCommand == "comment")
                {
                    string currentName = input[2];
                    socialMedia[currentPost][currentName] = new List<string>();
                    for (int i = 3; i < input.Length; i++)
                    {
                        socialMedia[currentPost][currentName].Add(input[i]);
                    }
                }

                input = Console.ReadLine().Split(' ').ToArray();
            }

            PrintResult(socialMedia);
        }

        public static void PrintResult(Dictionary<string, Dictionary<string, List<string>>> socialMedia)
        {
            foreach (var post in socialMedia)
            {
                int likes = 0;
                int dislikes = 0;
                var commentators = post.Value;
                foreach (var item in post.Value)
                {
                    if (item.Key == "Likes")
                    {
                        likes = item.Value.Count();
                    }
                    else if (item.Key == "Dislikes")
                    {
                        dislikes = item.Value.Count();
                    }
                }
                Console.WriteLine($"Post: {post.Key} | Likes: {likes} | Dislikes: {dislikes}");
                Console.WriteLine("Comments:");

                bool withoutComments = true;
                foreach (var commentator in commentators)
                {
                    if (commentator.Key != "Likes" && commentator.Key != "Dislikes")
                    {
                        Console.WriteLine($"*  {commentator.Key}: {string.Join(" ", commentator.Value)}");
                        withoutComments = false;
                    }
                }
                if (withoutComments)
                {
                    Console.WriteLine("None");
                }
            }
        }
    }
}
