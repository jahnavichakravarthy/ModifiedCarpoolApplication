using System;
using System.Collections.Generic;
using System.Text;

namespace CarpoolApplication.helper
{
    public class Dsiplayervices
    {
        public void Print(string data)
        {
            Console.WriteLine($"{data}"); ;
        }

        public string Scan()
        {
            string data;
            data = Console.ReadLine();
            return data;
        }
    }
}
