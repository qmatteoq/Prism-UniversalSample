using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Prism_Commands.Entities;

namespace Prism_Commands.ViewModels
{
    public class MainPageViewModel : ViewModel
    {
        private ObservableCollection<News> _news;

        public ObservableCollection<News> News
        {
            get { return _news; }
            set { SetProperty(ref _news, value); }
        }

        public override void OnNavigatedTo(object navigationParameter, NavigationMode navigationMode, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(navigationParameter, navigationMode, viewModelState);
        }

        public override void OnNavigatedFrom(Dictionary<string, object> viewModelState, bool suspending)
        {
            base.OnNavigatedFrom(viewModelState, suspending);
        }

        public MainPageViewModel()
        {
            DoubleTapCommand = new DelegateCommand(async () =>
            {
                MessageDialog dialog = new MessageDialog("Double tap performed");
                await dialog.ShowAsync();
            });

            DisplayMessageCommand = new DelegateCommand<string>(async (args) =>
            {
                MessageDialog dialog = new MessageDialog(args);
                await dialog.ShowAsync();
            });

            ShowDetailCommand = new DelegateCommand<ItemClickEventArgs>(async (args) =>
            {
                News news = args.ClickedItem as News;
                MessageDialog dialog = new MessageDialog(news.Title);
                await dialog.ShowAsync();
            });

            News = new ObservableCollection<News>
            {
                new News
                {
                    Title = "First news",
                    Summary = "Description"
                },
                new News
                {
                    Title = "Second news",
                    Summary = "Description"
                },
                new News
                {
                    Title = "Third news",
                    Summary = "Description"
                }
            };
        }

        public DelegateCommand DoubleTapCommand { get; private set; }

        public DelegateCommand<string> DisplayMessageCommand { get; private set; }

        public DelegateCommand<ItemClickEventArgs> ShowDetailCommand { get; private set; }

    }
}
