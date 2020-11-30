using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace lab12_9
{
    class Programs
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nTask1");
            Owner pass1 = new Owner() { };
            Type type1 = pass1.GetType();
            Console.WriteLine($"\nТип: {type1}");

            Console.WriteLine($"\n{type1} Сборка :");
            Reflector.AssemblyName(pass1);

            Console.WriteLine($"\n{type1} Конструкторы:");
            Reflector.PublicConstructors(pass1);

            Console.WriteLine($"\n{type1} Методы:");
            Reflector.Methods(pass1);

            Console.WriteLine($"\n{type1} Свойства:");
            Reflector.Properties(pass1);

            Console.WriteLine($"\n{type1} Поля:");
            Reflector.Fields(pass1);

            Console.WriteLine($"\n{type1} Интерфейсы:");
            Reflector.Interfaces(pass1);

            string p = "String";
            Console.WriteLine($"\n {type1} Методы с параметрами {p}");
            Reflector.MethodsByParametr(pass1, p);

           
            Console.WriteLine($"\n Вызываем метод:");
            Reflector.Invoke(pass1, "Owner1", Reflector.ParamsGenerater("lab12_9.Owner", "Owner1"));

            Console.WriteLine($"\n Вызываем метод:");
            Reflector.Invoke(pass1, "Owner1", Reflector.FileRead("lab12_9.Owner", "Owner1"));

            Cowner<int, string> cowner1 = new Cowner<int, string>(3, "boook1");
            Type type2 = cowner1.GetType();
            Console.WriteLine($"\nТип: {type2}");

            Console.WriteLine($"\n{type2} Сборка :");
            Reflector.AssemblyName(cowner1);

            Console.WriteLine($"\n{type2} Конструкторы:");
            Reflector.PublicConstructors(cowner1);

            Console.WriteLine($"\n{type2} Методы:");
            Reflector.Methods(cowner1);

            Console.WriteLine($"\n{type2} Свойства:");
            Reflector.Properties(cowner1);

            Console.WriteLine($"\n{type2} Поля:");
            Reflector.Fields(cowner1);

            Console.WriteLine($"\n{type2} Интерфейсы:");
            Reflector.Interfaces(cowner1);

            string p2 = "Int32";
            Console.WriteLine($"\n{type2} Методы с параметром {p2}:");
            Reflector.MethodsByParametr(cowner1, p2);

            Console.WriteLine($"\nВызывыем метод:");
            Reflector.Invoke(cowner1, "Owner2", Reflector.ParamsGenerater("lab12_9.Cowner`2[System.Int32,System.String]", "Owner2"));

            Console.WriteLine($"\nВызывыем метод:");
            Reflector.Invoke(cowner1, "Owner2", Reflector.FileRead("lab12_9.Cowner`2[System.Int32,System.String]", "Owner2"));




            Console.WriteLine("\nTask2");
            Console.WriteLine($"Создаём объект:");
            Type type3 = pass1.GetType();
            Reflector.Create(type3);












            List<IComparable>.Output_Autor();
        }


    }
}
