using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace up_12
{
    class Cset
    {
        public delegate void AccountHandler(string message);
        public event AccountHandler Notify;              // 1.Определение события

        private dynamic[] list;

        public Cset(dynamic[] list)
        {
            this.list = list;
        }
        public static Cset operator +(Cset c1, Cset c2)
        {
            return new Cset(c1.list.Concat(c2.list).ToArray());
        }
        //public static Cset operator -(Cset c1, Cset c2)
        //{
        //    return new Cset(c1.list.Except(c2.list).ToArray());
        //}
        public static bool operator >=(Cset c1, Cset c2)
        {
            if (c1.Int() >= c2.Int())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator <=(Cset c1, Cset c2)
        {
            if (c1.Int() <= c2.Int())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int Int()
        {
            return list.Length;
        }
        public static Cset operator &(Cset c1, Cset c2)
        {

            return new Cset(c1.list.Except(c2.list).ToArray());


        }

        public  dynamic this[int i]
        {
            get
            {
                return list[i];
            }
            set
            {
                list[i] = value;
            }
        }
        public void DelElem(int index)
        {
            Notify?.Invoke($"был удален элем {list[index]}");
            list = list.Except(new dynamic[] { list[index] }).ToArray();
        }
        ~Cset()
        {
            Console.WriteLine( "Элемент удален.");
        }

    }
}

//  Класс – множество Сset.Дополнительно перегрузить следующие операции: + –
//  объединение множеств; &lt;=,&gt;= – сравнение множеств; int()– количество элементов
//  множества; &amp;– пересечение.Удаление элемента из множества.
//  Генерацию события по удалению элемента из массива. В обработчике указать значение
//  удаленного элемента