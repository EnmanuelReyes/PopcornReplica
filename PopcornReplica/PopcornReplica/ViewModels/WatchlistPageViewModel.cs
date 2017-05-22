using System;
using PopcornReplica.Models;
using Prism.Mvvm;
using Prism.Navigation;

namespace PopcornReplica.ViewModels
{
	public class WatchlistPageViewModel : BindableBase, INavigationAware
	{
		public readonly INavigationService navService;

		public WatchlistPageViewModel(INavigationService navigationService)
		{
			navService = navigationService;

		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{
		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{
		}

		public void OnNavigatingTo(NavigationParameters parameters)
		{
		}

		public void ViewMovie(Movie movie)
		{
			System.Diagnostics.Debug.WriteLine("View Movieee");
			NavigationParameters navParams = new NavigationParameters();
			navParams.Add("movie", movie);
			navService.NavigateAsync("MoviePage", navParams);
				
		}
	}
}
