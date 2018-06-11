using System.ComponentModel;
using MoviesDatabase.Model;

namespace MoviesDatabase.ViewModel
{
    public class EditGenreViewModel : WindowStateViewModel
    {
        public EditGenreViewModel(Genre genre)
        {
            this.Genre = genre;
            this.Name = genre.Name;
            EditGenre = new SimpleCommand<object>((object ignored) =>
            {
                Genre.Edit(Name);
                RaiseFinished();
            }, (object ignored) => !string.IsNullOrWhiteSpace(Name));
            PropertyChanged += (object sender, PropertyChangedEventArgs args) => EditGenre.RaiseCanExecuteChanged();
        }
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
        public Genre Genre { get; }

        public SimpleCommand<object> EditGenre { get; private set; }
    }
}