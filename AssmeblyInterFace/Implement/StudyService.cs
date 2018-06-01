using AssemblyInterFace.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyInterFace.Implement
{
    public class StudyService : IStudyService
    {
        public void Study()
        {
            Console.WriteLine("学习");
        }
    }
}
