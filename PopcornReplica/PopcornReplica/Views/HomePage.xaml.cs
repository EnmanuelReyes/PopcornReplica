using System;
using System.Collections.Generic;
using PopcornReplica.Services;
using PopcornReplica.ViewModels;
using Xamarin.Forms;

namespace PopcornReplica.Views
{
	public partial class HomePage : ContentPage
	{
		public HomePage()
		{
			InitializeComponent();
			CreateGrid();

		}

		async void CreateGrid()
		{
			AzureService az = new AzureService();
			var list = await az.GetTops();
			var size = list.Count;
			var grid = new Grid();
			for (var i = 1; i <= size; i++)
			{
				grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(0.1, GridUnitType.Auto) });
			}
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });


			var j = 0;
			for (var i = 1; i < size;)
			{

				var x = list[i];
				var catx = new TopView(x);

				catx.GestureRecognizers.Add(new TapGestureRecognizer((categoryView) => OnCategoryClicked(categoryView)));

				if (i % 3 == 0)
				{
					GridExtension.AddChild(grid, catx, j, 0, 1, 2);

					i++;
					j++;
					continue;
				}
				else
				{
					grid.Children.Add(catx, 0, j);

				}

				if (size > i)
				{
					var y = list[i + 1];
					var caty = new TopView(y);
					grid.Children.Add(caty, 1, j);
					caty.GestureRecognizers.Add(new TapGestureRecognizer((categoryView) => OnCategoryClicked(categoryView)));

				}

				i += 2;
				j++;
			}
			this.ScrollView.Children.Add(grid);
		}

		void OnCategoryClicked(View categoryView)
		{
			var top = ((TopView)categoryView).Top;
			var viewModel = this.BindingContext as HomePageViewModel;
			viewModel.ViewTop(top);
		}

	}
}
