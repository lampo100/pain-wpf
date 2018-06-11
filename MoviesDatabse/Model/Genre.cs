namespace MoviesDatabase.Model
{
    public class Genre : BasePropertyChanged
    {
        public Genre(string name)
        {
            this._name = name;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Genre item))
                return false;
            return this.Name == item.Name;
        }

        public void Edit(string name)
        {
            Name = name;
            RaisePropertyChanged("Name");
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public string Name
        {
            get => _name;
            set
            {
                if (value == _name)
                    return;
                {
                    _name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }
        private string _name;

    }
}
