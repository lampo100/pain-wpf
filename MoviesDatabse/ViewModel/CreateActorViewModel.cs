using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesDatabase.Model;

namespace MoviesDatabase.ViewModel
{
    public class CreateActorViewModel : WindowStateViewModel
    {
        public CreateActorViewModel(Database database)
        {
            this._database = database;
            AddActor = new SimpleCommand<object>((object ignored) =>
            {
                database.AddActor(new Actor(FirstName, LastName));
                RaiseFinished();
            }, (object ignored) => !string.IsNullOrWhiteSpace(FirstName) && 
                                   !string.IsNullOrWhiteSpace(LastName));
            PropertyChanged += (object sender, PropertyChangedEventArgs args) => AddActor.RaiseCanExecuteChanged();
        }

        private Database _database;

        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value == _firstName)
                    return;

                _firstName = value;
                RaisePropertyChanged("FirstName");
            }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                if (value == _lastName)
                    return;

                _lastName = value;
                RaisePropertyChanged("LastName");
            }
        }

        public SimpleCommand<object> AddActor { get; private set; }
    }
}
