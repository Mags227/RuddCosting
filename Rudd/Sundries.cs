using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rudd
{
    class Sundries
    {
        private Double sQty;
        private Double sUnitPrice;
        private Double sSubValue;
        private int unitsPerMonth;
        private Double costPerUnit;

        public Sundries(String sQty, String sUnitPrice, String unitsPerMonth)
        {
            this.sQty = Double.Parse(sQty.Replace(".", ","));
            this.sUnitPrice = Double.Parse(sUnitPrice.Replace(".", ","));
            this.unitsPerMonth = Int32.Parse(unitsPerMonth);
        }

        public Double getSubValue()
        {
            sSubValue = sQty * sUnitPrice;
            return sSubValue;
        }

        public Double getCostPerUnit()
        {
            costPerUnit = sSubValue / unitsPerMonth;
            return costPerUnit;
        }

        public void setPrice(String price)
        {
            this.sUnitPrice = Double.Parse(price.Replace(".", ","));
        }
    }
}
