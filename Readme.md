# Talking Timer
This a very simple app. It's a timer that you start, and every 10 seconds, it "speaks" the number of elapsed seconds. It allows you to pause/restart the timer, reset the timer, and stop the timer.

If you pause the timer, and restart it, the counting continues from where it was paused. 

This is actually my first Xamarin "published" app. I haven't bothered to put it in the Google or Windows store yet, because it's really just a pre-cursor to another app that I will be publishing later. The app here is more of a proof of concept to ensure that I could feasibly make the final app.

This is implemented as a Xamarin.Forms app using the PCL approach rather than shared code. It has two platform instances - Windows UWP & Android. I didn't provide the iPhone version simply because I don't have an Apple device for compilation - and am unlikely to get one for a while. There's a link below in the Resources section that will take you to some of the code I used that also has an iPhone implementation. You can use that if you need the Apple stuff.

### Built Using ...
This uses the MvvmLightLib NuGet plug-in provided [here](http://www.mvvmlight.net/installing/nuget/) by Laurent Guignion (GalaSoft).

While re-researching the text-to-speech page I originally found, I discovered someone actually has a NuGet package that implements text-to-speech. It's documented in the Resources section. I decided not to use it, because I wanted to implement something myself just as a learning exercise. When I do my "final" app, I probably will use it, as the demo indicates it adds a lot of functionality that I'm not interested in building. I want to build my app, and just use other folks tools. 

Although it's a very simple app, I did take the MVVM approach, so there's a ViewModel, command relays, etc.

This is all very similar to the limited amount of WPF programming I've done in the past.

Finally, I did update ALL my NuGet packages before starting my coding. You might have to as well. This was built using Visual Studio 2017 Community edition.

### Resources
[Implementing Text To Speech](https://developer.xamarin.com/guides/xamarin-forms/application-fundamentals/dependency-service/text-to-speech/)

[Potential Library to avoid the above ...](https://github.com/jamesmontemagno/TextToSpeechPlugin)