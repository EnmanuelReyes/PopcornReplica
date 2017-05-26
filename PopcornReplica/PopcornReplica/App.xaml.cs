using PopcornReplica.Views;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PopcornReplica
{
	public partial class App : PrismApplication
	{
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
