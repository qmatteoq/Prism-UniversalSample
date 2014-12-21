using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI.Xaml.Navigation;
using Microsoft.Practices.Prism.Mvvm;
using Prism_LayoutManagement.Entities;

namespace Prism_LayoutManagement.ViewModels
{
    public class MinimumWidthPageViewModel : ViewModel
    {
        private ObservableCollection<Person> _persons;

        public ObservableCollection<Person> Persons
        {
            get { return _persons; }
            set { SetProperty(ref _persons, value); }
        }  

        public override void OnNavigatedTo(object navigationParameter, NavigationMode navigationMode, Dictionary<string, object> viewModelState)
        {
            Persons = new ObservableCollection<Person>
            {
                new Person
                {
                    Name = "Matteo",
                    Surname = "Pagani"
                },
                new Person
                {
                    Name = "Ugo",
                    Surname = "Lattanzi"
                },
                new Person
                {
                    Name = "Lorenzo",
                    Surname = "Barbieri"
                }
            };
        }
    }
}
