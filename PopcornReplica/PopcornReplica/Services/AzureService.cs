using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PopcornReplica.Models;

namespace PopcornReplica.Services
{
	public class AzureService
	{

		public List<Category> Categories { get; set; }

		public AzureService()
		{
			Categories = new List<Category> {
				new Category() { Name = "Action"},
				new Category() { Name = "Adventure"},
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

			foreach(var x in Categories) {
				List<Movie> movies = new List<Movie>();
				for (var i = 0; i < 10; i++) {
					Movie m = new Movie { Name = "Pelicula " + i };
					movies.Add(m);
				}
				x.Movies = movies;
			}

		}

		public async Task<List<Category>> GetCategories()
		{
			return Categories;
		}

	}
}
