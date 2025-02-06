using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        const int count = 1_000_000;

        // ArrayList测试
        var arrayList = new ArrayList();
        var sw = Stopwatch.StartNew();
        for (int i = 0; i < count; i++)
        {
            arrayList.Add(i); // 装箱发生
        }
        sw.Stop();
        Console.WriteLine($"ArrayList添加耗时：{sw.ElapsedMilliseconds}ms");

        // List<int>测试
        var genericList = new List<int>();
        sw.Restart();
        for (int i = 0; i < count; i++)
        {
            genericList.Add(i); // 无装箱
        }
        sw.Stop();
        Console.WriteLine($"List<T>添加耗时：{sw.ElapsedMilliseconds}ms");
    }
}