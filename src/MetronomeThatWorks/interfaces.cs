namespace MetronomeThatWorks
{
	public interface ISoundPlayer
	{
		void Play(bool tick);
	}

	public interface IMetronome
	{
		int BeatsPerMinute { get; set; }
		bool IsPlaying { get; }
		void Start();
		void Stop();
	}

}
