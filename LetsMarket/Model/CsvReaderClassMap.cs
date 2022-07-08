using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsMarket
{
    public class CsvReaderClassMap : ClassMap<Product>
    {
        public CsvReaderClassMap()
        {
            Map(m => m.Code).Name("codbar");
            Map(m => m.Description).Name("desc_sem_acento");
            Map(m => m.Price).Ignore();
        }
    }
}
