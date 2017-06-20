using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using static PotterShoppingCart.ShoppingCart;

namespace PotterShoppingCart.Tests
{
    [TestClass()]
    public class ShoppingCartTests
    {
        /// <summary>
        /// 第一集買了一本，其他都沒買，價格應為100*1=100元
        /// </summary>
        [TestMethod()]
        public void CalculateFeeTest_Book1_1_Return_100()
        {
            //arrange
            var target = new ShoppingCart();
            var books = new List<Book>()
            {
                new Book(){
                    Name = "HarryPotter1",
                    Count =1
                }
            };

            //act
            var actual = target.CalculateFee(books);

            //assert
            var expected = 100;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 第一集買了一本，第二集也買了一本，價格應為100*2*0.95=190
        /// </summary>
        [TestMethod()]
        public void CalculateFeeTest_Book1_1_Book2_1_Return_190()
        {
            //arrange
            var target = new ShoppingCart();
            var books = new List<Book>()
            {
                new Book(){
                    Name = "HarryPotter1",
                    Count =1
                },
                new Book(){
                    Name = "HarryPotter2",
                    Count =1
                }
            };

            //act
            var actual = target.CalculateFee(books);

            //assert
            var expected = 190;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 一二三集各買了一本，價格應為100*3*0.9=270
        /// </summary>
        [TestMethod()]
        public void CalculateFeeTest_Book1_1_Book2_1_Book3_1_Return_270()
        {
            //arrange
            var target = new ShoppingCart();
            var books = new List<Book>()
            {
                new Book(){
                    Name = "HarryPotter1",
                    Count =1
                },
                new Book(){
                    Name = "HarryPotter2",
                    Count =1
                },
                new Book(){
                    Name = "HarryPotter3",
                    Count =1
                }
            };

            //act
            var actual = target.CalculateFee(books);

            //assert
            var expected = 270;
            Assert.AreEqual(expected, actual);
        }
    }
}