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

        /// <summary>
        /// 購買套裝數量折扣
        /// </summary>
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
            if (books != null && books.Count() > 0 && books.Sum(c=>c.Count) >0)
            {
                var groupedBooks = groupBooks(books);

                var price = (from g in groupedBooks
                             let booksCount = g.Count()
                             select booksCount * getDiscount(booksCount) * this._bookPrice).Sum();
                
                return price;
            }
            else
            {
                return 0;
            } 
        }

        /// <summary>
        /// 將書根據套本分組
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        private IEnumerable<IEnumerable<Book>> groupBooks(IEnumerable<Book> books)
        {
            //書籍中購買最多的數量
            var maxCountOfBooks = books.Max(c => c.Count);

            //一次傳回一套
            for (int i = 1; i <= maxCountOfBooks; i++)
            {
                yield return books.Where(c => c.Count >= i);
            }
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
