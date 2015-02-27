using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileRoots_Assgnmnt
{
    public interface ITaxCalculation
    {
        double SalexTaxCalculation(double cost);
        double ImportTaxCalculation(double cost);
    }
}
