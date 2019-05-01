namespace FestivalManager.Core.Controllers
{
	using System;
    using System.Collections.Generic;
    using System.Globalization;
	using System.Linq;
	using System.Text;
	using Contracts;
	using Entities.Contracts;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
	{
        private const string InvalidSetErrorMsg = "Invalid set provided";
        private const string InvalidSongErrorMsg = "Invalid song provided";
        private const string InvalidPerformerErrorMsg = "Invalid performer provided";

        private const string RegisterSetMessage = "Registered {0} set";
        private const string SignUpPerformerMessage = "Registered performer {0}";
        private const string RegisterSongMessage = "Registered song {0} ({1})";
        private const string SongAddedToSetMessage = "Added {0} ({1}) to {2}";
        private const string PerformerAddedToSetMessage = "Added {0} to {1}";
        private const string InstrumentsRepairedMessage = "Repaired {0} instruments";
        private const string ResultsMessage = "Results:";
        private const string FestivalSummaryMessage = "Festival length: {0}";

        private const int InstrumentMinLevelOfWearToBeRepaired = 100;
        private const string TimeFormat = "mm\\:ss";
        //private const string TimeFormatLong = "{0:2D}:{1:2D}";
        //private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

        private IStage stage;
        private ISetFactory setFactory;
        private ISongFactory songFactory;
        private IPerformerFactory performerFactory;
        private IInstrumentFactory instrumentFactory;

		public FestivalController(IStage stage, ISetFactory setFactory, 
            ISongFactory songFactory, IPerformerFactory performerFactory, 
            IInstrumentFactory instrumentFactory)
		{
			this.stage = stage;
            this.setFactory = setFactory;
            this.songFactory = songFactory;
            this.performerFactory = performerFactory;
            this.instrumentFactory = instrumentFactory;
		}

		
		public string RegisterSet(string[] args)
		{
            var setName = args[0];
            var setType = args[1];

            var set = this.setFactory.CreateSet(setName, setType);

            this.stage.AddSet(set);

            var result = string.Format(RegisterSetMessage, setType);

            return result;
        }

		public string SignUpPerformer(string[] args)
		{
            var name = args[0];
            var age = int.Parse(args[1]);
            var instrumentsTypes = args.Skip(2).ToList();

            var performer = this.performerFactory.CreatePerformer(name, age);
            
            foreach (var instrumentType in instrumentsTypes)
            {
                var currentInstrument = this.instrumentFactory.CreateInstrument(instrumentType);
                performer.AddInstrument(currentInstrument);
            }

            this.stage.AddPerformer(performer);

            var result = string.Format(SignUpPerformerMessage, name);

            return result;
		}

		public string RegisterSong(string[] args)
		{
            var name = args[0];
            var time = args[1].Split(':');
            var hours = int.Parse(time[0]) / 60;
            var minutes = int.Parse(time[0]) % 60;
            var seconds = int.Parse(time[1]);

            var songLength = new TimeSpan(hours, minutes, seconds);

            var song = this.songFactory.CreateSong(name, songLength);

            this.stage.AddSong(song);

            var timeAsString = song.Duration.ToString(TimeFormat, CultureInfo.InvariantCulture);

            var result = string.Format(RegisterSongMessage, name, timeAsString);

            return result;
        }
        
		public string AddPerformerToSet(string[] args)
		{
            var performerName = args[0];
            var setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException(InvalidPerformerErrorMsg);
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException(InvalidSetErrorMsg);
            }
            
            var performer = this.stage.GetPerformer(performerName);
            var set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            var result = string.Format(PerformerAddedToSetMessage, performerName, setName);

            return result;
        }
        
		public string RepairInstruments(string[] args)
		{
			var instrumentsToRepair = this.stage.Performers
				.SelectMany(p => p.Instruments)
				.Where(i => i.Wear < InstrumentMinLevelOfWearToBeRepaired)
				.ToArray();

			foreach (var instrument in instrumentsToRepair)
			{
				instrument.Repair();
			}

            var result = string.Format(InstrumentsRepairedMessage, instrumentsToRepair.Length);

            return result;
		}

        public string ProduceReport()
        {
            var festivalTotalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            var minutes = festivalTotalLength.Hours * 60 + festivalTotalLength.Minutes;
            var seconds = festivalTotalLength.Seconds;

            var festivalTime = $"{minutes:00}:{seconds:00}";

            var festivalSummary = string.Format(FestivalSummaryMessage, festivalTime);

            var builder = new StringBuilder()
                .AppendLine(ResultsMessage)
                .AppendLine(festivalSummary);

            foreach (var set in this.stage.Sets)
            {
                builder.AppendLine(set.ToString());
            }

            var result = builder.ToString().Trim();

            return result;
        }

        public string AddSongToSet(string[] args)
        {
            var songName = args[0];
            var setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException(InvalidSetErrorMsg);
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException(InvalidSongErrorMsg);
            }

            var set = this.stage.GetSet(setName);
            var song = this.stage.GetSong(songName);

            set.AddSong(song);

            var songLength = song.Duration.ToString(TimeFormat, CultureInfo.InvariantCulture);

            return string.Format(SongAddedToSetMessage, songName, songLength, setName);
        }
    }
}