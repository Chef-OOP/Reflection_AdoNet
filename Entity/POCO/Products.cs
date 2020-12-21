using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.POCO
{
    public  class Products : IDatabaseTable
    {

        private int productIDField;

        private string productNameField;

        private int supplierIDField;

        private int categoryIDField;

        private string quantityPerUnitField;

        private decimal unitPriceField;

        private int unitsInStockField;

        private int unitsOnOrderField;

        private int reorderLevelField;

        private int discontinuedField;

        public int ProductID
        {
            get
            {
                return this.productIDField;
            }
            set
            {
                this.productIDField = value;
            }
        }

        public string ProductName
        {
            get
            {
                return this.productNameField;
            }
            set
            {
                this.productNameField = value;
            }
        }

        public int SupplierID
        {
            get
            {
                return this.supplierIDField;
            }
            set
            {
                this.supplierIDField = value;
            }
        }

        public int CategoryID
        {
            get
            {
                return this.categoryIDField;
            }
            set
            {
                this.categoryIDField = value;
            }
        }

        public string QuantityPerUnit
        {
            get
            {
                return this.quantityPerUnitField;
            }
            set
            {
                this.quantityPerUnitField = value;
            }
        }

        public decimal UnitPrice
        {
            get
            {
                return this.unitPriceField;
            }
            set
            {
                this.unitPriceField = value;
            }
        }

        public int UnitsInStock
        {
            get
            {
                return this.unitsInStockField;
            }
            set
            {
                this.unitsInStockField = value;
            }
        }

        public int UnitsOnOrder
        {
            get
            {
                return this.unitsOnOrderField;
            }
            set
            {
                this.unitsOnOrderField = value;
            }
        }

        public int ReorderLevel
        {
            get
            {
                return this.reorderLevelField;
            }
            set
            {
                this.reorderLevelField = value;
            }
        }

        public int Discontinued
        {
            get
            {
                return this.discontinuedField;
            }
            set
            {
                this.discontinuedField = value;
            }
        }
    }


}
