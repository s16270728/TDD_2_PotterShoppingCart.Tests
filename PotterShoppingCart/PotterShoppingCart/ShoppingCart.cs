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

        private Dictionary<int, decimal> _discount;

        public ShoppingCart()
        {
            this._bookPrice = 100;

            this._discount = new Dictionary<int, decimal>() {
                {1, 1},
                {2, 0.95M},
                {3, 0.9M},
                {4, 0.8M},
                {5, 0.75M}
            };
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
            ///總金額
            var price = 0M;

            var booksCount = books.Sum(c => c.Count);

            var maxCountOfBooks = books.Max(c => c.Count);

            for (int i = 1; i <= maxCountOfBooks; i++)
            {
                var groupBooks = books.Where(c => c.Count >= i);

                var booksDistinctCount = groupBooks.Select(c => c.Name).Distinct().Count();

                var bookDiscount = getDiscount(booksDistinctCount);

                price += booksDistinctCount * this._bookPrice * bookDiscount;
            }

            return price;
        }

        /// <summary>
        /// 計算購買書籍折扣
        /// </summary>
        /// <param name="booksDistinctCount"></param>
        /// <returns></returns>
        private decimal getDiscount(int booksDistinctCount)
        {
            var bookDiscount = (from item in this._discount
                                where item.Key <= booksDistinctCount
                                orderby item.Key descending
                                select item.Value).FirstOrDefault();

            return bookDiscount;
        }
    }
}
