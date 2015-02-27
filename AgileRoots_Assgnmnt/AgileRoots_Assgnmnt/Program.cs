using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileRoots_Assgnmnt
{
    /// <summary>
    /// This is the main program which prints the recipet.
    /// Concepts of TDD, Design patterns has been demonstrated
    /// </summary>
    class Program
    {
        public static void Main()
        {
            //************************************************************************************************
            //Initializing the Cart with the Items for Bill 1 (Input1)
            List<CartItem> itemsInCart = new List<CartItem>();
            itemsInCart.Add(new CartItem("Book", 1, 12.49, false, true));
            itemsInCart.Add(new CartItem("Music CD", 1, 14.99, false , false));
            itemsInCart.Add(new CartItem("Chocolate Bar", 1, 0.85, false, true));
            //DisplayConsole(itemsInCart);

            //Initializing the Cart with the Items for Bill 2 (Input2)
            List<CartItem> itemsInCart1 = new List<CartItem>();
            itemsInCart1.Add(new CartItem("imported box of chocolate", 1, 10.00, true, true));
            itemsInCart1.Add(new CartItem("imported bottle of perfume", 1, 47.50, true, false));

            //Initializing the Cart with the Items for Bill 3 (Input3)
            List<CartItem> itemsInCart2 = new List<CartItem>();
            itemsInCart2.Add(new CartItem("imported bottle of perfume", 1, 27.99, true, false));
            itemsInCart2.Add(new CartItem("bottle of perfume", 1, 18.99, false, false));
            itemsInCart2.Add(new CartItem("packet of headache pills", 1, 9.75, false, true));
            itemsInCart2.Add(new CartItem("box of imported chocolates", 1, 11.25, true, true));
            //************************************************************************************************

            //Initializing the Tax object with the Sales Tax of 10% and 5% Import tax
            Tax txItem = new Tax(0.10, 0.05);

            Console.Write("Receipt\n");

            //Generate the Reciept by calculating appropriate Tax and Bil Amount and Display in the console. (Bill 1)
            string strOutPut = GenerateReceipt(itemsInCart, txItem);
            Console.WriteLine(strOutPut);
            strOutPut = string.Empty;

            //Generate the Reciept by calculating appropriate Tax and Bil Amount and Display in the console. (Bill 2)
            strOutPut = GenerateReceipt(itemsInCart1, txItem);
            Console.WriteLine(strOutPut);
            strOutPut = string.Empty;

            //Generate the Reciept by calculating appropriate Tax and Bil Amount and Display in the console. (Bill 3)
            strOutPut = GenerateReceipt(itemsInCart2, txItem);
            Console.WriteLine(strOutPut);
            strOutPut = string.Empty;

            Console.Read();
        }    

        /// <summary>
        /// A static method created to take care of Calculation and returning the reciept entries
        /// </summary>
        /// <param name="itemsInCart"></param>
        /// <param name="txItem"></param>
        /// <returns></returns>
       public static string GenerateReceipt(List<CartItem> itemsInCart, Tax txItem) {
              double itemSalesTax = 0;
                string strOutput= string.Empty;
                double salesTax=0;
                double totalBill =0, itemCostTotal=0;
                double importTax =0;
                foreach (CartItem item in itemsInCart){
                    double itemCost = item.Quantity * item.PricePerUnit;
                    if (item.TaxExcepted != true) {
                        itemSalesTax = txItem.SalexTaxCalculation(itemCost);
                    }
                    if (item.Imported) {                //For imported items an additional import duty is applicable
                        importTax = txItem.ImportTaxCalculation(itemCost);
                        itemSalesTax += importTax;
                    }
                    salesTax += itemSalesTax;           
                    itemCostTotal = itemCost + itemSalesTax;
                    totalBill += itemCostTotal;
                    strOutput = strOutput + string.Format("{0} {1}:{2} ", item.Quantity, item.Comodity, itemCostTotal);
                    itemCostTotal = 0;
                    itemSalesTax = 0;
                    importTax = 0;
               }
                strOutput = strOutput + string.Format("Sales Taxes:{0} Total:{1}", salesTax, totalBill);
              return strOutput;
         } 
      }
 }
