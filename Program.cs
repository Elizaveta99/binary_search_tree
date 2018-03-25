using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binary_search_tree
{
    class Walk<T> : IVisit<T> where T : IComparable 
    {
        public void visit(T data)
        {
            Console.Write("{0} ", data.ToString());
        }
    }

    class Walk_Search<T> : Walk<T>, IVisit_Search<T> where T : IComparable
    {
        public void visit(T data, ref T mx, ref T mn)
        {
            // Math.Max использовать
            if ((data).CompareTo(mx) > 0) mx = data;
            if ((data).CompareTo(mn) < 0) mn = data;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Tree_Search<int> tr = new Tree_Search<int>();
            Console.WriteLine("Введите количество элементов дерева :");
            int num_nodes = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите элементы дерева :");
            for (int i = 0; i < num_nodes; i++)
            {
                int temp = Int32.Parse(Console.ReadLine());
                if (tr.Insert(temp)) Console.WriteLine("{0} вставлено успешно!", temp); 
                else Console.WriteLine("{0} не удалось вставить!", temp);
            }
            Console.WriteLine("Дерево до удаления : ");
            tr.SortedLeftTreeWalk_out(new Walk<int>());
            Console.WriteLine();

            int mx = -Int32.MaxValue, mn = Int32.MaxValue;
            //(tr as Tree_Search<int>).SortedLeftTreeWalk_search(new Walk_Search<int>(), ref mx, ref mn);
            tr.SortedLeftTreeWalk_search(new Walk_Search<int>(), ref mx, ref mn);

            if (tr.Delete(mx)) Console.WriteLine("Удаление максимального значения листа выполнено успешно!");
            else
                Console.WriteLine("Удаление максимального значения невозможно.");
            if (tr.Delete(mn)) Console.WriteLine("Удаление минимального значения листа выполнено успешно!");
            else
                Console.WriteLine("Удаление минимального значения невозможно.");
            Console.WriteLine("Дерево после удаления : ");
            tr.SortedLeftTreeWalk_out(new Walk<int>());  
            Console.ReadKey();
        }
    }
}
