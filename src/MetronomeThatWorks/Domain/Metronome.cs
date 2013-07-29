using System;
using System.Reactive.Linq;

namespace MetronomeThatWorks.Domain
{
	public class Metronome : IMetronome 
	{
		private readonly ISoundPlayer _player;
		private IDisposable _subscription;

		public Metronome(ISoundPlayer player)
		{
			_player = player;
		}

		public int BeatsPerMinute { get; set; }
		public void Start()
		{
			_subscription = Observable.Interval(TimeSpan.FromSeconds((double)60/BeatsPerMinute))
			                          .ObserveOnDispatcher().Subscribe(_ => _player.Play());
		}

		public void Stop()
		{
			if (_subscription != null)
			{
				_subscription.Dispose();
			}
		}
	}
}
