using Innouvous.Utils.MVVM;
using Phonebook.Core;

namespace Phonebook.GUI.ViewModels
{
    internal class RecordViewModel : ViewModel
    {
        private Record r;

        public string FName
        {
            get
            {
                return r.FName;
            }
        }

        public string LName
        {
            get
            {
                return r.LName;
            }
        }

        public string FullName
        {
            get
            {
                return r.FullName;
            }
        }

        public RecordViewModel(Record r)
        {
            this.r = r;
        }

        public void SetModel(Record r)
        {
            this.r = r;
            RefreshViewModel();
        }

        public override string ToString()
        {
            return FName + " " + LName;
        }

        public Record Model
        {
            get
            {
                return r;
            }
        }

    }
}