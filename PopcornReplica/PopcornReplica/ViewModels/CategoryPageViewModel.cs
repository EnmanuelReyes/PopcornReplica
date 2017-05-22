using System;
using System.Collections.ObjectModel;
using PopcornReplica.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace PopcornReplica.ViewModels
{
	public class CategoryPageViewModel : BindableBase, INavigationAware
	{
		public readonly INavigationService navService;

		/// <summary>
		/// All models; loaded from appropriate data source.
		/// </summary>
		public Category Category { get; set; }
		public Grid Grid { get; set; }



		public DelegateCommand<Movie> ViewMovieCommand { get; set; }

		public CategoryPageViewModel(INavigationService navigationService)
		{
			navService = navigationService;

			System.Diagnostics.Debug.WriteLine("Entro al constructor del category");

			Grid = new Grid();

			ViewMovieCommand = new DelegateCommand<Movie>(ViewMovie);
		}

		public void createGrid()
		{
			var list = Category.Movies;
			var size = list.Count;
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
				//var catx = new Label { Text = x.Name };
				var catx = new MovieView(x);
				var y = list[i + 1];
				//var caty = new Label { Text = y.Name };
				var caty = new MovieView(y);
				Grid.Children.Add(catx, 0, j);
				Grid.Children.Add(caty, 1, j);

				catx.GestureRecognizers.Add(new TapGestureRecognizer((movieView) => OnMovieClicked(movieView)));
				caty.GestureRecognizers.Add(new TapGestureRecognizer((movieView) => OnMovieClicked(movieView)));

				j++;
			}
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

		public void OnNavigatedFrom(NavigationParameters parameters)
		{
			throw new NotImplementedException();
		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{
			System.Diagnostics.Debug.WriteLine("primero");

		}

		public void OnNavigatingTo(NavigationParameters parameters)
		{
			Category = (Category)parameters["category"];
			System.Diagnostics.Debug.WriteLine("segundo");
			createGrid();

		}
	}
}
