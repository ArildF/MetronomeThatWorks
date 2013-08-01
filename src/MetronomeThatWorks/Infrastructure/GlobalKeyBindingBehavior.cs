using System.Windows.Input;
using WinRtBehaviors;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace MetronomeThatWorks.Infrastructure
{
	public class GlobalKeyBindingBehavior : Behavior<FrameworkElement>
	{
		public static readonly DependencyProperty KeyProperty;



		public VirtualKey Key
		{
			get { return (VirtualKey) GetValue(KeyProperty); }
			set { SetValue(KeyProperty, value); }
		}




		public static readonly DependencyProperty CommandProperty;

		static GlobalKeyBindingBehavior()
		{
			CommandProperty = DependencyProperty.Register("Command", typeof (ICommand),
				typeof (GlobalKeyBindingBehavior), new PropertyMetadata(null));
			KeyProperty = DependencyProperty.Register("Key", typeof (VirtualKey), typeof (GlobalKeyBindingBehavior),
				new PropertyMetadata(VirtualKey.None));
		}


		public ICommand Command
		{
			get { return (ICommand) GetValue(CommandProperty); }
			set { SetValue(CommandProperty, value); }
		}


		protected override void OnAttached()
		{
			base.OnAttached();
			Window.Current.CoreWindow.KeyDown += CoreWindowOnKeyDown;
		}

		private void CoreWindowOnKeyDown(CoreWindow sender, KeyEventArgs args)
		{
			if (args.VirtualKey == Key && Command != null && Command.CanExecute(null))
			{
				Command.Execute(null);
			}
			
		}
	}
}
