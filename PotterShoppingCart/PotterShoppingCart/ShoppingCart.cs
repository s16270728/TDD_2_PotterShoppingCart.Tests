using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotterShoppingCart
{
    public class ShoppingCart
    {
        /// <summary>
        /// Book class
        /// </summary>
        public class Book
        {
            /// <summary>
            /// Book name
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// 購買數量
            /// </summary>
            public int Count { get; set; }
        }

        /// <summary>
        /// 計算書籍購買金額
        /// </summary>
        /// <param name="books">各書本購買數量</param>
        /// <returns></returns>
        public decimal CalculateFee(IEnumerable<Book> books)
        {
            var price = books.Sum(c => c.Count) * 100;
            return price;
        }  
    }
}
