using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace XFAttatchedPropSample.Views
{
	/// <summary>
	/// 添付プロパティクラス
	/// </summary>
	public class AttachedProp
	{
		#region Page.Appearing
		/// <summary>
		/// Appearing コマンドプロパティ
		/// </summary>
		public static readonly BindableProperty AppearingCommandProperty =
			BindableProperty.CreateAttached(
				"AppearingCommand",                     // プロパティ名
				typeof(ICommand),                       // プロパティの型
				typeof(Page),                           // 添付対象の型
				null,
				BindingMode.OneWay,                     // デフォルト BindingMode
				null,
				OnAppearingCommandPropertyChanged,      // プロパティが変更された時に呼び出されるデリゲート
				null,
				null);

		/// <summary>
		/// Appearing コマンドプロパティの getter
		/// </summary>
		/// <param name="bindable">バインド対象オブジェクト</param>
		/// <returns>プロパティの値</returns>
		public static ICommand GetAppearingCommand(BindableObject bindable)
		{
			return (ICommand)bindable.GetValue(AttachedProp.AppearingCommandProperty);
		}

		/// <summary>
		/// Appearing コマンドプロパティの setter
		/// </summary>
		/// <param name="bindable">バインド対象オブジェクト</param>
		/// <param name="value">プロパティに設定する値</param>
		public static void SetAppearingCommand(BindableObject bindable, Command value)
		{
			bindable.SetValue(AttachedProp.AppearingCommandProperty, value);
		}

		/// <summary>
		/// Appearing コマンドプロパティ変更
		/// </summary>
		/// <param name="bindable">バインド対象オブジェクト</param>
		/// <param name="oldValue">変更前の値</param>
		/// <param name="newValue">変更後の値</param>
		public static void OnAppearingCommandPropertyChanged(BindableObject bindable, Object oldValue, Object newValue)
		{
			var page = bindable as Page;
			if (page == null)
			{
				return;
			}

			if (newValue != null)
			{
				page.Appearing += Page_Appearing;
			}
			else
			{
				page.Appearing -= Page_Appearing;
			}
		}

		/// <summary>
		/// Appearing イベント発生
		/// </summary>
		/// <param name="sender">送信元オブジェクト</param>
		/// <param name="e">イベント引数</param>
		private static void Page_Appearing(object sender, EventArgs e)
		{
			var command = GetAppearingCommand(sender as BindableObject);
			if (command != null)
			{
				if (command.CanExecute(e))
				{
					command.Execute(e);
				}
			}
		}
		#endregion

		#region Page.Disappearing
		/// <summary>
		/// Disappearing コマンドプロパティ
		/// </summary>
		public static readonly BindableProperty DisappearingCommandProperty =
			BindableProperty.CreateAttached(
				"DisappearingCommand",                  // プロパティ名
				typeof(ICommand),                       // プロパティの型
				typeof(Page),                           // 添付対象の型
				null,
				BindingMode.OneWay,                     // デフォルト BindingMode
				null,
				OnDisappearingCommandPropertyChanged,   // プロパティが変更された時に呼び出されるデリゲート
				null,
				null);

		/// <summary>
		/// Disappearing コマンドプロパティの getter
		/// </summary>
		/// <param name="bindable">バインド対象オブジェクト</param>
		/// <returns>プロパティの値</returns>
		public static ICommand GetDisappearingCommand(BindableObject bindable)
		{
			return (ICommand)bindable.GetValue(AttachedProp.DisappearingCommandProperty);
		}

		/// <summary>
		/// Disappearing コマンドプロパティの setter
		/// </summary>
		/// <param name="bindable">バインド対象オブジェクト</param>
		/// <param name="value">プロパティに設定する値</param>
		public static void SetDisappearingCommand(BindableObject bindable, Command value)
		{
			bindable.SetValue(AttachedProp.DisappearingCommandProperty, value);
		}

		/// <summary>
		/// Disappearing コマンドプロパティ変更
		/// </summary>
		/// <param name="bindable">バインド対象オブジェクト</param>
		/// <param name="oldValue">変更前の値</param>
		/// <param name="newValue">変更後の値</param>
		public static void OnDisappearingCommandPropertyChanged(BindableObject bindable, Object oldValue, Object newValue)
		{
			var page = bindable as Page;
			if (page == null)
			{
				return;
			}

			if (newValue != null)
			{
				page.Disappearing += Page_Disappearing;
			}
			else
			{
				page.Disappearing -= Page_Disappearing;
			}
		}

		/// <summary>
		/// Disappearing イベント発生
		/// </summary>
		/// <param name="sender">送信元オブジェクト</param>
		/// <param name="e">イベント引数</param>
		private static void Page_Disappearing(object sender, EventArgs e)
		{
			var command = GetDisappearingCommand(sender as BindableObject);
			if (command != null)
			{
				if (command.CanExecute(e))
				{
					command.Execute(e);
				}
			}
		}
		#endregion

		#region WebView.Navigating
		/// <summary>
		/// Navigating コマンドプロパティ
		/// </summary>
		public static readonly BindableProperty NavigatingCommandProperty =
			BindableProperty.CreateAttached(
				"NavigatingCommand",                    // プロパティ名
				typeof(ICommand),                       // プロパティの型
				typeof(WebView),                        // 添付対象の型
				null,
				BindingMode.OneWay,                     // デフォルト BindingMode
				null,
				OnNavigatingCommandPropertyChanged,     // プロパティが変更された時に呼び出されるデリゲート
				null,
				null);

		/// <summary>
		/// Navigating コマンドプロパティの getter
		/// </summary>
		/// <param name="bindable">バインド対象オブジェクト</param>
		/// <returns>プロパティの値</returns>
		public static ICommand GetNavigatingCommand(BindableObject bindable)
		{
			return (ICommand)bindable.GetValue(AttachedProp.NavigatingCommandProperty);
		}

		/// <summary>
		/// Navigating コマンドプロパティの setter
		/// </summary>
		/// <param name="bindable">バインド対象オブジェクト</param>
		/// <param name="value">プロパティに設定する値</param>
		public static void SetNavigatingCommand(BindableObject bindable, Command value)
		{
			bindable.SetValue(AttachedProp.NavigatingCommandProperty, value);
		}

		/// <summary>
		/// Navigating コマンドプロパティ変更
		/// </summary>
		/// <param name="bindable">バインド対象オブジェクト</param>
		/// <param name="oldValue">変更前の値</param>
		/// <param name="newValue">変更後の値</param>
		public static void OnNavigatingCommandPropertyChanged(BindableObject bindable, Object oldValue, Object newValue)
		{
			var webView = bindable as WebView;
			if (webView == null)
			{
				return;
			}

			if (newValue != null)
			{
				webView.Navigating += WebView_Navigating;
			}
			else
			{
				webView.Navigating -= WebView_Navigating;
			}
		}

		/// <summary>
		/// Navigating イベント発生
		/// </summary>
		/// <param name="sender">送信元オブジェクト</param>
		/// <param name="e">イベント引数</param>
		private static void WebView_Navigating(object sender, WebNavigatingEventArgs e)
		{
			var command = GetNavigatingCommand(sender as BindableObject);
			if (command != null)
			{
				if (command.CanExecute(e))
				{
					command.Execute(e);
				}
			}
		}
		#endregion

		#region WebView.Navigated
		/// <summary>
		/// Navigated コマンドプロパティ
		/// </summary>
		public static readonly BindableProperty NavigatedCommandProperty =
			BindableProperty.CreateAttached(
				"NavigatedCommand",                     // プロパティ名
				typeof(ICommand),                       // プロパティの型
				typeof(WebView),                        // 添付対象の型
				null,
				BindingMode.OneWay,                     // デフォルト BindingMode
				null,
				OnNavigatedCommandPropertyChanged,      // プロパティが変更された時に呼び出されるデリゲート
				null,
				null);

		/// <summary>
		/// Navigated コマンドプロパティの getter
		/// </summary>
		/// <param name="bindable">バインド対象オブジェクト</param>
		/// <returns>プロパティの値</returns>
		public static ICommand GetNavigatedCommand(BindableObject bindable)
		{
			return (ICommand)bindable.GetValue(AttachedProp.NavigatedCommandProperty);
		}

		/// <summary>
		/// Navigated コマンドプロパティの setter
		/// </summary>
		/// <param name="bindable">バインド対象オブジェクト</param>
		/// <param name="value">プロパティに設定する値</param>
		public static void SetNavigatedCommand(BindableObject bindable, Command value)
		{
			bindable.SetValue(AttachedProp.NavigatedCommandProperty, value);
		}

		/// <summary>
		///  Navigated コマンドプロパティ変更
		/// </summary>
		/// <param name="bindable">バインド対象オブジェクト</param>
		/// <param name="oldValue">変更前の値</param>
		/// <param name="newValue">変更後の値</param>
		public static void OnNavigatedCommandPropertyChanged(BindableObject bindable, Object oldValue, Object newValue)
		{
			var webView = bindable as WebView;
			if (webView == null)
			{
				return;
			}

			if (newValue != null)
			{
				webView.Navigated += WebView_Navigated;
			}
			else
			{
				webView.Navigated -= WebView_Navigated;
			}
		}

		/// <summary>
		/// Navigated イベント発生
		/// </summary>
		/// <param name="sender">送信元オブジェクト</param>
		/// <param name="e">イベント引数</param>
		private static void WebView_Navigated(object sender, WebNavigatedEventArgs e)
		{
			var command = GetNavigatedCommand(sender as BindableObject);
			if (command != null)
			{
				if (command.CanExecute(e))
				{
					command.Execute(e);
				}
			}
		}
		#endregion
	}
}
