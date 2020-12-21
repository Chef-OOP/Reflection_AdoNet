using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionType
{
    class Program
    {
        static void Main(string[] args)
        {
            ReflectionType<Person>();

            Console.ReadLine();
        }
        static void ReflectionType<T>()
            where T : class, new()
        {
            Type t = typeof(T);

            T type = new T();
            List<T> types = new List<T>();
            types.Add(type);
            //if (t.IsClass)
            //{
            //    var type = Activator.CreateInstance(typeof(T));
            //}
            Console.WriteLine("Namespace: " + t.Namespace);
            Console.WriteLine("Name: " + t.Name);
            Console.WriteLine("Fullname: " + t.FullName);
            Console.WriteLine("Base Type:" + t.BaseType);
            Console.WriteLine("IsClass: " + t.IsClass);
            Console.WriteLine("IsAbstract: " + t.IsAbstract);
            Console.WriteLine("IsInterface: " + t.IsInterface);
            Console.WriteLine("------Fields------");
            foreach (var item in t.GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                Console.WriteLine(item.Name + " " + item.FieldType);
            }
            Console.WriteLine("-----------------");
            foreach (var member in t.GetMembers())
                Console.WriteLine("Name: " + member.Name + " " + member.MemberType);
            Console.WriteLine("-----------------");
            foreach (var property in t.GetProperties())
            {
                if (property.PropertyType == typeof(string))
                    property.SetValue(type, "Cihan");
                if (property.PropertyType == typeof(int))
                    property.SetValue(type, 36);
            }
            foreach (var item in t.GetProperties())
            {
                Console.WriteLine(item.GetValue(type));
            }
            Console.WriteLine("----------MethodInfo------------");
            foreach (var item in t.GetMethods())
            {
                if (item.ReturnType == typeof(string))
                    Console.WriteLine(item.Invoke(type, null));
            }
        }
    }
    static class IPerson { }
    class Person : Customer
    {
        public int Id;
        private int _Age;
        public string Name { get; set; }
        public int Age { get; set; }
        public void FullInfo()
        {
            Console.WriteLine("FullInfo Çalıştı");
        }
        public string FullName() => Name + " " + Age;

    }
    class Customer
    {

    }
}
