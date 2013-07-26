using MetronomeThatWorks.ViewModels;
using ReactiveUI;
using Windows.UI.Xaml;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace MetronomeThatWorks.Views
{
	public sealed partial class MainView : IViewFor<MainViewModel>
	{
		public MainView()
		{
			InitializeComponent();
		}

		public MainViewModel ViewModel
		{
			get { return (MainViewModel)GetValue(ViewModelProperty); }
			set { SetValue(ViewModelProperty, value); }
		}
		public static readonly DependencyProperty ViewModelProperty =
			DependencyProperty.Register("ViewModel", typeof(MainViewModel), typeof(MainView), new PropertyMetadata(null));


		object IViewFor.ViewModel
		{
			get { return ViewModel; }
			set { ViewModel = (MainViewModel) value; }
		}

	}
}
