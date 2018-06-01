using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory.Entity
{
   public  class Cow:Animal
    {
        public override void Show()
        {
            Console.WriteLine("This is Cow.Show");
        }
    }
}
