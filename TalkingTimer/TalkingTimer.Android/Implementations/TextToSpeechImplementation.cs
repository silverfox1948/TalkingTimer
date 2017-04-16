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

using Android.Speech.Tts;
using TalkingTimer.Droid.Implementations;
using TalkingTimer.PlatformContracts;
using System.Collections.Generic;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(TextToSpeechImplementation))]
namespace TalkingTimer.Droid.Implementations
{
	public class TextToSpeechImplementation : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
	{
		TextToSpeech speaker;
		string toSpeak;

		public TextToSpeechImplementation() { }

		public void Speak(string text)
		{
			var ctx = Forms.Context; // useful for many Android SDK features
			toSpeak = text;
			if (speaker == null)
			{
				speaker = new TextToSpeech(ctx, this);
			}
			else
			{
				var p = new Dictionary<string, string>();
				speaker.Speak(toSpeak, QueueMode.Flush, p);
			}
		}

		public void OnInit(OperationResult status)
		{
			if (status.Equals(OperationResult.Success))
			{
				var p = new Dictionary<string, string>();
				speaker.Speak(toSpeak, QueueMode.Flush, p);
			}
		}
	}
}