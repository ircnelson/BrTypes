﻿using System;
using System.Diagnostics;
using BrTypes;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            // var cpf1 = Cpf.Parse("61709754079");
            // var cpf2 = Cpf.Parse("27823643081");
            // var cpf3 = Cpf.Parse("18171528074");

            
            var sw = new Stopwatch();
            var before2 = GC.CollectionCount(2);
            var before1 = GC.CollectionCount(1);
            var before0 = GC.CollectionCount(0);
            
            sw.Start();
            for (int i = 0; i < 1_000_000; i++)
            {
                if (!Cpf.TryParse("61709754079", out _))
                    throw new ApplicationException("Error");
                if (Cpf.TryParse("61709754070", out _))
                    throw new ApplicationException("Error");
            }
            sw.Stop();
            
            Console.WriteLine($"Tempo total: {sw.ElapsedMilliseconds}ms");
            Console.WriteLine($"GC Gen #2 : {GC.CollectionCount(2) - before2}");
            Console.WriteLine($"GC Gen #1 : {GC.CollectionCount(1) - before1}");
            Console.WriteLine($"GC Gen #0 : {GC.CollectionCount(0) - before0}");
            Console.WriteLine("Done!");
        }
    }
}