using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaSpese.Model
{
    public class Expense
    {
        [SQLite.PrimaryKey]
        public Guid Id { get; set; }
       
        public int TotalAmount { get; set; }

        public string Itinerary { get; set; }

        public DateTimeOffset Date { get; set; }

        public string Purpose { get; set; }

        public Expense()
        {
            Date = DateTimeOffset.Now;
        }
    }
}
