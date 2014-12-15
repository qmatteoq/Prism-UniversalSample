using System.Collections.Generic;
using Windows.UI.Xaml.Navigation;
using Microsoft.Practices.Prism.Mvvm;
using Prism_Navigation.Entities;

namespace Prism_Navigation.ViewModels
{
    public class DetailPageViewModel : ViewModel
    {
        private News _selectedNews;

        public News SelectedNews
        {
            get { return _selectedNews; }
            set { SetProperty(ref _selectedNews, value); }
        }

        public override void OnNavigatedTo(object navigationParameter, NavigationMode navigationMode, Dictionary<string, object> viewModelState)
        {
            if (navigationParameter != null)
            {
                SelectedNews = navigationParameter as News;
            }
        }
    }
}
