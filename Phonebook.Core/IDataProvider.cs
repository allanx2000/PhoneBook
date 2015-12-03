using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Core
{
    public interface IDataProvider
    {
        ICollection<Record> GetAllRecords();
        ICollection<Record> Find(string searchText);
        void Delete(Record model);
        void Add(Record r);
    }
}
