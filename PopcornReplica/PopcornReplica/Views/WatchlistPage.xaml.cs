using System;
using System.Collections.Generic;
using PopcornReplica.Models;
using PopcornReplica.Services;
using PopcornReplica.ViewModels;
using Xamarin.Forms;

namespace PopcornReplica.Views
{
	public partial class WatchlistPage : ContentPage
	{
		public Category Category { get; set; }

		public WatchlistPage()
		{
			InitializeComponent();
			LoadCategories();
		}

		public async void LoadCategories()
		{
			AzureService az = new AzureService();
			foreach (var x in await az.GetCategories())
			{
				Label label = new Label
				{
					Margin = new Thickness { Right = 10 },
					Text = x.Name,
					BindingContext = x,
					//TextColor = Color.Black
					TextColor = Color.White
				};
				label.GestureRecognizers.Add(new TapGestureRecognizer((view) => OnLabelClicked(view)));

				this.View.Children.Add(label);

			}
		}

		void OnLabelClicked(View view)
		{
			Category = (PopcornReplica.Models.Category)view.BindingContext;
			System.Diagnostics.Debug.WriteLine("clickeo label");
			AllWhite();
			((Label)view).TextColor = (Color)Application.Current.Resources["Pink"];
			createGrid();

		}

		void AllWhite()
		{
			foreach (var x in View.Children)
			{

				((Label)x).TextColor = Color.White;
				//((Label)x).TextColor = Color.Black;

			}
		}

		public void createGrid()
		{
			var list = Category.Movies;
			var size = list.Count;
			var grid = new Grid();
			for (var i = 0; i < size / 2; i++)
			{
				grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.1, GridUnitType.Auto) });
			}
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });


			var j = 0;
			for (var i = 0; i < size; i += 2)
			{
				var x = list[i];
				//var catx = new Label { Text = x.Name };
				var catx = new MovieView(x);
				var y = list[i + 1];
				//var caty = new Label { Text = y.Name };
				var caty = new MovieView(y);
				grid.Children.Add(catx, 0, j);
				grid.Children.Add(caty, 1, j);

				catx.GestureRecognizers.Add(new TapGestureRecognizer((movieView) => OnMovieClicked(movieView)));
				caty.GestureRecognizers.Add(new TapGestureRecognizer((movieView) => OnMovieClicked(movieView)));

				j++;
			}
			this.ScrollView.Children.Add(grid);
		}

		void OnMovieClicked(View movieView)
		{
			var movie = ((MovieView)movieView).Movie;
			var bindingContext = BindingContext as WatchlistPageViewModel;
			bindingContext.ViewMovie(movie);
		}

	}
}
