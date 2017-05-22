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
			System.Diagnostics.Debug.WriteLine("Entro al constructor del movie");
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
