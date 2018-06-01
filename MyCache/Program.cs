using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MyCache.Cache;
using MyCache.Entity;

namespace MyCache
{
    class Program
    {
        static void Main(string[] args)
        {
            //自定义缓存 

            var count = 0;
            GenericCache.AddCache<string>("string_key", "cache", 10);
            GenericCache.RemoveCache(m => m == "string_key");
            GenericCache.RemoveCache("string_key");

            //GenericCache.AddCache<int>("int_key", 123456789, 10);
            //for (int i = 0; i < 100; i++)
            //{
            //    Task.Run(() =>
            //    {

            //        var data = GenericCache.GetCache<string>("string_key");
            //        var data2 = GenericCache.GetCache<int>("int_key");
            //        Console.WriteLine("第{0}次数据:{1}-------{2}", ++count, data, data2);
            //        GenericCache.RemoveCache("string_key");
            //        GenericCache.RemoveCache(m => m == "string_key");
            //        Thread.Sleep(1000);
            //    });
            //}

            //GenericCache.AddCache<Student>("Student_Id=1", new Student { Id = 1, Age = 20, BrithDay = DateTime.Parse("1991/01/01"), Name = "Jack", Sex = "M" }, 5);

            GenericCache.AddCache<string>("Student_Id=1", "123", 5);
            GenericCache.AddCache<int>("Student_Id=12", 123, 5);
            var stu = GenericCache.GetCache<string>("Student_Id=1");
            Console.WriteLine("Data in Cache Value is {0}", stu);

            Thread.Sleep(1000 * 12);
            var stu2 = GenericCache.GetCache<string>("Student_Id=1");
            Console.WriteLine("Data in Cache Value is {0}", stu2);

            Console.ReadKey();
        }
    }
    
}
