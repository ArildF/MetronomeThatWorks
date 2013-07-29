using System;
using System.Reactive.Linq;

namespace MetronomeThatWorks.Domain
{
	public class Metronome : IMetronome 
	{
		private readonly ISoundPlayer _player;
		private IDisposable _subscription;

		private int _bpm;

		public Metronome(ISoundPlayer player)
		{
			_player = player;
		}

		public int BeatsPerMinute
		{
			get { return _bpm; }
			set
			{
				if (_bpm != value)
				{
					_bpm = value;
					if (Playing)
					{
						Start();
					}
				}
			}
		}

		protected bool Playing
		{
			get { return _subscription != null; }
		}

		public void Start()
		{
			Stop();
			_subscription = Observable.Interval(TimeSpan.FromSeconds((double)60/BeatsPerMinute))
			                          .ObserveOnDispatcher().Subscribe(_ => _player.Play());
		}

		public void Stop()
		{
			if (_subscription != null)
			{
				_subscription.Dispose();
				_subscription = null;
			}
		}
	}
}
