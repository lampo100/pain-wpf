using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesDatabase.Model;

namespace MoviesDatabase.ViewModel
{
    public class CreateGenreViewModel : WindowStateViewModel
    {
        public CreateGenreViewModel(Database database)
        {
            this._database = database;

            AddGenre = new SimpleCommand<object>((ignored) =>
            {
                database.AddGenre(new Genre(Name));
                RaiseFinished();
            }, (ignored) => !string.IsNullOrWhiteSpace(Name));
            PropertyChanged += (sender, prop) => AddGenre.RaiseCanExecuteChanged();
        }

        private Database _database;

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (value == _name)
                    return;
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        public SimpleCommand<object> AddGenre { get; private set; }
    }
}
