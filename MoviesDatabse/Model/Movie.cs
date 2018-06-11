using System;
using System.ComponentModel;

namespace MoviesDatabase.Model
{
    public class Movie : BasePropertyChanged
    {
        public Movie(string title, DateTime releaseDate, Actor actor, Genre genre)
        {
            this._title = title;
            this._releaseDate = releaseDate;
            this._actor = actor;
            this._genre = genre;

            genre.PropertyChanged += new PropertyChangedEventHandler(somePropertyChanged);
            actor.PropertyChanged += new PropertyChangedEventHandler(somePropertyChanged);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Movie item))
                return false;
            return this.Title == item.Title && this.ReleaseDate == item.ReleaseDate && this.Actor == item.Actor && this.Genre == item.Genre;
        }

        public override int GetHashCode()
        {
            return (this.Title + this.Genre).GetHashCode() ^ this.Actor.GetHashCode();
        }

        public void Edit(string title, DateTime releaseDate, Actor actor, Genre genre)
        {
            Title = title;
            ReleaseDate = releaseDate;
            Actor = actor;
            Genre = genre;
            RaisePropertyChanged("Title");
            RaisePropertyChanged("ReleaseDate");
            RaisePropertyChanged("Actor");
            RaisePropertyChanged("Genre");
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

        private void somePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged("Actor");
            RaisePropertyChanged("Genre");
        }
    }
}
