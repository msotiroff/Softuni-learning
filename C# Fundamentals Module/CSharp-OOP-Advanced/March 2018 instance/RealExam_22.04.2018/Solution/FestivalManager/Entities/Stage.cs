namespace FestivalManager.Entities
{
	using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class Stage : IStage
    {
        private List<ISong> songs;
        private List<ISet> sets;
        private List<IPerformer> performers;

        public Stage()
        {
            this.songs = new List<ISong>();
            this.sets = new List<ISet>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => this.sets.AsReadOnly();

        public IReadOnlyCollection<ISong> Songs => this.songs.AsReadOnly();

        public IReadOnlyCollection<IPerformer> Performers => this.performers.AsReadOnly();

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSet(ISet set)
        {
            this.sets.Add(set);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            var performer = this.Performers.FirstOrDefault(p => p.Name == name);

            if (!HasPerformer(name))
            {
                // TODO : throw
            }

            return performer;
        }

        public ISet GetSet(string name)
        {
            var set = this.Sets.FirstOrDefault(s => s.Name == name);

            if (!HasSet(name))
            {
                // TODO : throw
            }

            return set;
        }

        public ISong GetSong(string name)
        {
            var song = this.Songs.FirstOrDefault(s => s.Name == name);

            if (!HasSong(name))
            {
                // TODO : throw
            }

            return song;
        }

        public bool HasPerformer(string name)
        {
            return this.Performers.Any(p => p.Name == name);
        }

        public bool HasSet(string name)
        {
            return this.Sets.Any(s => s.Name == name);
        }

        public bool HasSong(string name)
        {
            return this.Songs.Any(s => s.Name == name);
        }
    }
}
