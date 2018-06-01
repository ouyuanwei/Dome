using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using AssemblyInterFace.InterFace;
using System.Configuration;

namespace AssemblyInterFace.CreateBll
{
    public class CreateImplement
    {
        private static Dictionary<Type, string> _dicAssemblyStr = new Dictionary<Type, string>();
        private static Dictionary<Type, IBaseInterface> _dicImplement = new Dictionary<Type, IBaseInterface>();
        private static readonly string bllStr = ConfigurationManager.AppSettings["Assembly_Bll"];
        private static Type[] assTypeArr = null;
        private static readonly object _lock = new object();
        static CreateImplement()
        {
            _dicAssemblyStr.Add(typeof(IPalyService), "AssemblyInterFace,AssemblyInterFace.Implement.PalyService");
            _dicAssemblyStr.Add(typeof(ISheepService), "AssemblyInterFace,AssemblyInterFace.Implement.SheepService");
            _dicAssemblyStr.Add(typeof(IStudyService), "AssemblyInterFace,AssemblyInterFace.Implement.StudyService");
            AssemblyTypes();
        }
        private static void AssemblyTypes()
        {
            if (!string.IsNullOrEmpty(bllStr))
            {
                try
                {
                    Assembly assembly = Assembly.Load(bllStr);
                    if (assembly != null)
                    {
                        assTypeArr = assembly.GetTypes();
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
        public static T ImplementCreate<T>() where T : IBaseInterface
        {
            if(!typeof(T).IsInterface)
            {
                throw new Exception("Your Input T Is Not Interface ,Please Check Type of T");
            }
            if (!DicExist(typeof(T)))
            {
                lock (_lock)
                {
                    if (!DicExist(typeof(T)))
                    {
                        CreateBllByDic<T>();
                    }
                }
            }
            return (T)_dicImplement[typeof(T)];
        }
        private static bool DicExist(Type type)
        {
            return _dicImplement.ContainsKey(type);
        }
        private static void CreateBllByDic<T>() where T : IBaseInterface
        {
            try
            {
                if (!CreateBllByConfig<T>())
                {
                    if (!_dicAssemblyStr.ContainsKey(typeof(T)))
                    {
                        throw new Exception(string.Format("Here is not find {0}", typeof(T).Name));
                    }
                    string typeName = _dicAssemblyStr[typeof(T)];
                    string[] assStr = typeName.Split(',');
                    if (assStr.Length < 2)
                    {
                        throw new Exception(string.Format("Key:{0} in _dicImplement of value length less then 2", typeof(T).Name));
                    }
                    Assembly assembly = Assembly.Load(assStr[0]);
                    Type type = assembly.GetType(assStr[1]);
                    var t = (T)Activator.CreateInstance(type);
                    _dicImplement.Add(typeof(T), t);
                    Console.WriteLine("Create InterFace:{0} By Dic Success", typeof(T).Name);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Key:{0} in _dicImplement of value is error", typeof(T).Name));
            }
        }
        private static bool CreateBllByConfig<T>() where T : IBaseInterface
        {
            if (assTypeArr == null || assTypeArr.Length < 1)
            {
                return false;
            }
            try
            {
                foreach (var item in assTypeArr)
                {
                    if (item.GetInterface(typeof(T).Name) != null)
                    {
                        var t = (T)Activator.CreateInstance(item);
                        _dicImplement.Add(typeof(T), t);
                        Console.WriteLine("Create InterFace:{0} By Config Success", typeof(T).Name);
                        break;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
