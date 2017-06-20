using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterShoppingCart
{
    public class ShoppingCart
    {
        public class Book
        {
            public string Name { get; set; }
            public int Count { get; set; }
        }

        public decimal CalculateFee(IEnumerable<Book> books)
        {
            return 0;
        }  
    }
}
