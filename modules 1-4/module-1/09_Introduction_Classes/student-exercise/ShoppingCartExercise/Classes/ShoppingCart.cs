using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechElevator.Classes
{
    /// <summary>
    /// A shopping cart class stores items in it.
    /// </summary>
    public class ShoppingCart
    {
        //constructors
        public ShoppingCart()
        {

        }

        //properties

        private int totalNumberOfItems = 0;
        private decimal totalAmountOwed = 0.0M;

        public int TotalNumberOfItems
        {
            get
            {
                return totalNumberOfItems;
            }
            private set
            {
                totalNumberOfItems = value;
            }
        }

        public decimal TotalAmountOwed
        {
            get
            {
                return totalAmountOwed;
            }
            private  set
            {
                totalAmountOwed = value;
            }
        }


        //methods
        public decimal GetAveragePricePerItem()
        {
            if (TotalNumberOfItems > 0)
            {
                return TotalAmountOwed / TotalNumberOfItems;
            }
            else
            {
                return 0.0M;
            }
        }

        public void AddItems(int numberOfItems, decimal pricePerItem)
        {
            TotalNumberOfItems += numberOfItems;
            TotalAmountOwed += (pricePerItem * numberOfItems);
        }

        public void Empty()
        {
            TotalNumberOfItems = 0;
            TotalAmountOwed = 0.0M;
        }

    }
}
