using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace familyBudget
{
    public class Expense
    {
        public int Id { get; set; }
        public int IdCategory { get; set; }
        public int IdProduct { get; set; }
        public double Price { get; set; }

        public int IdBuyer { get; set; }
        public string Comment { get; set; }
        public DateTime DateOperation { get; set; }
    }
}
