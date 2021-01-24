using System;
using System.Collections.Generic;

namespace OwnCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new MyCollection<int>();
            list.Add(44);
            list.Add(56);
            list.Add(34);
            list.Add(22);
            list.Add(11);
            list.Add(89);
            list.Add(18);
            list.Reverse();


            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }


        }
    }
}
