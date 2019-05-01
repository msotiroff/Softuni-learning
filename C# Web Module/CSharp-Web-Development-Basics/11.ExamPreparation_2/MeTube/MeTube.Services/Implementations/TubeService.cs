namespace MeTube.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using MeTube.Data;
    using MeTube.Models;
    using MeTube.Services.Models.Tube;

    public class TubeService : DataAccessService, ITubeService
    {
        public TubeService(MeTubeDbContext db) 
            : base(db)
        {
        }

        public IEnumerable<TubeListServiceModel> All()
        {
            return this.db
                .Tubes
                .ProjectTo<TubeListServiceModel>()
                .ToArray();
        }

        public TubeDetailsServiceModel GetById(int id)
        {
            var tube = this.db.Tubes.Find(id);
            if (tube == null)
            {
                return null;
            }

            tube.Views++;
            this.db.Tubes.Update(tube);
            this.db.SaveChanges();

            return Mapper.Map<TubeDetailsServiceModel>(tube);
        }

        public int Upload(string title, string description, string author, int uploaderId, string youTubeId)
        {
            var tube = new Tube
            {
                Title = title,
                Description = description,
                Author = author,
                UploaderId = uploaderId,
                YouTubeId = youTubeId
            };

            if (!this.ValidateModelState(tube))
            {
                return default(int);
            }

            this.db.Tubes.Add(tube);
            this.db.SaveChanges();

            return tube.Id;
        }
    }
}
