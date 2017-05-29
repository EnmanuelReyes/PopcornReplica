using System;
using Prism.Mvvm;
using SQLite;

namespace PopcornReplica.Models
{
	public class Movie : BindableBase
	{
		[PrimaryKey]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Photo { get; set; }
		public int Year { get; set; }
		public int CategoryId { get; set; }

		public Movie()
		{
		}
	}
}
