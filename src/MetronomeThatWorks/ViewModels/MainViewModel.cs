using ReactiveUI;
using System;

namespace MetronomeThatWorks.ViewModels
{
	public class MainViewModel : ReactiveObject
	{
		private int _beatsPerMinute;
		private bool _showPlayButton;

		public MainViewModel()
		{
			BeatsPerMinute = 120;
			ShowPlayButton = true;

			PlayCommand = new ReactiveCommand();
			PlayCommand.Subscribe(_ => ShowPlayButton = !ShowPlayButton);
		}

		public ReactiveCommand PlayCommand
		{
			get; 
			private set; 
		}

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
