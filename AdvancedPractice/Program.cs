using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        #region
        var mydog = new Dog();
        mydog.Name = "旺财";
        mydog.Eat();
        mydog.barking();

        var mycat = new Cat();
        mycat.Speak();

        #endregion



        #region 泛型，装箱与不装箱的比较
        //const int count = 1_000_000;

        //// ArrayList测试
        //var arrayList = new ArrayList();
        //var sw = Stopwatch.StartNew();
        //for (int i = 0; i < count; i++)
        //{
        //    arrayList.Add(i); // 装箱发生
        //}
        //sw.Stop();
        //Console.WriteLine($"ArrayList添加耗时：{sw.ElapsedMilliseconds}ms");

        //// List<int>测试
        //var genericList = new List<int>();
        //sw.Restart();
        //for (int i = 0; i < count; i++)
        //{
        //    genericList.Add(i); // 无装箱
        //}
        //sw.Stop();
        //Console.WriteLine($"List<T>添加耗时：{sw.ElapsedMilliseconds}ms");
        #endregion
    }


    public class Animal
    {
        public string Name { get; set; }
        public void Eat() { Console.WriteLine($"{Name} is eating "); }
         public virtual void Speak() { Console.WriteLine("Animal sound"); }
    }
    
    public class Dog : Animal 
    {
        public void barking() { Console.WriteLine("Wow! Wow!!"); }
    }

    public class Cat : Animal
    {
        public override void Speak() { Console.WriteLine("Meow");base.Speak(); }
    }
}