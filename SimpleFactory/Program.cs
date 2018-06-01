using SimpleFactory.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleFactory.Factory;

namespace SimpleFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            //SimpleFactory 简单工厂模式
            Animal animal = SimFactory.CreateAnimal(AnimalType.Dog);
            animal.Show();
            //SimpleFactory + Config 简单工厂+配置
            Animal animal2 = SimFactory.CreateAnimalByConfig();
            animal2.Show();
            //SimpleFactory + Config + Assembly  简单工厂+配置+反射
            Animal animal3 = SimFactory.CreateAnimalByAssembly();
            animal3.Show();

            Console.ReadKey();
        }
    }
}
