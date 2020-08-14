using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Stubs
{
    public class Vehicle : Object
    {
        public Vehicle()
        {

        }
        public Vehicle(int vin)
        {
            this.vin = vin;
        }

        public virtual int GetYearManufactured()
        {
            return 1980;
        }

        private int vin;

        public void SetVin(int number)
        {
            this.vin = number;
        }
    }

    public class Truck : Vehicle
    {
        private int squirrelsHit;

        public Truck(int vin) : base()
        {
            squirrelsHit = 0;
        }

        public void DriveToStore()
        {
            this.GetYearManufactured();
            base.GetYearManufactured();
        }
    }

    public class FordF150 : Truck
    {
        public FordF150(int vin) : base(vin)
        {

        }

        public int DollarValue
        {
            get
            {
                return ((2020 - GetYearManufactured()) * 10000) - (MilesDriven * 3);
            }
        }

        public override int GetYearManufactured()
        {
            return 2002;
        }

        public int MilesDriven { get; set; }

        public void MakeAd()
        {
            int currentValue = this.DollarValue;
            base.GetYearManufactured();
        }
    }
}
