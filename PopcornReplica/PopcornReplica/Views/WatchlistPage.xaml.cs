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
			createGrid();
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
			var bindingContext = BindingContext as WatchlistPageViewModel;
			bindingContext.InitializeGrid(Category);
			System.Diagnostics.Debug.WriteLine("clickeo label");
			AllWhite();
			((Label)view).TextColor = (Color)Application.Current.Resources["Pink"];

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
			var bindingContext = BindingContext as WatchlistPageViewModel;
			this.ScrollView.Children.Add(bindingContext.Grid);
		}

		void OnMovieClicked(View movieView)
		{
			var movie = ((MovieView)movieView).Movie;
			var bindingContext = BindingContext as WatchlistPageViewModel;
			bindingContext.ViewMovie(movie);
		}

	}
}
