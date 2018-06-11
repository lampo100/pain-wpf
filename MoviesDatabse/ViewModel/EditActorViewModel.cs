using System.Collections.Generic;
using System.ComponentModel;
using MoviesDatabase.Model;

namespace MoviesDatabase.ViewModel
{
    public class EditActorViewModel: WindowStateViewModel
    {
        public EditActorViewModel(Actor actor)
        {
            this.Actor = actor;
            this.FirstName = actor.FirstName;
            this.LastName = actor.LastName;
            EditActor = new SimpleCommand<object>((object ignored) =>
            {
                Actor.Edit(FirstName, LastName);
                RaiseFinished();
            }, (object ignored) => !string.IsNullOrWhiteSpace(FirstName) &&
                                   !string.IsNullOrWhiteSpace(LastName));
            PropertyChanged += (object sender, PropertyChangedEventArgs args) => EditActor.RaiseCanExecuteChanged();
        }

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
        public Actor Actor { get; }

        public SimpleCommand<object> EditActor { get; private set; }

    }
}