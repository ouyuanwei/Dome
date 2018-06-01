using AssemblyInterFace.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyInterFace.Implement
{
    public class SheepService : ISheepService
    {
        public void Sheep()
        {
            Console.WriteLine("睡觉");
        }
    }
}
