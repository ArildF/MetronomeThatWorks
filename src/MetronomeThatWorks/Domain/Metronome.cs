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
					if (IsPlaying)
					{
						Start();
					}
				}
			}
		}

		public bool IsPlaying
		{
			get { return _subscription != null; }
		}


		public void Start()
		{
			Stop();
			_subscription = Observable.Generate(0, _ => true, it => it + 1, it => it,
				it => TimeSpan.FromSeconds((double)60 / BeatsPerMinute)).Select(it => it % 4 == 0)
				.ObserveOnDispatcher()
				.Subscribe(_player.Play);
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
