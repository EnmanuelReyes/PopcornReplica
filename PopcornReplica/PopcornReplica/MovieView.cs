using System;
using PopcornReplica.Models;
using Xamarin.Forms;

namespace PopcornReplica
{
	public class MovieView : ContentView
	{
		public Movie Movie { get; set; }

		public MovieView()
		{
			Content = new Label { Text = "Hello ContentView" };
		}

		public MovieView(Movie movie)
		{
			this.Movie = movie;
			var myLabel = new Label()
			{
				Text = movie.Name,
				Font = Font.SystemFontOfSize(20, FontAttributes.Bold),
				TextColor = Color.Black,
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.End,
			};
			var embeddedImage = new Image { Aspect = Aspect.AspectFit };
			embeddedImage.Source = ImageSource.FromResource("PopcornReplica.beach.jpg");


			var grid = new Grid();
			grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
			grid.Children.Add(embeddedImage, 0, 0);
			grid.Children.Add(myLabel, 0, 0);
			Content = grid;
		}
	}
}

