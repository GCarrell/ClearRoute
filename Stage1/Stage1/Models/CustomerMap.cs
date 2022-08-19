using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stage1.Models
{
    internal class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Map(m => m.Name).Index(0).Name("name");
            Map(m => m.Age).Index(1).Name("age");
            Map(m => m.Address).Index(2).Name("address");
            Map(m => m.Phone).Index(3).Name("phone");
            Map(m => m.Email).Index(4).Name("email");
        }
    }
}
