using System;
using System.Collections.Generic;
using SQLite;

namespace PopcornReplica.Models
{
	public class Category
	{
		[PrimaryKey]
		public int Id { get; set; }
		public string Name { get; set; }
		public List<Movie> Movies { get; set; }
		public Category()
		{
		}
	}
}
