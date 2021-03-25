using System;
using System.Collections.Generic;
using System.Linq;

namespace VogCodeChallenge.Console.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");

            QuestionClass.IterationMethod1();
            System.Console.WriteLine("------------------");
            QuestionClass.IterationMethod2();
        }
    }

    public static class QuestionClass
    {
        static List<string> NamesList = new List<string>()
        {
            "Jimmy",
            "Jeffrey",
            "John",
        };

        public static void IterationMethod1()
        {
            System.Console.WriteLine("Iteration method 1 -> using while");

            var listLength = NamesList.Count;
            var indexer = 0;

            while (indexer < listLength) 
            {
                System.Console.WriteLine(NamesList[indexer]);
                indexer++;
            }            
        }

        public static void IterationMethod2()
        {
            System.Console.WriteLine("Iteration method 2 -> using Linq Select");

            NamesList.Select(name => { System.Console.WriteLine(name); return name; }).ToList();
        }
    }

}
