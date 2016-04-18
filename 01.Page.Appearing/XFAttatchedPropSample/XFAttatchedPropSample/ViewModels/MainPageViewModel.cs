using Reactive.Bindings;
using System;

namespace XFAttatchedPropSample.ViewModels
{
	public class MainPageViewModel
	{
		public ReactiveProperty<String> Message { get; }

		public ReactiveCommand Loaded { get; }

		public MainPageViewModel()
		{
			Message = new ReactiveProperty<string>();

			Loaded = new ReactiveCommand();
			Loaded.Subscribe(_ =>
			{
				System.Diagnostics.Debug.WriteLine("Loaded");
				Message.Value = "Loaded";
			});
		}
	}
}
