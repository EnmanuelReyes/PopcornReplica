using System;
using System.Collections.Generic;

namespace PopcornReplica.Models
{
	public class Category
	{
		public string Name { get; set; }
		public List<Movie> Movies { get; set; }
		public Category()
		{
		}
	}
}
