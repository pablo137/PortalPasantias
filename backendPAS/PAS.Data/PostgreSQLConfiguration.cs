using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAS.Data
{
    public class PostgreSQLConfiguration
    {
        public PostgreSQLConfiguration(string conectionString) => ConectionString = conectionString;
        public string ConectionString { get; set; }
    }
}
