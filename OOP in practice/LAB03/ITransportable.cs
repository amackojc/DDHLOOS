using System;
using System.Collections.Generic;
using System.Text;

namespace C3
{
    interface ITransportable
    {
        // anything we can transport is ITransportable
        // examples: people, food, waste, fuel, equipment
        // each transportable item has to know its volume in m^3 and weight in tonnes
        // important: if you change volume, weight should update automatically and vice versa
        // you can use any numbers you want - don't worry about being realistic
		// see Equipment.cs for an example implementation
        double Volume { get; set; } 
        double Weight { get; set; }

    }
    abstract class Human : ITransportable
    {
        protected double volume, weight;
        public double Volume
        {
            get { return volume; }
            set
            {
                volume = value;
                weight = value * 1.5;
            }

        }
        public double Weight 
        {
            get { return weight; }
            set
            {
                weight = value;
                volume = value / 1.5;
            }
        }
    }
    class Scientist : Human
    {
        Equipment equipment;
        public Scientist(Equipment equipment)
        {
            this.equipment = equipment;
        }
        
        public void Work(double Time)
        {
            Console.WriteLine($"Time work is: {Time}.");
        }
    }
    class Crewman : Human
    {

    }

    abstract class Fuel : ITransportable
    {
        public string Type { get; set; }
        protected double density;
        protected double volume, weight;
        public double Volume
        {
            get { return volume; }
            set
            {
                volume = value;
                weight = value * (density/1000);
            }
        }
        public double Weight 
        {
            get { return weight; }
            set
            {
                weight = value;
                volume = value / (density/1000);
            }
        }
        public abstract new string GetType();
    }

    class FuelNuclear : Fuel
    {
        public FuelNuclear()
        {
            this.density = 10;
        }
        public override string GetType()
        {
            return this.Type;
        }


    }
    class FuelDiesel : Fuel
    {
        public FuelDiesel()
        {
            this.density = 9;
        }
        public override string GetType()
        {
            return this.Type;
        }
    }
}
