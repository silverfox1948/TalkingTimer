using System;
using TalkingTimer.PlatformContracts;
using TalkingTimer.UWP.Implementations;
using Windows.UI.Xaml.Controls;

[assembly: Xamarin.Forms.Dependency(typeof(TextToSpeechImplementation))]
namespace TalkingTimer.UWP.Implementations
{
	public class TextToSpeechImplementation : ITextToSpeech
	{
		public TextToSpeechImplementation() { }

		public async void Speak(string text)
		{
			var mediaElement = new MediaElement();
			var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
			var stream = await synth.SynthesizeTextToStreamAsync(text);

			mediaElement.SetSource(stream, stream.ContentType);
			mediaElement.Play();
		}
	}
}
