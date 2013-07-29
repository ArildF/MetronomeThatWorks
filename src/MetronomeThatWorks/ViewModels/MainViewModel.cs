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

			PlayCommand = new ReactiveCommand();
			PlayCommand.Subscribe(_ => Play());
			StopCommand = new ReactiveCommand();
			StopCommand.Subscribe(_ => Stop());
		}

		private void Stop()
		{
			_metronome.Stop();
			ShowPlayButton = true;
		}

		private void Play()
		{
			ShowPlayButton = false;
			_metronome.BeatsPerMinute = BeatsPerMinute;
			_metronome.Start();
		}

		public ReactiveCommand PlayCommand
		{
			get; 
			private set; 
		}

		public ReactiveCommand StopCommand { get; private set; }

		public int BeatsPerMinute
		{
			get { return _beatsPerMinute; }
			set { this.RaiseAndSetIfChanged(ref _beatsPerMinute, value); }
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
