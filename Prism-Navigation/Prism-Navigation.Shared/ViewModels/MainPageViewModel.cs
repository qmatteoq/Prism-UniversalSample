using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Mvvm.Interfaces;
using Prism_Navigation.Entities;
using Prism_Navigation.Services;

namespace Prism_Navigation.ViewModels
{
    public class MainPageViewModel : ViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IFeedService _feedService;
        private ObservableCollection<News> _news;

        public ObservableCollection<News> News
        {
            get { return _news; }
            set { SetProperty(ref _news, value); }
        }

        public MainPageViewModel(INavigationService navigationService, IFeedService feedService)
        {
            _navigationService = navigationService;
            _feedService = feedService;

            ShowDetailCommand = new DelegateCommand<ItemClickEventArgs>((args) =>
            {
                News selectedNews = args.ClickedItem as News;
                _navigationService.Navigate("Detail", selectedNews);
            });
        }

        public override async void OnNavigatedTo(object navigationParameter, NavigationMode navigationMode, Dictionary<string, object> viewModelState)
        {
            IEnumerable<News> news = await _feedService.GetNews();

            News = new ObservableCollection<News>();
            foreach (News item in news)
            {
                News.Add(item);
            }
        }

        public DelegateCommand<ItemClickEventArgs> ShowDetailCommand { get; private set; }
    }
}
