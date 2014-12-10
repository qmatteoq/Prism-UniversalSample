using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Windows.UI.Xaml.Navigation;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Mvvm.Interfaces;

namespace PrismDemo.ViewModels
{
    public class MainPageViewModel : ViewModel
    {
        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SayHelloCommand = new DelegateCommand(() =>
            {
                Message = string.Format("Hello {0}", Name);
            }, () => !string.IsNullOrEmpty(Name));
        }

        public DelegateCommand SayHelloCommand { get; private set; }


        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SayHelloCommand.RaiseCanExecuteChanged();
                SetProperty(ref _name, value);
            }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
    }
}
