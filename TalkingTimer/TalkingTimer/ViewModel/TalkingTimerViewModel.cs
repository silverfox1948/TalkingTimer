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

using TalkingTimer.PlatformContracts;
using System;
using System.Threading;
using System.Windows.Input;
using Xamarin.Forms;

namespace TalkingTimer.ViewModel
{
	public class TalkingTimerViewModel : BaseViewModel
	{
		private bool keepRunning = false;
		private TimeSpan countInterval = TimeSpan.FromSeconds(1);

		//public event PropertyChangedEventHandler PropertyChanged;
		public ICommand StartPauseResumeTimer { get; protected set; }
		public ICommand StopTimer { get; protected set; }
		public ICommand ResetTimer { get; protected set; }

		public int CountInterval { get; set; }

		private string _StartButtonText = "Start";
		public string StartButtonText
		{
			get { return _StartButtonText; }
			set
			{
				if (_StartButtonText != value)
				{
					_StartButtonText = value;
					OnPropertyChanged("StartButtonText");
				}
			}
		}

		private int _ElapsedSeconds = 0;
		public int ElapsedSeconds
		{
			get { return _ElapsedSeconds; }
			set
			{
				if (_ElapsedSeconds != value)
				{
					_ElapsedSeconds = value;
					OnPropertyChanged("ElapsedSeconds");
				}
			}
		}

		public TalkingTimerViewModel()
		{
			CountInterval = 10;
			StartPauseResumeTimer = new Command(() => ExecStartPauseResumeTimer());
			StopTimer = new Command(() => ExecStopTimer());
			ResetTimer = new Command(() => ExecResetTimer());
		}

		public void ExecStartPauseResumeTimer()
		{
			switch (StartButtonText)
			{
				case "Start":
					{
						ElapsedSeconds = 0;
						keepRunning = true;
						StartButtonText = "Pause";
						Device.StartTimer(countInterval, () => { DisplayElapsedSeconds(); return keepRunning; });
						break;
					}
				case "Pause":
					{
						keepRunning = false;
						StartButtonText = "Resume";
						break;
					}
				case "Resume":
					{
						keepRunning = true;
						StartButtonText = "Pause";
						Device.StartTimer(countInterval, () => { DisplayElapsedSeconds(); return keepRunning; });
						break;
					}
				default:
					{
						break;
					}
			}
		}

		public void ExecStopTimer()
		{
			keepRunning = false;
			StartButtonText = "Start";
		}

		public void ExecResetTimer()
		{
			keepRunning = false;
			StartButtonText = "Start";
			Device.StartTimer(countInterval, () => { ElapsedSeconds = 0; return keepRunning; });
		}

		public void DisplayElapsedSeconds()
		{
			ElapsedSeconds = ElapsedSeconds + 1;
			if (ElapsedSeconds % CountInterval == 0)
			{
				SpeakSeconds();
			}
		}

		private void SpeakSeconds()
		{
			DependencyService.Get<ITextToSpeech>().Speak(ElapsedSeconds.ToString());
		}
	}
}
