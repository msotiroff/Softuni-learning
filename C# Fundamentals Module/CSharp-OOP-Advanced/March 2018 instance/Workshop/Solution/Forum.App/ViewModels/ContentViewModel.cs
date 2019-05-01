namespace Forum.App.Models.ViewModels
{
    using Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class ContentViewModel : IContentViewModel
    {
        private const int lineLength = 37;

        public ContentViewModel(string content)
        {
            this.Content = this.GetLines(content);
        }

        public string[] Content { get; }

        private string[] GetLines(string content)
        {
            var textAsCharArr = content.ToCharArray();

            ICollection<string> lines = new List<string>();

            for (int i = 0; i < content.Length; i++)
            {
                var currentLine = textAsCharArr
                    .Skip(i * lineLength)
                    .Take(lineLength)
                    .ToArray();

                var lineAsText = string.Join(string.Empty, currentLine);

                lines.Add(lineAsText);
            }

            return lines.ToArray();
        }
    }
}
