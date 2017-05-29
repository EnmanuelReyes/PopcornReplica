using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PopcornReplica.Models;
using SQLite;

namespace PopcornReplica
{
	public class PopcornDatabase
	{
		readonly SQLiteAsyncConnection database;

		public PopcornDatabase(string dbPath)
		{
			database = new SQLiteAsyncConnection(dbPath);
			database.CreateTableAsync<Movie>().Wait();
		}

		public Task<List<Movie>> GetMoviesAsync()
		{
			return database.Table<Movie>().ToListAsync();
		}


		public Task<List<Movie>> GetMoviesOfCategory(Category category)
		{
			return database.QueryAsync<Movie>("SELECT * FROM [Movie] WHERE [CategoryId] = " + category.Id);
		}

		public Task<int> SaveMovieAsync(Movie item)
		{

			return database.InsertAsync(item);
		}

		public Task<int> DeleteMovieAsync(Movie item)
		{
			return database.DeleteAsync(item);
		}


	}
}
