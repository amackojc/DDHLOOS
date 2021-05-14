using System;
using System.Collections.Generic;
using System.Text;

namespace C3
{
    interface IVisitPort : ITransportable
    {
        // some ITransportable items will be refilled or disposed during each port visit
        // examples: food (refill), oxygen (refill), fuel (refill), waste (dispose)
        // each IVisitPort item has to know its refillment/disposal cost 
        double VisitPort(); // this method should update volume & weight, then return total cost
    }
    class FuelTank : IVisitPort
    {
        public double MaxCapacity { get; set; }
        private Fuel fuel;
        protected double volume, weight;
        public FuelTank(double capacity, Fuel fuel)
        {
            this.fuel = fuel;
            volume = capacity;
        }
        public double Volume
        {
            get { return volume; }
            set
            {
                volume = value;
                weight = value * 7.0; // assume density equal to 7000 kg/m^3 (arbitrary number)
            }
        }
        public double Weight
        {
            get { return weight; }
            set
            {
                weight = value;
                volume = value / 7.0; // assume density equal to 7000 kg/m^3 (arbitrary number)
            }
        }
        public virtual double VisitPort()
        {
            volume = MaxCapacity;
            return Math.Abs(MaxCapacity - weight / 7) * 120;
        }
        public double GetCapacity()
        {
            return volume;
        }
        public string GetFuelType()
        {
            return fuel.Type;
        }
    }
    class Waste : IVisitPort
    {
        protected double volume, weight;
        public double Volume
        {
            get { return volume; }
            set
            {
                volume = value;
                weight = value * 100;
            }
        }
        public double Weight
        {
            get { return weight; }
            set
            {
                weight = value;
                volume = value / 100;
            }
        }
        public double VisitPort()
        {
            volume = 0;
            return 10;
        }
    }
    class OxygenBottle : IVisitPort
    {
        public double MaxCapacity { get; set; }
        protected double volume, weight;
        
        public OxygenBottle(double capacity)
        {
            MaxCapacity = capacity;
        }
        public double Volume
        {
            get { return volume; }
            set
            {
                volume = value;
                weight = value * 3;
            }
        }
        public double Weight
        {
            get { return weight; }
            set
            {
                weight = value;
                volume = value / 3;
            }
        }
        public double VisitPort()
        {
            volume = MaxCapacity;
            return 100;
        }
        public double GetCapacity()
        {
            return volume;
        }
    }
    class FoodContainer : IVisitPort
    {
        public double MaxCapacity { get; set; }
        protected double volume, weight;

        public FoodContainer(double capacity)
        {
            MaxCapacity = capacity;
        }
        public double Volume
        {
            get { return volume; }
            set
            {
                volume = value;
                weight = value * 30;
            }
        }
        public double Weight
        {
            get { return weight; }
            set
            {
                weight = value;
                volume = value / 30;
            }
        }
        public double VisitPort()
        {
            volume = MaxCapacity;
            return 100;
        }
        public double GetCapacity()
        {
            return volume;
        }
    }
    class Engine
    {
        private FuelTank tank;
        private Waste waste;

        public Engine(FuelTank tank, Waste waste)
        {
            this.tank = tank;
            this.waste = waste;
        }

        public double GetVelocity(double sumbarineWeight)
        {
            tank.Weight = sumbarineWeight;
            return 50000 / tank.Weight;
        }
        public bool CheckFuelBeforeTravel(double travelTime)
        {

            if (tank.Weight / travelTime * 1000 >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Travel(double travelTime)
        {
            tank.Weight -= travelTime * 1000;
            waste.Weight += travelTime * 1000;
        }
    }
    class LifeSupportSystem
    {
        private List<OxygenBottle> oxygenBottles;
        private FoodContainer foodContainer;
        private Waste waste;
        private List<Human> crew;

        public LifeSupportSystem(List<OxygenBottle> bottles, FoodContainer container, Waste waste, List<Human> crew)
        {
            this.oxygenBottles = bottles;
            this.foodContainer = container;
            this.waste = waste;
            this.crew = crew;
        }
        public bool CheckSuppliesBeforeTravel(double travelTime)
        {
            if(foodContainer.Weight / travelTime * 100 >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Run(double travelTime)
        {
            foodContainer.Weight -= travelTime * 100;
            waste.Weight += travelTime * 100;
            for (int i = 0; i < travelTime; i++)
            {
                if (oxygenBottles.Count == i) { break; }
                oxygenBottles[i].Weight = 0;
            }
        }
    }


}
