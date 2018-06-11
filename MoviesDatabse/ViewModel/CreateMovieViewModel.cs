using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesDatabase.Model;

namespace MoviesDatabase.ViewModel
{
    public class CreateMovieViewModel : WindowStateViewModel
    {
        public CreateMovieViewModel(Database database)
        {
            this._database = database;

            AddMovie = new SimpleCommand<object>((ignored) =>
            {
                database.AddMovie(new Movie(Title, ReleaseDate, Actor, Genre));
                RaiseFinished();
            }, (ignored) => !string.IsNullOrWhiteSpace(Title) &&
                            ReleaseDate != null &&
                            Actor != null &&
                            Genre != null);

            PropertyChanged += (sender, prop) => AddMovie.RaiseCanExecuteChanged();
        }

        private readonly Database _database;

        private string title;
        public string Title
        {
            get => title;
            set
            {
                if (value == title)
                    return;
                title = value;
                RaisePropertyChanged("Title");
            }
        }

        private DateTime _releaseDate = DateTime.Now;
        public DateTime ReleaseDate
        {
            get => _releaseDate;
            set
            {
                if (value == _releaseDate)
                    return;
                _releaseDate = value;
                RaisePropertyChanged("ReleaseDate");
            }
        }

        private Actor _actor;
        public Actor Actor
        {
            get => _actor;
            set
            {
                if (value == _actor)
                    return;
                _actor = value;
                RaisePropertyChanged("Actor");
            }
        }

        public ItemsChangeObservableCollection<Actor> AvailableActors => _database.Actors;

        private Genre _genre;
        public Genre Genre
        {
            get => _genre;
            set
            {
                if (value == _genre)
                    return;
                _genre = value;
                RaisePropertyChanged("Genre");
            }
        }

        public ItemsChangeObservableCollection<Genre> AvailableGenres => _database.Genres;

        public SimpleCommand<object> AddMovie { get; private set; }
    }
}
