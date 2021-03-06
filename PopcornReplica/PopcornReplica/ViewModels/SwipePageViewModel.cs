﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using PopcornReplica.Models;
using Prism.Mvvm;
using Prism.Navigation;

namespace PopcornReplica.ViewModels
{
	public class SwipePageViewModel : BindableBase, INotifyPropertyChanged, INavigationAware
	{

		public Top Top { get; set; }

		List<Movie> items = new List<Movie>();
		public List<Movie> ItemsList
		{
			get
			{
				return items;
			}
			set
			{
				if (items == value)
				{
					return;
				}
				items = value;
				OnPropertyChanged();
			}
		}
		public readonly INavigationService navService;

		public SwipePageViewModel(INavigationService navigationService)
		{
			navService = navigationService;

			//items.Add(new CardStackView.Item() { Name = "Pizza to go", Photo = "one.jpg", Location = "30 meters away", Description = "Pizza" });
			//items.Add(new CardStackView.Item() { Name = "Dragon & Peacock", Photo = "two.jpg", Location = "800 meters away", Description = "Sweet & Sour" });
			//items.Add(new CardStackView.Item() { Name = "Murrays Food Palace", Photo = "three.jpg", Location = "9 miles away", Description = "Salmon Plate" });
			//items.Add(new CardStackView.Item() { Name = "Food to go", Photo = "four.jpg", Location = "4 miles away", Description = "Salad Wrap" });
			//items.Add(new CardStackView.Item() { Name = "Mexican Joint", Photo = "five.jpg", Location = "2 miles away", Description = "Chilli Bites" });
			//items.Add(new CardStackView.Item() { Name = "Mr Bens", Photo = "six.jpg", Location = "1 mile away", Description = "Beef" });
			//items.Add(new CardStackView.Item() { Name = "Corner Shop", Photo = "seven.jpg", Location = "100 meters away", Description = "Burger & Chips" });
			//items.Add(new CardStackView.Item() { Name = "Sarah's Cafe", Photo = "eight.jpg", Location = "6 miles away", Description = "House Breakfast" });
			//items.Add(new CardStackView.Item() { Name = "Pata Place", Photo = "nine.jpg", Location = "2 miles away", Description = "Chicken Curry" });
			//items.Add(new CardStackView.Item() { Name = "Jerrys", Photo = "ten.jpg", Location = "8 miles away", Description = "Pasta Salad" });

		}

		void CreateCardStack()
		{
			ItemsList = Top.Movies;
		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{
		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{
		}

		public void OnNavigatingTo(NavigationParameters parameters)
		{
			Top = (Top)parameters["top"];
			CreateCardStack();

		}

		public async void AddToWatchlist(int index)
		{
			//foreach (var x in await App.Database.GetMoviesAsync()) {
			//	await App.Database.DeleteMovieAsync(x);
			//}
			var movie = ItemsList[index - 2];
			try
			{
				await App.Database.SaveMovieAsync(movie);
			}
			catch (Exception e)
			{

			}
			System.Diagnostics.Debug.WriteLine("Movie liked");
			var list = await App.Database.GetMoviesAsync();


		}

	}
}
