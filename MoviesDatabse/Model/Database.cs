using System.Collections.Generic;
using System.Linq;

namespace MoviesDatabase.Model
{
    public class Database
    {
        public ItemsChangeObservableCollection<Movie> Movies { get; } = new ItemsChangeObservableCollection<Movie>();

        public ItemsChangeObservableCollection<Actor> Actors { get; } = new ItemsChangeObservableCollection<Actor>();

        public ItemsChangeObservableCollection<Genre> Genres { get; } = new ItemsChangeObservableCollection<Genre>();

        public void AddActor(Actor actor)
        {
            if(!Actors.Contains(actor))
                Actors.Add(actor);
        }

        public void AddGenre(Genre genre)
        {
            if(!Genres.Contains(genre))
                Genres.Add(genre);
        }

        public void AddMovie(Movie movie)
        {
            if(!Movies.Contains(movie))
                Movies.Add(movie);
        }

        public void RemoveActor(Actor actor)
        {
            Actors.Remove(actor);
        }

        public void RemoveGenre(Genre genre)
        {
            Genres.Remove(genre);
        }

        public void RemoveMovie(Movie movie)
        {
            Movies.Remove(movie);
        }

        public List<Movie> MoviesWithGenre(Genre genre)
        {
            return Movies
                .Where(song => song.Genre == genre)
                .ToList();
        }

        public List<Movie> MoviesWithActor(Actor actor)
        {
            return Movies
                .Where(song => song.Actor == actor)
                .ToList();
        }
    }
}
