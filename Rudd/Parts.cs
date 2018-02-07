using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

//this is a class to get the costing price of parts
namespace Rudd
{
    class Parts
    {
        private int cbxIdx;
        private String type;
        private Double qty;
        private Double price;
        private Double unitSize;
        private Double unitPrice;
        
        public Parts(int cbxIdx, String qty, String price, String type)
        {
            this.cbxIdx = cbxIdx;
            this.type = type;
            this.qty = Double.Parse(qty);
            this.price = Double.Parse(price.Replace(".", ","));
        }

        public Double getQty()
        {
            return this.qty;
        }

        public double getPrice()
        {
            return this.price;
        }

        public void setPrice(String price)
        {
            this.price = Double.Parse(price.Replace(".", ","));
        }

        public Double getUnitSize()
        {
            if (type.Equals("brace"))
            {
                switch (this.cbxIdx)
                {
                    case 0:
                        this.unitSize = 60;
                        break;
                    case 1:
                        this.unitSize = 100;
                        break;
                    default:
                        this.unitSize = 60;
                        break;
                }
            }

            if (type.Equals("feetbar"))
            {
                this.unitSize = 14.29;
            }

            if (type.Equals("loadcell"))
            {
                this.unitSize = 150;
            }

            if (type.Equals("potting"))
            {
                this.unitSize = 150;
            }

            if (type.Equals("cable"))
            {
                this.unitSize = 500; 
            }

            if (type.Equals("single"))
            {
                this.unitSize = 1;
            }

            if (type.Equals("gas"))
            {
                int unitSize_a = 3;
                int unitSize_b = 2;
                this.unitSize = unitSize_a * unitSize_b;
            }

            if (type.Equals("wire"))
            {
                this.unitSize = 7.5;
            }

            if (type.Equals("galvanising"))
            {
                this.unitSize = 10;
            }

            if (type.Equals("petrol"))
            {
                this.unitSize = 225;
            }

            if (type.Equals("plateSecu"))
            {
                this.unitSize = 55;
            }

            if (type.Equals("cuttingDiscs"))
            {
                this.unitSize = 14;
            }

            return this.unitSize;
        }

        public Double getUnitPrice()
        {

            this.unitPrice = this.price / this.getUnitSize();
            return this.unitPrice;

        }

        public Double getFuelPrice()
        {
            Double fuelPrice;
            fuelPrice = (75 * 3) / this.price;
            return fuelPrice;
        }

        public Double getSetPrice()
        {
            return this.unitPrice * this.qty;
        }
        
    }
}
