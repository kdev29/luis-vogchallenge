using System;
using System.Collections.Generic;
using System.Linq;

namespace VogCodeChallenge.Console.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("----ITERATIONS EXCERSICE---");

            QuestionClass.IterationMethod1();
            System.Console.WriteLine("------------------");
            QuestionClass.IterationMethod2();

            System.Console.WriteLine("-------TESTModule calls-----------");
            System.Console.WriteLine(TESTModule<int>(3));
            System.Console.WriteLine(TESTModule<int>(5));
            System.Console.WriteLine(TESTModule<string>("test"));
            System.Console.WriteLine(TESTModule<TestClass>(new TestClass()));
        }

        static T TESTModule<T>(T argument)
        {            
            switch(Type.GetTypeCode(argument.GetType()))
            {
                case TypeCode.Int32:
                    var actualValue = Convert.ToInt32(argument);

                    if (actualValue < 0)
                        throw new ApplicationException("Provided value cannot be below zero");

                    if (actualValue > 0 && actualValue <= 4)
                        return (T)Convert.ChangeType(actualValue, typeof(T));

                    return (T)Convert.ChangeType(actualValue * 3, typeof(T));

                case TypeCode.Double:
                    var doubleValue = Convert.ToDouble(argument);
                    if (doubleValue == 1.0f || doubleValue == 2.0f)                    
                        return (T)Convert.ChangeType(3.0f, typeof(T));

                    return argument;

                case TypeCode.String:
                    return (T)Convert.ChangeType(argument.ToString().ToUpper(), typeof(T));
                    
                default:
                    return argument;
            }
        }
    }

    public class TestClass
    {

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
