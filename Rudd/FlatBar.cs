using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//A Class to get and set the attributes associated with flatbar
namespace Rudd
{
    class FlatBar
    {
        
        private Double dPrice;
        private Double dSize;
        private Double dUnitSize;
        private Double dCostperUnit;

        public FlatBar(String price, String size, String unitSize)
        {
            this.dPrice = Double.Parse(price.Replace(".", ","));
            this.dSize = Int32.Parse(size);
            this.dUnitSize = Int32.Parse(unitSize);
        }

        public Double getUnitSize()
        {
            dUnitSize = (dSize * 1000) / dUnitSize;
            return dUnitSize;
        }

        public Double getCostperUnit()
        {
            dCostperUnit = dPrice / dUnitSize;
            return dCostperUnit;
        }

        public void setPrice(String price)
        {
            this.dPrice = Double.Parse(price.Replace(".", ","));
        }
    }
}
