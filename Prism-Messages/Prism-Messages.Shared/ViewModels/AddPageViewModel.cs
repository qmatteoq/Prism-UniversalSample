using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Mvvm.Interfaces;
using Microsoft.Practices.Prism.PubSubEvents;
using Prism_Messages.Entities;
using Prism_Messages.Events;

namespace Prism_Messages.ViewModels
{
    public class AddPageViewModel : ViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;

        private string _name;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _surname;

        public string Surname
        {
            get { return _surname; }
            set { SetProperty(ref _surname, value); }
        }

        public AddPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;

            SaveCommand = new DelegateCommand(() =>
            {
                Person person = new Person
                {
                    Name = this.Name,
                    Surname = this.Surname
                };

                _eventAggregator.GetEvent<AddPersonEvent>().Publish(person);
                _navigationService.GoBack();
            });
        }


        public DelegateCommand SaveCommand { get; private set; }
    }
}
