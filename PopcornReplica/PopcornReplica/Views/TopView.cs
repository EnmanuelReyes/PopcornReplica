using System;
using PopcornReplica.Models;
using Xamarin.Forms;

namespace PopcornReplica.Views
{
	public class TopView : ContentView
	{
		public Top Top { get; set; }

		public TopView()
		{
			Content = new Label { Text = "Hello ContentView" };

		}
		public TopView(Top top)
		{
			this.Top = top;
			var myLabel = new Label()
			{
				Text = top.Name,
				Font = Font.SystemFontOfSize(20, FontAttributes.Bold),
				TextColor = Color.Black,
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.End,
			};
			var embeddedImage = new Image { Aspect = Aspect.Fill };
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

