using SimpleFactory.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;

namespace SimpleFactory.Factory
{
   public  class SimFactory
    {
        private static string _animalConfig = ConfigurationManager.AppSettings["AnimalType"];
        private static string _animalAssembly = ConfigurationManager.AppSettings["AnimalAssembly"];
        public static Animal CreateAnimal(AnimalType animalType)
        {
            Animal animal = null;
            switch (animalType)
            {
                case AnimalType.Dog:
                    animal = new Dog();
                    break;
                case AnimalType.Cat:
                    animal = new Cat();
                    break;
                case AnimalType.Cow:
                    animal = new Cow();
                    break;
                default:
                    break;
            }
            return animal;
        }

        public static Animal CreateAnimalByConfig()
        {
            AnimalType type = (AnimalType)Enum.Parse(typeof(AnimalType), _animalConfig);
            return CreateAnimal(type);
        }
        public static Animal CreateAnimalByAssembly()
        {
            string[] assArr = _animalAssembly.Split(',');
            Assembly assembly = Assembly.Load(assArr[0]);
            Type type = assembly.GetType(assArr[1]);
            Animal animal = (Animal)Activator.CreateInstance(type);
            return animal;
        }
    }
    public enum AnimalType
    {
        Dog=1,Cat=2,Cow=3
    }
}
