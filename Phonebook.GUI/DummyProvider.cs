using System;
using System.Collections.Generic;
using Phonebook.Core;
using System.Linq;

namespace Phonebook.GUI
{
    internal class DummyProvider : IDataProvider
    {
        private List<Record> records = new List<Record>()
        {
            new Record() { FName="Allan", LName="Xiao" },
            new Record() { FName="Brian", LName="Xiao" },
            new Record() { FName="Chris", LName="Xiao" },
            new Record() { FName="Julie", LName="Chen" },
        };

        public void Add(Record r)
        {
            records.Add(r);
        }

        public void Delete(Record model)
        {
            records.Remove(model);
        }

        public ICollection<Record> Find(string searchText)
        {
            return (from r in records where r.Match(searchText) select r).ToList();
        }

        public ICollection<Record> GetAllRecords()
        {
            return records;
        }
    }
}