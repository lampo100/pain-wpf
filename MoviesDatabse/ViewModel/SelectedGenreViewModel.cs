using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesDatabase.Model;

namespace MoviesDatabase.ViewModel
{
    public class SelectedGenreViewModel : WindowStateViewModel
    {
        public SelectedGenreViewModel(Database database, Genre genre)
        {
            this._database = database;
            this.Genre = genre;
        }

        private readonly Database _database;

        public Genre Genre { get; }

        public List<Movie> Movies => _database.MoviesWithGenre(Genre);
    }
}
