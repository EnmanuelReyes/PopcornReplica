using PopcornReplica.Views;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;
using Xamarin.Forms;

namespace PopcornReplica
{
	public partial class App : PrismApplication
	{
		static PopcornDatabase database;
		public static PopcornDatabase Database
		{
			get
			{
				if (database == null)
				{
					database = new PopcornDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
				}
				return database;
			}
		}

		public App(IPlatformInitializer initializer = null) : base(initializer) { }



		protected override void OnInitialized()
		{
			InitializeComponent();

			NavigationService.NavigateAsync("MasterPage");
		}
		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<MainPage>();
			Container.RegisterTypeForNavigation<BrowsePage>();
			Container.RegisterTypeForNavigation<HomePage>();
			Container.RegisterTypeForNavigation<WatchlistPage>();
			Container.RegisterTypeForNavigation<MasterPage>();
			Container.RegisterTypeForNavigation<CategoryPage>();
			Container.RegisterTypeForNavigation<MoviePage>();
			Container.RegisterTypeForNavigation<SwipePage>();
		}
	}
}
