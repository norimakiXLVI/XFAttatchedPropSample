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
	}
}
