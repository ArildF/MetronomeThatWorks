namespace MetronomeThatWorks
{
	public interface ISoundPlayer
	{
		void Play();
	}

	public interface IMetronome
	{
		int BeatsPerMinute { get; set; }
		bool IsPlaying { get; }
		void Start();
		void Stop();
	}

}
