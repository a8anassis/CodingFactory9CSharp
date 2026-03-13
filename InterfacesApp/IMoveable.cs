using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesApp
{
    internal interface IMoveable
    {
        void Move5();

        void Move10()
        {
            Console.WriteLine("Moving 10 steps");
        }
    }
}
