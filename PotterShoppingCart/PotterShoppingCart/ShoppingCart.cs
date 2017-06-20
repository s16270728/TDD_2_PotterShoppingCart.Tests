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
        /// 書籍售價
        /// </summary>
        private decimal _bookPrice;

        private decimal _discount;

        public ShoppingCart()
        {
            this._bookPrice = 100;

            this._discount = 0.95M;
        }

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
            var booksCount = books.Sum(c => c.Count);

            var booksDistinctCount = books.Select(c => c.Name).Distinct().Count();

            var price = 0M;

            if (booksDistinctCount >= 2) //大於兩本不一樣的書就打折
            {
                price = booksCount * this._bookPrice * this._discount;
            }
            else
            {
                price = booksCount * this._bookPrice;
            }
            

            return price;
        }  
    }
}
