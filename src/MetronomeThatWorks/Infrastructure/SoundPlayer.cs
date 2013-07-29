using System;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;

namespace MetronomeThatWorks.Infrastructure
{
	public class SoundPlayer : ISoundPlayer
	{
		private readonly MediaElement _mediaElement;
		private IRandomAccessStream _audio;

		public SoundPlayer()
		{
			_mediaElement = new MediaElement();
		}
		
		public async void Play()
		{
			if (_audio == null)
			{
				var file = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(
					new Uri("ms-appx:///Assets/Sounds/Tock.wav"));
				_audio = await file.OpenAsync(FileAccessMode.Read);
			}
			_mediaElement.SetSource(_audio, "audio/wav");
			_mediaElement.Play();
		}
	}
}
