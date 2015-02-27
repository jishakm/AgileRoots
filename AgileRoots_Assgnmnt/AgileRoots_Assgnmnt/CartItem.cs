using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace AgileRoots_Assgnmnt
{
   public class CartItem
    {
        string item;
        int qty;
        double price;
        bool import;
        bool taxable;

        /// <summary>
        /// Property to capture the comodity purchased
        /// </summary>
        public string Comodity {
            set{this.item = value;}
            get{return this.item;}
        }
        
        public int Quantity {
            set { this.qty = value; }
            get {return this.qty;}
        }
        
        public double PricePerUnit {
            set { this.price = value; }
            get { return this.price;  }
        }

        public bool Imported
        {
            set
            {
                this.import = value;
            }
            get
            {
                return this.import;
            }
        }

        public bool TaxExcepted
        {
            set
            {
                this.taxable = value;
            }
            get
            {
                return this.taxable;
            }
        }

        public CartItem(string product, int qty, double price, bool import, bool taxable)
        {
            Comodity = product;
            Quantity = qty;
            PricePerUnit = price;
            Imported = import;
            TaxExcepted = taxable;
        }
    }
 
}
