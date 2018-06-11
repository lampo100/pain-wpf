using System;
using System.ComponentModel;
using MoviesDatabase.Model;

namespace MoviesDatabase.ViewModel
{
    public class EditMovieViewModel : WindowStateViewModel
    {
        public EditMovieViewModel(Movie movie, Database database)
        {
            this._database = database;
            this.Movie = movie;
            this.Title = movie.Title;
            this.ReleaseDate = movie.ReleaseDate;
            this.Actor = movie.Actor;
            this.Genre = movie.Genre;
            EditMovie = new SimpleCommand<object>((object ignored) =>
            {
                Movie.Edit(Title, ReleaseDate, Actor, Genre);
                RaiseFinished();
            }, (object ignored) => !string.IsNullOrWhiteSpace(Title) &&
                                   ReleaseDate != null &&
                                   Actor != null &&
                                   Genre != null);
            PropertyChanged += (object sender, PropertyChangedEventArgs args) => EditMovie.RaiseCanExecuteChanged();
        }
        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                if (value == _title) return;
                _title = value;
                RaisePropertyChanged("Title");
            }
        }

        private DateTime _releaseDate;
        public DateTime ReleaseDate
        {
            get => _releaseDate;
            set
            {
                if (value == _releaseDate) return;
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
                if (value == _actor) return;
                _actor = value;
                RaisePropertyChanged("Actor");
            }
        }

        private Genre _genre;
        public Genre Genre
        {
            get => _genre;
            set
            {
                if (value == _genre) return;
                _genre = value;
                RaisePropertyChanged("Genre");
            }
        }
        public Movie Movie { get; }

        private Database _database;
        public ItemsChangeObservableCollection<Actor> AvailableActors => _database.Actors;
        public ItemsChangeObservableCollection<Genre> AvailableGenres => _database.Genres;



        public SimpleCommand<object> EditMovie { get; private set; }
    }
}