using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory.Entity
{
   public  class Dog:Animal
    {
        public override void Show()
        {
            Console.WriteLine("This is  Dog.Show");
        }
    }
}
