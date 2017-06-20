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

        /// <summary>
        /// 一二三四集各買了一本，價格應為100*4*0.8=320
        /// </summary>
        [TestMethod()]
        public void CalculateFeeTest_Book1_1_Book2_1_Book3_1_Book4_1_Return_320()
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
                },
                new Book(){
                    Name = "HarryPotter4",
                    Count =1
                }
            };

            //act
            var actual = target.CalculateFee(books);

            //assert
            var expected = 320;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 一次買了整套，一二三四五集各買了一本，價格應為100*5*0.75=375
        /// </summary>
        [TestMethod()]
        public void CalculateFeeTest_Book1_1_Book2_1_Book3_1_Book4_1_Book5_1_Return_375()
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
                },
                new Book(){
                    Name = "HarryPotter4",
                    Count =1
                },
                new Book(){
                    Name = "HarryPotter5",
                    Count =1
                }
            };

            //act
            var actual = target.CalculateFee(books);

            //assert
            var expected = 375;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 一二集各買了一本，第三集買了兩本，價格應為100*3*0.9 + 100 = 370
        /// </summary>
        [TestMethod()]
        public void CalculateFeeTest_Book1_1_Book2_1_Book3_2_Return_370()
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
                    Count =2
                }
            };

            //act
            var actual = target.CalculateFee(books);

            //assert
            var expected = 370;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// 第一集買了一本，第二三集各買了兩本，價格應為100*3*0.9 + 100*2*0.95 = 460
        /// </summary>
        [TestMethod()]
        public void CalculateFeeTest_Book1_1_Book2_2_Book3_2_Return_460()
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
                    Count =2
                },
                new Book(){
                    Name = "HarryPotter3",
                    Count =2
                }
            };

            //act
            var actual = target.CalculateFee(books);

            //assert
            var expected = 460;
            Assert.AreEqual(expected, actual);
        }
    }
}