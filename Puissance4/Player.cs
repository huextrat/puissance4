using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puissance4
{
    public class Player
    {
        public String Name { get; set; }
        public char ID { get; set; }

        public Player(String name, char id)
        {
            Name = name;
            ID = id;
        }

        
    }
}
