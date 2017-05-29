using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PopcornReplica.Models;

namespace PopcornReplica.Services
{
	public class AzureService
	{

		public List<Category> Categories { get; set; }
		public List<Top> Tops { get; set; }

		public AzureService()
		{
			Categories = new List<Category> {
				new Category() { Name = "Action", Id = 1},
				new Category() { Name = "Adventure",Id = 2},
				new Category() { Name = "Animation"},
				new Category() { Name = "Comedy"},
				new Category() { Name = "Crime"},
				new Category() { Name = "Documentary"},
				new Category() { Name = "Drama"},
				new Category() { Name = "Family"},
				new Category() { Name = "Fantasy"},
				new Category() { Name = "History"},
				new Category() { Name = "Horror"},
				new Category() { Name = "Music"},
				new Category() { Name = "Mystery"},
				new Category() { Name = "Romance"},
				new Category() { Name = "Science Fiction"},
				new Category() { Name = "Thriller"},
				new Category() { Name = "War"},
				new Category() { Name = "Western"}
			};

			Tops = new List<Top> {
				new Top() { Name = "Action"},
				new Top() { Name = "Adventure"},
				new Top() { Name = "Animation"},
				new Top() { Name = "Comedy"},
				new Top() { Name = "Crime"},
				new Top() { Name = "Documentary"}
			};

			foreach (var x in Tops)
			{
				List<Movie> movies = new List<Movie>();
				for (var i = 0; i < 10; i++)
				{
					Movie m = new Movie { Name = "Movie " + i, Id = i + 1, CategoryId = 1, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse" };
					movies.Add(m);
				}
				x.Movies = movies;
			}

			foreach (var x in Categories)
			{
				List<Movie> movies = new List<Movie>();
				for (var i = 0; i < 10; i++)
				{
					Movie m = new Movie { Name = "Movie " + i, Id = i + 1, Rating = 9, CategoryId = 1, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." };
					movies.Add(m);
				}
				x.Movies = movies;
			}

		}

		public async Task<List<Category>> GetCategories()
		{
			return Categories;
		}
		public async Task<List<Top>> GetTops()
		{
			return Tops;
		}

	}
}
