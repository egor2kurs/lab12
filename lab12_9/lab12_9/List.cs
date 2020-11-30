
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;

namespace lab12_9
{





    public static class Reflector
    {

        public static void AssemblyName(object obj)
        {
            Type type = obj.GetType();
            FileSave(type.Assembly);
        }
        public static void PublicConstructors(object obj)
        {
            Type type = obj.GetType();
            ConstructorInfo[] Ci = type.GetConstructors();
            foreach (ConstructorInfo ci in Ci)
            {
                FileSave(ci);
            }
        }
        public static void Methods(object obj)
        {
            Type type = obj.GetType();
            MethodInfo[] Mi = type.GetMethods();
            foreach (MethodInfo mi in Mi)
            {
                FileSave(mi);
            }
        }
        public static void Properties(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] Pi = type.GetProperties();
            foreach (PropertyInfo pi in Pi)
            {
                FileSave(pi);
            }
        }
        public static void Fields(object obj)
        {
            Type type = obj.GetType();
            FieldInfo[] Fi = type.GetFields();
            foreach (FieldInfo fi in Fi)
            {
                FileSave(fi);
            }
        }
        public static void Interfaces(object obj)
        {
            Type type = obj.GetType();
            Type[] Fi = type.GetInterfaces();
            foreach (Type fi in Fi)
            {
                FileSave(fi);
            }
        }

        public static void MethodsByParametr(object obj, string parametr)
        {
            Type type = obj.GetType();
            MethodInfo[] Fi = type.GetMethods();
            foreach (MethodInfo fi in Fi)
            {
                string str = fi.ToString();
                if(str.Contains(parametr))
                FileSave(fi);
            }
        }

        public static object Invoke(object obj, string methodName, params object[] parametrs)
        {

            MethodInfo obMethod = obj.GetType().GetMethod(methodName);
            return obMethod.Invoke(obj, parametrs);
        }
        public static object[] ParamsGenerater(string ClassName, string MethodName)//генератор значений
        {
            Type type = Type.GetType(ClassName);
            Console.WriteLine(type.Name);

            MethodInfo[] Met = type.GetMethods();

            int index = 0;
            string[] nameT = new string[16];

            foreach (var m in Met)
            {
                ParameterInfo[] pars = m.GetParameters();
                if (m.Name == MethodName)
                {

                    foreach (var p in pars)
                    {
                        nameT[index] = Convert.ToString(p.ParameterType);
                        index++;
                    }
                }
            }

            object[] param = new object[index];
            Random rnd = new Random();
            for (int i = 0; nameT[i] != null; i++)
            {
                switch (nameT[i])
                {
                    case "System.Int32":
                        param[i] = rnd.Next(50);
                        break;
                    case "System.String":
                        int size = rnd.Next(3, 12);
                        string str = "";
                        for (int ind = 1; ind < size; ind++)
                        {
                            str += Convert.ToChar(rnd.Next(65, 90));
                        }
                        param[i] = Convert.ToString(str); break;
                    case "System.Char":
                        param[i] = Convert.ToChar(rnd.Next(65, 90));
                        break;
                    case "System.Boolean":
                        param[i] = Convert.ToBoolean(rnd.Next(0, 1));
                        break;

                    default: break;
                }
            }
            return param;
        }

        public static object[] FileRead(string ClassName, string MethodName)
        {
            Type type = Type.GetType(ClassName);
            Console.WriteLine(type.Name);

            MethodInfo[] Met = type.GetMethods();

            int index = 0;
            string[] nameT = new string[16];

            foreach (var m in Met)
            {
                ParameterInfo[] pars = m.GetParameters();
                if (m.Name == MethodName)
                {

                    foreach (var p in pars)
                    {
                        nameT[index] = Convert.ToString(p.ParameterType);
                        index++;
                    }
                }
            }
            string readPath = @"D:\12labReadFile2.txt";

            StreamReader sr = new StreamReader(readPath);
            object[] param = new object[index];
            for (int i = 0; nameT[i] != null; i++)
            {

                while (!sr.EndOfStream)
                {
                    object line = sr.ReadLine();
                    if (line.GetType().ToString() == nameT[i])
                    {
                        param[i] = line;
                        break;
                    }
                }

            }
            sr.Close();
            return param;
        }

        public static Object Create(Type cl)
        {
            Console.WriteLine("объект создан");
            return Activator.CreateInstance(cl);
        }



        public static void FileSave(object obj)
        {

            string writePath = @"D:\12lab.txt";
            StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default);
            sw.WriteLine(obj);
            sw.Close();
            StreamReader sr = new StreamReader(writePath);
            Console.WriteLine(sr.ReadLine());
            sr.Close();
        }
    }






    //отсюда берутся все параметры

    public class Owner //является вложенным
    {
        public int ID;
        public string name;
        public string organisation;
        public Owner()
        {
            ID = 0;
            name = null;
            organisation = null;
        }
        public Owner(int ID, string name, string organisation)
        {
            this.ID = ID;
            this.name = name;
            this.organisation = organisation;
        }
       public static Owner egor = new Owner(123, "egor", "BSTU");

        public void Owner1(string str, int i)
        {
            Console.WriteLine(str + i);
        }
    }

    public class Cowner<Tkey, TValue> //является вложенным
    {
        public int ID;
        public string name;
       
        public Cowner()
        {
            ID = 0;
            name = null;
            
        }
        public Cowner(int ID, string name)
        {
            this.ID = ID;
            this.name = name;
            
        }

        public void Owner2(string str, int i)
        {
            Console.WriteLine(i + str);
        }
    }





    public class List<T> where T : IComparable
    {
        private const string V = "";
        private Item<T> head;
        private Item<T> tail;
        private int count;
        
        public class Date
        {
            public DateTime date = DateTime.Now;
            public Date()
            {

            }
        }
        public int Count
        {
            get
            {
                return count;
            }
        }
        public Item<T> First
        {
            get
            {
                return head;
            }
        }
        public List()
        {

        }


        public void AddAfter(Item<T> node, T value) //добовляет значение после существуюшего
        {
            Item<T> newNode = new Item<T>(value, node.Next);
            node.Next = newNode;

            count++;
        }
        public void Add(T value)
        {
            if (head == null)
            {
                head = tail = new Item<T>(value, null);
                count++;
            }
            else
            {
                AddAfter(tail, value);
                tail = tail.Next;
            }
        }
        public Item<T> Find(T value) //ищет элемент
        {
            Item<T> ptr = head;
            while (ptr != null)
            {
                if (ptr.Value.CompareTo(value) == 0) //сравнивает данный экземпляр с заданным объектом
                    return ptr;
                ptr = ptr.Next;
            }
            return null;
        }
        public static List<T> operator +(List<T> list1, List<T> list2) //перегрузка сложения 
        {
            var node1 = list1.First;
            var node2 = list2.First;
            while (node1 != null)
            {
                node1 = node1.Next;
                if (node1.Next == null)
                {
                    node1.Next = node2;
                    break;
                }
            }
            return list1;
        }
        public static List<T> operator --(List<T> list) //перегурзка дикримент
        {
            var node = list.head;
            list.head = null;
            list.head = node.Next;
            return list;
        }
        public static bool operator ==(List<T> list1, List<T> list2) //перегрузка на сравнение
        {
            bool check = false;
            var node1 = list1.First;
            var node2 = list2.First;
            while (node1 != null && node2 != null)
            {

                if (node1.Value.CompareTo(node2.Value) == 0)
                {
                    check = true;
                }
                node1 = node1.Next;
                node2 = node2.Next;
            }
            return check;
        }
        public static bool operator !=(List<T> list1, List<T> list2) //Перегрузка на неравность
        {
            bool check = true;
            var node1 = list1.First;
            var node2 = list2.First;
            while (node1 != null && node2 != null)
            {

                if (node1.Value.CompareTo(node2.Value) == 0) 
                {
                    check = false;
                }
                node1 = node1.Next;
                node2 = node2.Next;
            }
            return check;
        }
        public void Delete(T data) //удаление
        {
            if(head != null)
            {
                if (head.Value.Equals(data)) //сравнение
                {
                    head = head.Next;
                    count--;
                    return;
                }
                var current = head.Next;
                var previous = head;
                while(current != null)
                {
                    if (current.Value.Equals(data)) // удаляет первый элемент 
                    {
                        previous.Next = current.Next;
                        count--;
                        return;
                    }
                    previous = current;
                    current = current.Next;
                }
            }
        }

        
        public static void Output_Autor()
        {
            Console.WriteLine("Выполнил: №" + Convert.ToString(Owner.egor.ID) + " " + Owner.egor.name + " из " + Owner.egor.organisation);
            Console.WriteLine("--------------------------------------------------------------------------------------------------------\n");
        }
    }
    public static class StatisticOperation // без объявления элемента класса
    {
        public static int Counter(List<string> list) //выводит количество элементов в списке
        {
            int count = 0;
            var node = list.First;
            while (node != null)
            {
                node = node.Next;
                count++;
            }
            return count;
        }


        public static char Last_num_in_string(this string str1)
        {
            char g = ' ';
            int i = 0;
            while (i + 1 <= str1.Length)
            {
                for (int j = 0; j < str1.Length; j++)
                {
                    if (str1[i].ToString() == j.ToString())
                    {
                        g = str1[i];
                    }
                }
                i++;
            }
            return g;
        }
    }


}
