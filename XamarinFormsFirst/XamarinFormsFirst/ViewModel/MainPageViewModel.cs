using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinFormsFirst.Model;

namespace XamarinFormsFirst.ViewModel
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        private string _labelText { get; set; }
        public string LabelText
        {
            get { return _labelText; }
            set
            {
                _labelText = value;
                RaisePropertyChanged();
            }
        }
        public Command ChangeTextCommand { get; set; }

        public ICommand ItemSelectedCommand { get; private set; }

        public string _selectedItemText;
        public string SelectedItemText
        {
            get { return _selectedItemText; }
            set
            {
                _selectedItemText = value;
                RaisePropertyChanged();
            }
        }

        private void HandleItemSelected(Person person)
        {
            SelectedItemText = $"{person.Name} {person.Age}";
        }

        public MainPageViewModel()
        {
            ItemSelectedCommand = new Command<Person>(HandleItemSelected);
            ChangeTextCommand = new Command(() =>
            {
                MessagingCenter.Send(this, "ButtonClicked");
                LabelText = "Goodbye";
                People.Add(new Person()
                {
                    Name = "Just created person",
                    Age = 33.234M
                });
            });
            LabelText = "Hello";
            People = new ObservableCollection<Person>()
            {
                new Person()
                {
                    Name = "Anton Abyzov",
                    Age = 23.2343434M,
                    Phone = "797829734"
                },
                new Person()
                {
                    Name = "Alena Abyzova",
                    Age = 34.234234M,
                    Phone = "72222222"
                },
                new Person()
                {
                    Name = "Anna Abyzova",
                    Age = 3.29090M,
                    Phone = "71111111"
                }
            };
           
            //PopulatePeople(); // uncomment for ios db use
        }

        private async void PopulatePeople()
        {
            var people = await App.Database.GetPeopleAsync();
            foreach (var person in people)
            {
                People.Add(person);
            }
        }

        public ObservableCollection<Person> People { get; set; } = new ObservableCollection<Person>();

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
    }
}
