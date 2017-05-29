using System;
using System.Collections.Generic;
using PopcornReplica.Models;
using PopcornReplica.Views;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace PopcornReplica.ViewModels
{
	public class WatchlistPageViewModel : BindableBase, INavigationAware
	{
		public readonly INavigationService navService;

		public Grid Grid { get; set; }

		public WatchlistPageViewModel()
		{

		}
		public WatchlistPageViewModel(INavigationService navigationService)
		{
			navService = navigationService;
			Grid = new Grid();
		}

		public async void InitializeGrid(Category category)
		{
			List<Movie> list;
			if (category.Id != 0)
			{
				list = await App.Database.GetMoviesOfCategory(category);

			}
			else
			{
				list = await App.Database.GetMoviesAsync();

			}
			var size = list.Count;
			Grid.RowDefinitions.Clear();
			Grid.ColumnDefinitions.Clear();
			Grid.Children.Clear();
			for (var i = 0; i < size / 2; i++)
			{
				Grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.1, GridUnitType.Auto) });
			}
			Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			Grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

			var j = 0;
			for (var i = 0; i < size; i += 2)
			{
				var x = list[i];
				var catx = new MovieView(x);
				Grid.Children.Add(catx, 0, j);
				catx.GestureRecognizers.Add(new TapGestureRecognizer((movieView) => OnMovieClicked(movieView)));
				if (i + 1 < size)
				{
					var y = list[i + 1];
					var caty = new MovieView(y);
					Grid.Children.Add(caty, 1, j);

					caty.GestureRecognizers.Add(new TapGestureRecognizer((movieView) => OnMovieClicked(movieView)));
				}
				j++;
			}
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

		void OnMovieClicked(View movieView)
		{
			var movie = ((MovieView)movieView).Movie;
			ViewMovie(movie);
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
