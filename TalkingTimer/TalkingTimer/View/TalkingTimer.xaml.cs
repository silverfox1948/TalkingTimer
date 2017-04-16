using TalkingTimer.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TalkingTimer.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TalkingTimer : ContentPage
	{

		public TalkingTimer()
		{
			InitializeComponent();
			this.BindingContext = new TalkingTimerViewModel();
		}
	}
}
