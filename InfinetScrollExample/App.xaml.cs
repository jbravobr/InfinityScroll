using InfinetScrollExample.Views;
using Prism.Unity;

using Microsoft.Practices.Unity;

namespace InfinetScrollExample
{
	public class App : PrismApplication
	{
		protected override void OnInitialized()
		{
			NavigationService.NavigateAsync("HomePage");
		}

		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<HomePage>();

			Container.RegisterInstance(Acr.UserDialogs.UserDialogs.Instance);
		}
	}
}