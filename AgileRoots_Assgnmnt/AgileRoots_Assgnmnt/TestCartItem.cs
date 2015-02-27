using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace AgileRoots_Assgnmnt
{
   
    [TestFixture]
    class TestCartItem
    {

       [SetUp]
        public void Setup()
        {






           //Initialize Tax object;
            Tax x = new Tax(0.10, 0.05);
        }

       [Test]
       public void TestCalcImportTax()
       {

           Tax x = new Tax(0.10, 0.05);
           double itemCost = 12.40;
           double importTax = x.ImportTaxCalculation(itemCost);
           //Assert.AreEqual(Math.Round(itemCost * 0.05), importTax);
           double importDuty = Math.Round(itemCost * x.ImportTax, 2);
           Assert.AreEqual(importDuty, importTax);
       }


       [Test]
   
        public void TestCalcSalesTax(){
            Tax x = new Tax(0.10, 0.05);
            double itemCost = 12.40;
            double tax = Math.Round(itemCost * x.SalesTax,2);
            double salesTax = x.SalexTaxCalculation(itemCost);
            Assert.AreEqual(tax, salesTax);
        }

        [Test]
       public void TestOutput1() 
       {
           //Initializing the Cart with the Items for Bill 1 (Input1)
           List<CartItem> itemsInCart = new List<CartItem>();
           itemsInCart.Add(new CartItem("Book", 1, 12.49, false, true));
           itemsInCart.Add(new CartItem("Music CD", 1, 14.99, false, false));
           itemsInCart.Add(new CartItem("Chocolate Bar", 1, 0.85, false, true));
           //DisplayConsole(itemsInCart);
           Tax txItem = new Tax(0.10,0.05);
           string outPutStr= Program.GenerateReceipt(itemsInCart, txItem);
           string expStr = "1 book:12.49 1 music CD:16.49 1 chocolate bar:0.85 Sales Taxes:1.5 Total:29.83";
           StringAssert.AreEqualIgnoringCase(expStr, outPutStr);
       }

        [Test]
        public void TestOutput2()
        {
            //Initializing the Cart with the Items for Bill 2 (Input2)
            List<CartItem> itemsInCart1 = new List<CartItem>();
            itemsInCart1.Add(new CartItem("imported box of chocolates", 1, 10.00, true, true));
            itemsInCart1.Add(new CartItem("imported bottle of perfume", 1, 47.50, true, false));

            //DisplayConsole(itemsInCart);
            Tax txItem = new Tax(0.10, 0.05);
            string outPutStr = Program.GenerateReceipt(itemsInCart1, txItem);
            string expStr = "1 imported box of chocolates:10.5 1 imported bottle of perfume:54.65 Sales Taxes:7.65 Total:65.15";
            StringAssert.AreEqualIgnoringCase(expStr, outPutStr);
        }

        [Test]
        public void TestOutput3()
        {
            //Initializing the Cart with the Items for Bill 3 (Input3)
            List<CartItem> itemsInCart2 = new List<CartItem>();
            itemsInCart2.Add(new CartItem("imported bottle of perfume", 1, 27.99, true, false));
            itemsInCart2.Add(new CartItem("bottle of perfume", 1, 18.99, false, false));
            itemsInCart2.Add(new CartItem("packet of headache pills", 1, 9.75, false, true));
            itemsInCart2.Add(new CartItem("box of imported chocolates", 1, 11.25, true, true));

            //DisplayConsole(itemsInCart);
            Tax txItem = new Tax(0.10, 0.05);
            string outPutStr = Program.GenerateReceipt(itemsInCart2, txItem);
            string expStr = "1 imported bottle of perfume:32.19 1 bottle of perfume:20.89 1 packet of headache pills:9.75 1 imported box of chocolates:11.85 Sales Taxes:6.70 Total:74.68";
            StringAssert.AreEqualIgnoringCase(expStr, outPutStr);
        }

        


    }
}
