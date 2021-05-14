using System;
using System.Collections.Generic;

namespace homework2_2
{ 
    class Resident
    {
        protected int food_units;

        public Resident(int _food_units)
        {
            food_units = _food_units;
        }
        public int Eat()
        {
            return food_units;
        }
    }
    class Defender : Resident
    {
        public Defender(int _food_units) : base(_food_units) { }
        public virtual string ReadyToFight()
        {
            return "I'm ready to defend my country!";
        }

        public override string ToString()
        {
            return "I'm a defender!";
        }
    }
    
    class Civilian : Resident
    {
        public Civilian(int _food_units) : base(_food_units) { }

        public override string ToString()
        {
            return "I'm a civilian!";
        }
    }

    class Pikeman : Defender
    {
        public Pikeman(int _food_units) : base(_food_units) { }

        public override string ReadyToFight()
        {
            return "My spear will gore your body!";
        }
        public override string ToString()
        {
            return "I'm a pikeman!";
        }
    }

    class Crossbowman : Defender
    {
        public Crossbowman(int _food_units) : base(_food_units) { }

        public override string ReadyToFight()
        {
            return "My crossbow is ready to fire!";
        }
        public override string ToString()
        {
            return "I'm a crossbowman!";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Resident> Residents = new List<Resident>();
            List<Defender> Defenders = new List<Defender>();
            List<Crossbowman> Crossbowmen = new List<Crossbowman>();

            //Defenders 
            Defenders.Add(new Defender(40));
            Defenders.Add(new Defender(43));
            Defenders.Add(new Crossbowman(33));
            Defenders.Add(new Pikeman(43));
            Defenders.Add(new Crossbowman(30));

            //Pikemen
            Crossbowmen.Add(new Crossbowman(34));
            Crossbowmen.Add(new Crossbowman(40));
            Crossbowmen.Add(new Crossbowman(31));
            Crossbowmen.Add(new Crossbowman(25));

            //Residents
            Residents.Add(new Pikeman(50));
            Residents.Add(new Defender(22));
            Residents.Add(new Crossbowman(35));
            Residents.Add(new Civilian(15));

            Console.WriteLine("Method ReadyToFight() for defenders:");
            foreach (Defender i in Defenders) Console.WriteLine($"{i.ReadyToFight()}");

            Console.WriteLine("\nMethod ReadyToFight() for crossbowmen:");
            foreach (Crossbowman i in Crossbowmen) Console.WriteLine($"{i.ReadyToFight()}");

            Console.WriteLine("\nMethod ReadyToFight() for defenders:");
            foreach (Resident i in Residents) Console.WriteLine($"{i.ToString()} My food unit is: {i.Eat()}");
        }
    }
}
