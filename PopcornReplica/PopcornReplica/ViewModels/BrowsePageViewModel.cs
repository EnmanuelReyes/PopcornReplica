using System;
using System.Collections.ObjectModel;
using PopcornReplica.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace PopcornReplica.ViewModels
{
	public class BrowsePageViewModel : BindableBase
	{

		public readonly INavigationService navService;

		public string Text { get; set; }

		/// <summary>
		/// All models; loaded from appropriate data source.
		/// </summary>
		public ObservableCollection<MyModel> AllModels { get; set; }

		/// <summary>
		/// Model pairs, used for two-column list items.
		/// </summary>
		public ObservableCollection<ModelPair> ModelPairs { get; set; }

		public DelegateCommand<MyModel> ViewCategoryCommand { get; set; }

		public BrowsePageViewModel()
		{

			Text = "Hello Browser using Prism!";
			

		}

		public BrowsePageViewModel(INavigationService navigationService)
		{
			navService = navigationService;

			System.Diagnostics.Debug.WriteLine("Entro al navigated to del home screen");
			AllModels = new ObservableCollection<MyModel>();
			AllModels.Add(new MyModel() { Id = 1 });
			AllModels.Add(new MyModel() { Id = 2 });
			AllModels.Add(new MyModel() { Id = 3 });
			AllModels.Add(new MyModel() { Id = 4 });
			ModelPairs = new ObservableCollection<ModelPair>();
			CreateModelPairs();
			Text = "Hello Browser using Prism!";
			//ViewCategoryCommand = new DelegateCommand<MyModel>(ViewCategory);
		}

		public void ViewCategory(Category category)
		{
			System.Diagnostics.Debug.WriteLine("Entro al View");
			NavigationParameters navParams = new NavigationParameters();
			navParams.Add("category", category);
			navService.NavigateAsync("CategoryPage", navParams);

		}

		private void CreateModelPairs()
		{
			for (int i = 0; i < AllModels.Count; i += 2)
			{
				MyModel item1 = AllModels[i];
				MyModel item2 = i + 1 < AllModels.Count ? AllModels[i + 1] : null;

				ModelPairs.Add(new ModelPair(item1, item2));
			}
		}




	}

	public class ModelPair : Tuple<MyModel, MyModel>
	{
		public ModelPair(MyModel item1, MyModel item2)
			: base(item1, item2 ?? CreateEmptyModel()) { }

		private static MyModel CreateEmptyModel()
		{
			return new MyModel
			{
				Id = -1 // -1 indicates that view should not be rendered
			};
		}
	}

	public class MyModel
	{
		public int Id { get; set; }
	}
}