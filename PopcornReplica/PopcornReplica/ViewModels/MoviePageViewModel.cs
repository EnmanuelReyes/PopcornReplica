using System;
using PopcornReplica.Models;
using Prism.Mvvm;
using Prism.Navigation;

namespace PopcornReplica.ViewModels
{
	public class MoviePageViewModel : BindableBase, INavigationAware
	{
		private Movie _movie;

		public Movie Movie
		{
			get { return _movie; }
			set { SetProperty(ref _movie, value); }
		}

		public MoviePageViewModel()
		{
			Movie = new Movie { Id = 1, Name="Run Forrest Run", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum" };
		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{
			throw new NotImplementedException();
		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{
			throw new NotImplementedException();
		}

		public void OnNavigatingTo(NavigationParameters parameters)
		{
			Movie movie = parameters.GetValue<Movie>("movie");
			this.Movie = movie;
		}
	}
}
