using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace up_12
{
    class Program
    {

        static void Main(string[] args)
        {
            Cset c1 = new Cset(new dynamic[] { 2 });

            Cset c2 = new Cset(new dynamic[] { 4 });
            Cset c3 = c1 + c2;
            Console.WriteLine(c3[0]);
            c3.Notify += DisplayMessage;
            c3.DelElem(0);
            // Добавляем обработчик для события Notify
            Console.WriteLine("Введите n");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(c3[0]);
            Cset[] csets = new Cset[]
            {
                new Cset (new dynamic[]{ 3,false,"efd"}),
                new Cset (new dynamic[]{ 4,3,3}),
                new Cset (new dynamic[]{ true,"joopa","efd"}),
                new Cset (new dynamic[]{ 6,5,"54"}),
            };
            for (int i = 0; i < csets.Length; i++)
            {
                if (csets[i].Int() == n)
                {
                    Console.WriteLine($"найден сет с размерностью n - {i}");
                }
            }
            int max = 0;
            for (int i = 0; i < csets.Length; i++)
            {
                if (csets[i].Int()>max)
                {
                    max = csets[i].Int();
                }
            }
            for (int i = 0; i < csets.Length; i++)
            {
                if (csets[i].Int() == max)
                {
                    Console.WriteLine($"{i} сет имеет макс колво элемов");
                }
            }

        }
        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

}
//  создать объект CollectionType&lt; T & gt;, содержащий массив обобщённых
//  коллекций, запросы – найти коллекции размера n; найти максимальную
//  и минимальную коллекцию в массиве по количеству элементов.
//  Создать полный клон объекта, учитывая, что каждый элемент
//  коллекции, реализует интерфейс IClonable. Обобщенная коллекция –
//  LinkedList&lt; T & gt;.