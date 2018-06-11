using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesDatabase.Model;

namespace MoviesDatabase.ViewModel
{
    public class SelectedMovieViewModel : WindowStateViewModel
    {
        public SelectedMovieViewModel(Database database, Movie movie)
        {
            this._database = database;
            this.Movie = movie;
        }

        private Database _database;

        public Movie Movie { get; }
    }
}
