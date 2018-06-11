using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesDatabase.Model;

namespace MoviesDatabase.ViewModel
{
    class MainWindowViewModel : BasePropertyChanged
    {
        public MainWindowViewModel(Database database)
        {
            _database = database;

            AddActorClicked = new SimpleCommand<object>((object ignored) =>
            {
                State = new CreateActorViewModel(database);
            });
            AddGenreClicked = new SimpleCommand<object>((object ignored) =>
            {
                State = new CreateGenreViewModel(database);
            });
            AddMovieClicked = new SimpleCommand<object>((object ignored) =>
            {
                State = new CreateMovieViewModel(database);
            });
            EditActorClicked = new SimpleCommand<object>((object ignored) =>
                {
                    if (SelectedActor == null)
                        return;
                    State = new EditActorViewModel(SelectedActor);
                    SelectedActor = null;
                });
            EditGenreClicked = new SimpleCommand<object>((object ignored) =>
            {
                if (SelectedGenre == null)
                    return;
                State = new EditGenreViewModel(SelectedGenre);
                SelectedGenre = null;
            });
            EditMovieClicked = new SimpleCommand<object>((object ignored) =>
            {
                if (SelectedMovie == null)
                    return;
                State = new EditMovieViewModel(SelectedMovie, database);
                SelectedMovie = null;
            });
            RemoveActorClicked = new SimpleCommand<object>((object ignored) =>
            {
                if (SelectedActor == null)
                    return;
                _database.RemoveActor(SelectedActor);
                SelectedActor = null;
            });
            RemoveGenreClicked = new SimpleCommand<object>((object ignored) =>
            {
                if (SelectedGenre == null)
                    return;
                _database.RemoveGenre(SelectedGenre);
                SelectedGenre = null;
            });
            RemoveMovieClicked = new SimpleCommand<object>((object ignored) =>
            {
                if (SelectedMovie == null)
                    return;
                _database.RemoveMovie(SelectedMovie);
                SelectedMovie = null;
            });
        }

        private readonly Database _database;
        
        public ItemsChangeObservableCollection<Movie> AllMovies => _database.Movies;

        public ItemsChangeObservableCollection<Actor> AllActors => _database.Actors;

        public ItemsChangeObservableCollection<Genre> AllGenres => _database.Genres;

        private Movie _selectedMovie;
        public Movie SelectedMovie
        {
            get => _selectedMovie;
            set
            {
                if (value == _selectedMovie) return;
                _selectedMovie = value;
                RaisePropertyChanged("SelectedMovie");
                if (value == null) return;
                SelectedActor = null;
                SelectedGenre = null;
                State = new SelectedMovieViewModel(_database, value);
            }
        }

        private Actor _selectedActor;
        public Actor SelectedActor
        {
            get => _selectedActor;
            set
            {
                if (value == _selectedActor) return;
                _selectedActor = value;
                RaisePropertyChanged("SelectedActor");

                if (value == null) return;
                SelectedMovie = null;
                SelectedGenre = null;
                State = new SelectedActorViewModel(_database, value);
            }
        }

        private Genre _selectedGenre;
        public Genre SelectedGenre
        {
            get => _selectedGenre;
            set
            {
                if (value == _selectedGenre) return;
                _selectedGenre = value;
                RaisePropertyChanged("SelectedGenre");
                if (value == null) return;
                SelectedMovie = null;
                SelectedActor = null;
                State = new SelectedGenreViewModel(_database, value);
            }
        }

        private WindowStateViewModel _state;
        public WindowStateViewModel State
        {
            get => _state;
            set
            {
                if (value == _state) return;
                _state = value;
                if (_state != null)
                    _state.Finished += HandleStateFinished;
                RaisePropertyChanged("State");
            }
        }

        private void HandleStateFinished(object sender, EventArgs e)
        {
            State = null;
        }

        public SimpleCommand<object> AddActorClicked { get; }
        public SimpleCommand<object> AddGenreClicked { get; }
        public SimpleCommand<object> AddMovieClicked { get; }

        public SimpleCommand<object> EditActorClicked { get; }
        public SimpleCommand<object> EditGenreClicked { get; }
        public SimpleCommand<object> EditMovieClicked { get; }

        public SimpleCommand<object> RemoveActorClicked { get; }
        public SimpleCommand<object> RemoveGenreClicked { get; }
        public SimpleCommand<object> RemoveMovieClicked { get; }

    }
}
