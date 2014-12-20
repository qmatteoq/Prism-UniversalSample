using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI.Xaml.Navigation;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Mvvm.Interfaces;
using Microsoft.Practices.Prism.PubSubEvents;
using Prism_Messages.Entities;
using Prism_Messages.Events;

namespace Prism_Messages.ViewModels
{
    public class MainPageViewModel : ViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;

        private ObservableCollection<Person> _persons;

        public ObservableCollection<Person> Persons
        {
            get {return _persons;}
            set { SetProperty(ref _persons, value); }
        }  

        public MainPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<AddPersonEvent>().Subscribe(person =>
            {
                if (Persons == null)
                {
                    Persons = new ObservableCollection<Person>();
                }

                Persons.Add(person);
            }, ThreadOption.UIThread);

            GoToAddPageCommand = new DelegateCommand(() =>
            {
                _navigationService.Navigate("Add", null);
            });
        }

        public DelegateCommand GoToAddPageCommand { get; private set; }
    }
}
