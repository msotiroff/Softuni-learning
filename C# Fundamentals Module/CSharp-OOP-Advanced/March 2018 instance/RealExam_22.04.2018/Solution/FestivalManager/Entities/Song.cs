namespace FestivalManager.Entities
{
	using System;
    using System.Globalization;
    using Contracts;

	public class Song : ISong
    {
		public Song(string name, TimeSpan duration)
		{
			this.Name = name;
			this.Duration = duration;
		}

		public string Name { get; }

	    public TimeSpan Duration { get; }

	    public override string ToString()
	    {
		    var result =  $"{this.Name} ({this.Duration.ToString("mm\\:ss", CultureInfo.InvariantCulture)})"; // TODO fix

            return result;
	    }
    }
}
