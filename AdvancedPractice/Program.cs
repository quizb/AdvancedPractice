using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using static Program;

class Program
{
    static void Main(string[] args)
    {
        #region 继承
        var mydog = new Dog();
        mydog.Name = "旺财";
        mydog.Eat();
        mydog.barking();

        var mycat = new Cat();
        mycat.Speak();

        #endregion

        #region 构造函数链
        var myCar = new Car("XiaoMi");
        Console.WriteLine($"Model: {myCar.Model}, Wheels: {myCar.Wheels}");
        #endregion

        #region 抽象类
        Circle circle = new Circle { Radius = 5 };
        Console.WriteLine($"Circle Area: {circle.Area()}");

        Rectangle rectangle = new Rectangle { Width = 4, Height = 6 };
        Console.WriteLine($"Rectangle Area: {rectangle.Area()}");
        #endregion

        #region 密封类
        FinalClass finalClass = new FinalClass();
        finalClass.SomeMethod();
        #endregion

        #region 多态性
        // 创建一个包含不同支付方式的列表
        List<Payment> payments = new List<Payment> {
            new CreditCardPayment(),
            new PayPalPayment(),
            new BankTransferPayment()
        };

        // 遍历列表并调用 ProcessPayment 方法
        foreach (var payment in payments)
        {
            payment.ProcessPayment(100.0); // 各自实现不同的支付逻辑
        }
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
    public class Vehicle
    {
        public int Wheels { get; }

        public Vehicle(int wheels)
        {
            Wheels = wheels;

        }
    }
    public class Car : Vehicle
    {
        public string Model { get; }
        public Car(string model) : base(4)
        {
            Model = model;
        }

    }
    public abstract class Shape
    {
        public abstract double Area(); 
    }
    public class Circle : Shape
    {
        public double Radius { get; set; }
        public override double Area()
        {
            return Math.PI * Radius * Radius; // 实现抽象方法
        }
    }
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override double Area()
        {
            return Width * Height; // 实现抽象方法
        }
    }
    public sealed class FinalClass
    {
        public void SomeMethod()
        {
            Console.WriteLine("This is a method in a sealed class.");
        }
    }
    // 基类
    public abstract class Payment
    {
        public abstract void ProcessPayment(double amount);
    }

    // 派生类 CreditCardPayment
    public class CreditCardPayment : Payment
    {
        public override void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing credit card payment for ${amount}.");
        }
    }

    // 派生类 PayPalPayment
    public class PayPalPayment : Payment
    {
        public override void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing PayPal payment for ${amount}.");
        }
    }

    // 派生类 BankTransferPayment
    public class BankTransferPayment : Payment
    {
        public override void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing bank transfer payment for ${amount}.");
        }
    }
}