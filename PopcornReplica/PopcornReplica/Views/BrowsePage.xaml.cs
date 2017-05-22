using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PopcornReplica.Services;
using PopcornReplica.ViewModels;
using Xamarin.Forms;

namespace PopcornReplica.Views
{
	public partial class BrowsePage : ContentPage
	{
		public BrowsePage()
		{
			InitializeComponent();
			CreateGrid();
		}

		async void CreateGrid()
		{
			AzureService az = new AzureService();
			var list = await az.GetCategories();
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
				var catx = new CategoryView(x);
				var y = list[i + 1];
				//var caty = new Label { Text = y.Name };
				var caty = new CategoryView(y);
				grid.Children.Add(catx, 0, j);
				grid.Children.Add(caty, 1, j);

				catx.GestureRecognizers.Add(new TapGestureRecognizer((categoryView) => OnCategoryClicked(categoryView)));
				caty.GestureRecognizers.Add(new TapGestureRecognizer((categoryView) => OnCategoryClicked(categoryView)));

				j++;
			}
			this.ScrollView.Children.Add(grid);
		}

		void OnCategoryClicked(View categoryView)
		{
			var category = ((CategoryView)categoryView).Category;
			var viewModel = this.BindingContext as BrowsePageViewModel;
			viewModel.ViewCategory(category);
		}
}
}
