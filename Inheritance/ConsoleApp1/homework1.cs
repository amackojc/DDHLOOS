using System;

namespace ConsoleApp1
{
    class homework1
    {
        class parachute_jump
        {
            public int price;
            public string level;
            public int height;

            public parachute_jump(int _price, string _level, int _height)
            {
                this.price = _price;
                this.level = _level;
                this.height = _height;
            }
            public void PrintBase()
            {
                Console.WriteLine("Price: " + price);
                Console.WriteLine("Level: " + level);
                Console.WriteLine("Height: " + height);
            }

            public void jump()
            {
                Console.WriteLine("Aaaaa!");
            }

            public void open_parachute()
            {
                Console.WriteLine("Parachute opened");
            }

        }

        class solo_parachute_jump : parachute_jump
        {
            public string license;

            public solo_parachute_jump(int _price, string _level, int _height, string _license) : base(_price, _level, _height)
            {
                this.license = _license;
            }
        }

        class multi_parachute_jump : parachute_jump
        {
            public int number_of_people;

            public multi_parachute_jump(int _price, string _level, int _height, int _number_of_people) : base(_price, _level, _height)
            {
                this.number_of_people = _number_of_people;
            }
        }

        class tandem_jump : multi_parachute_jump
        {
            public tandem_jump(int _price, string _level, int _height, int _number_of_people) : base(_price, _level, _height, _number_of_people) { }

            public void instructor_help()
            {
                Console.WriteLine("Hold tight!");
            }
        }

        class skysurf_jump : solo_parachute_jump
        {
            string board_material; 

            public skysurf_jump(int _price, string _level, int _height, string _license, string _board_material) : base(_price, _level, _height, _license)
            {
                this.board_material = _board_material;
            }

            public void aerobraking()
            {
                Console.WriteLine("Reducing the falling speed");
            }

            public void somersault_in_the_air()
            {
                Console.WriteLine("Just make a somersault!");
            }
        }

        static void Main(string[] args)
        {
            parachute_jump first = new parachute_jump(100, "Easy", 1000);
            first.PrintBase();

            Console.WriteLine("\nSkysurf:");
            skysurf_jump second = new skysurf_jump(3000, "Hard", 3000, "AFF Pro",  "Wood");
            second.PrintBase();
            second.aerobraking();

            Console.WriteLine("\nMulti people jump:");
            multi_parachute_jump third = new multi_parachute_jump(500, "Medium", 1500, 3);
            third.PrintBase();
            third.open_parachute();

            Console.WriteLine("\nJump with instructor:");
            tandem_jump fourth = new tandem_jump(1200, "Beginner", 1600, 2);
            fourth.PrintBase();
            fourth.jump();
            fourth.instructor_help();
            fourth.open_parachute();

        }
    }
}
