using System.Collections.Generic;
using ModPanel.Services.Models.Post;

namespace ModPanel.Services.Contracts
{
    public interface IPostService
    {
        bool Create(string title, string content, int authorId);

        IEnumerable<PostServiceModel> All();

        PostUpdateServiceModel GetById(int id);

        bool Update(int id, string title, string content);

        bool Delete(int id);
    }
}
