using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesDatabase.Model;

namespace MoviesDatabase.ViewModel
{
    public abstract class WindowStateViewModel : BasePropertyChanged
    {
        public event EventHandler Finished;

        protected void RaiseFinished()
        {
            if (Finished != null)
                Finished(this, new EventArgs());
        }
    }
}
