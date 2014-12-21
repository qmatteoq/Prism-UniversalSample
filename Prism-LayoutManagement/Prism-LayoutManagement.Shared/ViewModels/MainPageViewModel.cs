using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Mvvm.Interfaces;

namespace Prism_LayoutManagement.ViewModels
{
    public class MainPageViewModel : ViewModel
    {
        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            GoToPortraitPageCommand = new DelegateCommand(() =>
            {
                _navigationService.Navigate("Portrait", null);
            });

            GoToMinimumWidthPageCommand = new DelegateCommand(() =>
            {
                _navigationService.Navigate("MinimumWidth", null);
            });
        }

        public DelegateCommand GoToPortraitPageCommand { get; private set; }
        public DelegateCommand GoToMinimumWidthPageCommand { get; private set; }
    }
}
