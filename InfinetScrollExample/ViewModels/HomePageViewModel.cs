using System;
using System.Collections.ObjectModel;
using Acr.UserDialogs;
using PropertyChanged;
using Xamarin.Forms;

namespace InfinetScrollExample.ViewModels
{
	[ImplementPropertyChanged]
	public class HomePageViewModel
	{
		public ObservableCollection<Number> Numbers { get; set; }
		public int LastPosition { get; set; } = 50;

		readonly IUserDialogs _userDialogs;

		public Command LoadMoreItens
		{
			get
			{
				return new Command(() =>
				{
					RandomList(50);
				});
			}
		}

		public HomePageViewModel(IUserDialogs userDialogs)
		{
			_userDialogs = userDialogs;

			RandomList();
		}

		void RandomList()
		{
			Numbers = new ObservableCollection<Number>();
			for (int i = 0; i < 50; i++)
			{
				Numbers.Add(new Number
				{
					Id = Guid.NewGuid(),
					Description = i.ToString()
				});
			}
		}

		void RandomList(int position)
		{
			_userDialogs.ShowLoading("Carregando mais registros");
			var max = LastPosition + position;

			for (int i = LastPosition; i < max; i++)
			{
				Numbers.Add(new Number
				{
					Id = Guid.NewGuid(),
					Description = i.ToString()
				});
			}

			LastPosition = max;
			_userDialogs.HideLoading();
		}
	}
}