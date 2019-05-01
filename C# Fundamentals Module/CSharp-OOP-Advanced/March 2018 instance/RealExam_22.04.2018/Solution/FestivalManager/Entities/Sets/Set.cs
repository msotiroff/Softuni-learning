namespace FestivalManager.Entities.Sets
{
	using System;
	using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
	using System.Text;

	using Contracts;

	public abstract class Set : ISet
	{
        private const string SongsPlayedMessage = "--Songs played:";
        private const string NoSongsPlayedMessage = "--No songs played";
        private const string MaxDurationOberflowErrorMsg = "Song is over the set limit!";
        private const string SetInfo = "--{0} ({1}):";
        private const string TimeFormat = "mm\\:ss";
        
        private readonly List<IPerformer> performers;
		private readonly List<ISong> songs;

		protected Set(string name)
		{
			this.Name = name;

			this.performers = new List<IPerformer>();
			this.songs = new List<ISong>();
		}

		public string Name { get; }

		public abstract TimeSpan MaxDuration { get; }

		public TimeSpan ActualDuration => new TimeSpan(this.Songs.Sum(s => s.Duration.Ticks));

		public IReadOnlyCollection<IPerformer> Performers => this.performers.AsReadOnly();

        public IReadOnlyCollection<ISong> Songs => this.songs.AsReadOnly();

		public void AddPerformer(IPerformer performer) => this.performers.Add(performer);

		public void AddSong(ISong song)
		{
			if (song.Duration + this.ActualDuration > this.MaxDuration)
			{
				throw new InvalidOperationException(MaxDurationOberflowErrorMsg);
			}

			this.songs.Add(song);
		}

		public bool CanPerform()
		{
			if (this.Performers.Count < 1)
			{
				return false;
			}

			if (this.Songs.Count < 1)
			{
				return false;
			}

			var allPerformersHaveInstruments = this.Performers.All(p => p.Instruments.Any(i => !i.IsBroken));

			if (!allPerformersHaveInstruments)
			{
				return false;
			}

			return true;
		}

		public override string ToString()
		{
            var minutes = this.ActualDuration.Hours * 60 + this.ActualDuration.Minutes;
            var seconds = this.ActualDuration.Seconds;

            var setTime = $"{minutes:00}:{seconds:00}";

            string setSummary = string.Format(SetInfo, this.Name, setTime);

            var sb = new StringBuilder()
                .AppendLine(setSummary);


            var performersOrdered = this.Performers.OrderByDescending(p => p.Age).ToArray();

            foreach (var performer in performersOrdered)
            {
                sb.AppendLine(performer.ToString());
            }

            if (this.Songs.Any())
            {
                sb.AppendLine(SongsPlayedMessage);
            }
            else
            {
                sb.AppendLine(NoSongsPlayedMessage);
            }

            foreach (var song in this.Songs)
            {
                sb.AppendLine($"----{song.ToString()}");
            }

			var result = sb.ToString().Trim();
			return result;
		}
	}
}
