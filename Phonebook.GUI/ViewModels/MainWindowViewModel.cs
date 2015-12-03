using Innouvous.Utils.MVVM;
using Phonebook.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

namespace Phonebook.GUI.ViewModels
{
    class MainWindowViewModel : ViewModel
    {

        private IDataProvider provider;
        private ObservableCollection<RecordViewModel> results;

        public ObservableCollection<RecordViewModel> ResultsView
        {
            get
            {
                return results;
            }
        }

        private RecordViewModel selectedContact;

        public string SearchText {get; set;}

        public RecordViewModel SelectedContact {
            get
            {
                return selectedContact;
            }
            set
            {
                selectedContact = value;
                RaisePropertyChanged("SelectedContact");
            }
        }

        public MainWindowViewModel()
        {
            provider = new DummyProvider();
            results = new ObservableCollection<RecordViewModel>();

            SearchText = "";
            Search();
        }
        
        public ICommand SearchCommand
        {
            get
            {
                return new CommandHelper(Search);
            }
        }

        private void Search()
        {
            IEnumerable<Record> rcs;

            if (SearchText == "")
                rcs = provider.GetAllRecords();
            else
                rcs = provider.Find(SearchText);

            results.Clear();

            foreach (Record r in rcs)
            {
                var vm = new RecordViewModel(r);

                results.Add(vm);
            }
        }

        public ICommand PrintCommand
        {
            get
            {
                return new CommandHelper(Print);
            }
        }

        private void Print()
        {
            if (results.Count == 0)
                return;

            PrintDialog dialog = new PrintDialog();
            dialog.ShowDialog();


            FlowDocument doc = new FlowDocument();

            foreach (var c in results)
            {
                Paragraph para = new Paragraph();
                doc.Blocks.Add(para);
                para.Inlines.Add(c.ToString());
            }


            dialog.PrintDocument(((IDocumentPaginatorSource) doc).DocumentPaginator, "PhoneBook");
        }

        public ICommand AddCommand
        {
            get
            {
                return new CommandHelper(Add);
            }
        }

        int ctr = 0;
        private void Add()
        {
            Record r = new Record() { FName = "F" + ctr, LName= "L" + ctr};
            provider.Add(r);
            Search();
        }

        public ICommand EditCommand
        {
            get
            {
                return null;
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return new CommandHelper(Delete);
            }
        }

        private void Delete()
        {
            if (SelectedContact == null)
                return;

            provider.Delete(selectedContact.Model);

            SelectedContact = null;

            Search();
        }
    }
}
