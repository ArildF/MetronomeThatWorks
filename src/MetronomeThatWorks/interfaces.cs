namespace MetronomeThatWorks
{
	public interface ISoundPlayer
	{
		void Play();
	}

	public interface IMetronome
	{
		int BeatsPerMinute { get; set; }
		void Start();
		void Stop();
	}

}
