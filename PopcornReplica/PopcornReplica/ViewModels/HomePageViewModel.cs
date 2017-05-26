using System;
using System.Collections.Generic;
using System.ComponentModel;
using PopcornReplica.Models;
using Prism.Mvvm;
using Prism.Navigation;

namespace PopcornReplica.ViewModels
{
	public class HomePageViewModel : BindableBase, INotifyPropertyChanged
	{

		public readonly INavigationService navService;

		public HomePageViewModel()
		{

		}
		public HomePageViewModel(INavigationService navigationService)
		{
			navService = navigationService;
		}



		internal void ViewTop(Top top)
		{
			NavigationParameters navParams = new NavigationParameters();
			navParams.Add("top", top);
			navService.NavigateAsync("SwipePage", navParams);
		}
	}
}
