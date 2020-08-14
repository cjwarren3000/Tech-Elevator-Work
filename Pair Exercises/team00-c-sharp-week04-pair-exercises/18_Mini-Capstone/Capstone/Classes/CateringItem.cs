using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class CateringItem
    {

        
        

        public CateringItem()
        {
        }
        
        /*
        public CateringItem(int amount, string code, string name, float price, string type)
        {
            Amount = amount;
            Code = code;
            Name = name;
            Price = price;
            Type = type;
        }
        */


        public int Amount { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public string TotalPrice { get; set; }



       public override string ToString()
        {
            return Amount.ToString().PadRight(5) +
                Code.PadRight(5) + Name.PadRight(5) + Price.ToString().PadLeft(5) + Type.PadLeft(3);
        }











    }
}
