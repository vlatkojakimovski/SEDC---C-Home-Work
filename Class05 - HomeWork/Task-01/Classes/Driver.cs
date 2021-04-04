using System;
using System.Collections.Generic;
using System.Text;

namespace Task_01.Class
{
    class Driver
    {
        public string Name { get; set; }
        public int Skill { get; set; }

        public Driver()
        {

        }
        public Driver(string name, int skill)
        {
            Name = name;
            Skill = skill;
        }

    }
}
