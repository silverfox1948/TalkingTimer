/*
Copyright 2017 Steven Archibald Consulting Corporation

Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

	 http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

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
