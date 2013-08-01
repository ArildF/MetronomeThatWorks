using ReactiveUI;
using System;

namespace MetronomeThatWorks.ViewModels
{
	public class MainViewModel : ReactiveObject
	{
		private readonly IMetronome _metronome;
		private int _beatsPerMinute;
		private bool _showPlayButton;

		public MainViewModel(IMetronome metronome)
		{
			_metronome = metronome;
			BeatsPerMinute = 120;
			ShowPlayButton = true;

			TogglePlayCommand = new ReactiveCommand();
			TogglePlayCommand.Subscribe(_ => TogglePlay());
		}

		private void Stop()
		{
			
		}

		private void TogglePlay()
		{
			if (_metronome.IsPlaying)
			{
				_metronome.Stop();
				ShowPlayButton = true;
			}
			else
			{
				ShowPlayButton = false;
				_metronome.Start();
			}
		}

		public ReactiveCommand TogglePlayCommand
		{
			get; 
			private set; 
		}

		public ReactiveCommand StopCommand { get; private set; }

		public int BeatsPerMinute
		{
			get { return _beatsPerMinute; }
			set
			{
				if (value != _beatsPerMinute)
				{
					_beatsPerMinute = value;
					this.RaisePropertyChanged();
					_metronome.BeatsPerMinute = value;
				}
			}
		}

		public bool ShowPlayButton
		{
			get { return _showPlayButton; }
			set
			{
				this.RaiseAndSetIfChanged(ref _showPlayButton, value);
				this.RaisePropertyChanged("ShowPauseButton");
			}
		}

		public bool ShowPauseButton
		{
			get { return !ShowPlayButton; }
		}
	}
}
