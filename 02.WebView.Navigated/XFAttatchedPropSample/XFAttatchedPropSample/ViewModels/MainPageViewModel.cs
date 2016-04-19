using Reactive.Bindings;
using System;

namespace XFAttatchedPropSample.ViewModels
{
	public class MainPageViewModel
	{
		public ReactiveProperty<String> Message { get; }

		public ReactiveProperty<string> Url { get; }

		public ReactiveCommand Loaded { get; }
		public ReactiveCommand Navigated { get; }

		public MainPageViewModel()
		{
			Message = new ReactiveProperty<string>();
			Url = new ReactiveProperty<string>();

			Loaded = new ReactiveCommand();
			Loaded.Subscribe(_ =>
			{
				Message.Value = "Loaded";
				Url.Value = "https://github.com/";
			});

			Navigated = new ReactiveCommand();
			Navigated.Subscribe(_ => Message.Value += " Navigated");
		}
	}
}
