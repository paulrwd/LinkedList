using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new Model.LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            list.Delete(4);


            foreach(var a in list)
            {
                Console.WriteLine(a);
            }

            Console.ReadLine();

            //1



        }
    }
}
