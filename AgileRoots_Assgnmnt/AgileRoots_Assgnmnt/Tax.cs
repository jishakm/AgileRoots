using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileRoots_Assgnmnt
{
    public class Tax : ITaxCalculation
    {
        double salesTaxPercent;
        double importDuty;
        public double SalesTax
        {
            set { this.salesTaxPercent = value; }
            get { return this.salesTaxPercent; }
        }
        public double ImportTax
        {
            set { this.importDuty = value; }
            get { return this.importDuty; }
        }

        public Tax(double tax, double import)
        {
            SalesTax = tax;
            ImportTax = import;
        }

        public double SalexTaxCalculation(double itemCost)
        {
            double totalSalesTax = 0;
            totalSalesTax = itemCost * SalesTax;
            return Math.Round (totalSalesTax,2);
        }

        public double ImportTaxCalculation(double itemCost)
        {
            double importDuty = 0;
            importDuty = itemCost * ImportTax;
            return Math.Round(importDuty,2);
       }
    }
}

