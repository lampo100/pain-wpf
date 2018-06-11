using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesDatabase.Model;

namespace MoviesDatabase.ViewModel
{
    public class SelectedActorViewModel : WindowStateViewModel
    {
        public SelectedActorViewModel(Database database, Actor actor)
        {
            this._database = database;
            this.Actor = actor;
        }

        private readonly Database _database;

        public Actor Actor { get; }

        public List<Movie> Movies => _database.MoviesWithActor(Actor);
    }
}
