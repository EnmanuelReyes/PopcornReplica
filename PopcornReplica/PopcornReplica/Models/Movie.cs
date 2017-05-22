using System;
using Prism.Mvvm;

namespace PopcornReplica.Models
{
	public class Movie : BindableBase
	{
		public string Name { get; set; }
		public Movie()
		{
		}
	}
}
