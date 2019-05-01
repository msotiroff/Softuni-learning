namespace MeTube.Services.Contracts
{
    using MeTube.Services.Models.Tube;
    using System.Collections.Generic;

    public interface ITubeService
    {
        int Upload(string title, string description, string author, int uploaderId, string youTubeId);

        IEnumerable<TubeListServiceModel> All();

        TubeDetailsServiceModel GetById(int id);
    }
}
