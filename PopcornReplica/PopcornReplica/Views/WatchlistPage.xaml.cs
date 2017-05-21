using System;
using System.Collections.Generic;
using PopcornReplica.Services;
using Xamarin.Forms;

namespace PopcornReplica.Views
{
	public partial class WatchlistPage : ContentPage
	{
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
					TextColor = Color.Black
					//TextColor = Color.White,
				};
				label.GestureRecognizers.Add(new TapGestureRecognizer((view) => OnLabelClicked(view)));

				this.View.Children.Add(label);

			}
		}

		void OnLabelClicked(View view)
		{
			System.Diagnostics.Debug.WriteLine("clickeo label");
			AllWhite();
			((Label)view).TextColor = (Color)Application.Current.Resources["Pink"];

		}

		void AllWhite()
		{
			foreach (var x in View.Children)
			{

				//((Label)x).TextColor = Color.White;
				((Label)x).TextColor = Color.Black;

			}
		}

	}
}
