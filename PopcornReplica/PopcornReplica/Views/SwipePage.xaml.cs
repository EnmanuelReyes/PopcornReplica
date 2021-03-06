﻿using System;
using System.Collections.Generic;
using PopcornReplica.ViewModels;
using Xamarin.Forms;

namespace PopcornReplica.Views
{
	public partial class SwipePage : ContentPage
	{
		public SwipePage()
		{
			InitializeComponent();
			CardStackView cardStack = new CardStackView();
			cardStack.SetBinding(CardStackView.ItemsSourceProperty, "ItemsList");
			cardStack.SwipedLeft += SwipedLeft;
			cardStack.SwipedRight += SwipedRight;

			view.Children.Add(cardStack,
				Constraint.Constant(30),
				Constraint.Constant(60),
				Constraint.RelativeToParent((parent) =>
				{
					return parent.Width - 60;
				}),
				Constraint.RelativeToParent((parent) =>
				{
					return parent.Height - 140;
				})
			);

			this.LayoutChanged += (object sender, EventArgs e) =>
			{
				cardStack.CardMoveDistance = (int)(this.Width * 0.60f);
			};
		}


		void SwipedLeft(int index)
		{
			System.Diagnostics.Debug.WriteLine("Swiped Left " + index);
		}

		void SwipedRight(int index)
		{
			var viewModel = this.BindingContext as SwipePageViewModel;
			viewModel.AddToWatchlist(index);
			System.Diagnostics.Debug.WriteLine("Swiped Right " + index);
		}
	}
}
