using System;
using System.Collections.Generic;
using System.Text;

namespace PocoApp
{
    internal class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
