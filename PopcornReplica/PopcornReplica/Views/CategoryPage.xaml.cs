using System;
using System.Collections.Generic;
using PopcornReplica.Models;
using PopcornReplica.Services;
using PopcornReplica.ViewModels;
using Xamarin.Forms;

namespace PopcornReplica.Views
{
	public partial class CategoryPage : ContentPage
	{
		public CategoryPage()
		{
			InitializeComponent();
			CreateGrid();
		}

		void CreateGrid()
		{
			var viewModel = this.BindingContext as CategoryPageViewModel;
			this.ScrollView.Children.Add(viewModel.Grid);

		}


	}
}
