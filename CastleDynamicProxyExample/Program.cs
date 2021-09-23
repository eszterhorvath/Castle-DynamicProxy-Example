using System;
using System.Collections.Generic;

namespace CastleDynamicProxyExample
{
    public class Program
    {
        static void Main(string[] args)
        {
            var person = Freezable.CreateFreezable<Person>();
            
            person.FirstName = "John";
            person.LastName = "Smith";
            person.Age = 24;
            Console.WriteLine(person.ToString());

            person.FirstName = "David";
            Console.WriteLine(person.ToString());

            Freezable.Freeze(person);
            person.LastName = "Jones";
        
        }
    }
}
