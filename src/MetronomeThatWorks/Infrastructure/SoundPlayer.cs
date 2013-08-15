using System;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;

namespace MetronomeThatWorks.Infrastructure
{
	public class SoundPlayer : ISoundPlayer
	{
		private readonly MediaElement _mediaElement;
		private IRandomAccessStream _tock;
		private IRandomAccessStream _tick;

		public SoundPlayer()
		{
			_mediaElement = new MediaElement();
		}
		
		public async void Play(bool tick)
		{
			if (_tock == null)
			{
				var tockFile = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(
					new Uri("ms-appx:///Assets/Sounds/Tock.mp3"));
				var tickFile = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(
					new Uri("ms-appx:///Assets/Sounds/Tick.mp3"));
				_tock = await tockFile.OpenAsync(FileAccessMode.Read);
				_tick = await tickFile.OpenAsync(FileAccessMode.Read);
			}
			_mediaElement.SetSource(tick ? _tick : _tock, "audio/mp3");
			_mediaElement.Play();
		}
	}
}
