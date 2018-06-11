namespace MoviesDatabase.Model
{
    public class Actor : BasePropertyChanged
    {
        public Actor(string firstName, string lastName)
        {
            this._firstName = firstName;
            this._lastName = lastName;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Actor item))
                return false;
            return this.FirstName == item.FirstName && this.LastName == item.LastName;
        }

        public override int GetHashCode()
        {
            return (this.FirstName + this.LastName).GetHashCode();
        }

        public void Edit(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value == _firstName)
                    return;
                _firstName = value;
                RaisePropertyChanged("FirstName");
            }
        }

        public string LastName{
            get => _lastName;
            set
            {
                if (value == _lastName)
                    return;
                _lastName = value;
                RaisePropertyChanged("LastName");
            }
        }

        private string _firstName;
        private string _lastName;
    }
}
