using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeEx9
{
    public class Point
    {
        int data;
        Point next;
        public Point(int value = 0)
        {
            data = value;
            next = null;
        }
        public override string ToString()
        {
            return data + " ";
        }
        static Point MakeAPoint(int value)
        {
            Point nPoint = new Point(value);
            return nPoint;
        }
        static int GetValue()
        {
            int nData = Program.ScanInt();
            Console.WriteLine("Элемент {0} теперь в списке!", nData);
            return nData;
        }
        static int GetValue(Random rnd)
        {
            int nData = rnd.Next(-1000, 1001);
            Console.WriteLine("Элемент {0} теперь в списке!", nData);
            return nData;
        }
        public static Point MakeRndList(int size)
        {
            if (size == 0)
                return null;
            Random rnd = new Random();
            Point head = MakeAPoint(GetValue(rnd));
            Point cur = head;
            while (cur.next != null)
            {
                cur.next = MakeAPoint(GetValue(rnd));
                cur = cur.next;
            }
            cur = head;
            return head;
            //for (int i = 1; i < size; i++)
            //{
            //    cur.next = MakeAPoint(GetValue(rnd));
            //    cur = cur.next;
            //}
            //return head;
        }
        public static Point MakeList(int size)
        {
            if (size == 0)
                return null;
            Console.WriteLine("Введите значение 1-го элемента: ");
            Point head = new Point(GetValue());
            Point cur = head;
            for (int i = 1; i < size; i++)
            {
                Console.WriteLine("Введите значение {0}-го элемента: ", i+1);
                cur.next = MakeAPoint(GetValue());
                cur = cur.next;
            }
            return head;
        }
        public void ShowList()
        {
            Console.WriteLine(ToString());
            if (next != null)
                next.ShowList();
        }
        public static void Sum(Point head, out int positive, out int negative)
        {
            if (head == null)
            {
                Console.WriteLine("Ваш список пуст.");
            }
            Point cur = head;
            positive = 0;
            negative = 0;
            while (cur != null)
            {
                if (cur.data > 0)
                    positive += cur.data;
                else
                    negative += cur.data;
                cur = cur.next;
            }
        }
    }
    class Program
    {
        public static int ScanInt()
        {
            bool ok;
            int buf;
            do
            {
                ok = Int32.TryParse(Console.ReadLine(), out buf);
                if (!ok)
                    Console.WriteLine("Ошибка ввода! Введите целое число");
            } while (!ok);
            return buf;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте! Введите количество элементов списка.");
            bool ok;
            int N;
            do
            {
                ok = Int32.TryParse(Console.ReadLine(), out N);
                if (!ok)
                    Console.WriteLine("Ошибка! Введите натуральное число.");
                if (N <= 0)
                {
                    Console.WriteLine("Ошибка! Введите натуральное число.");
                    ok = false;
                }
            } while (!ok);
            Console.WriteLine("Как вы хотите сформировать однонаправленный список?\n1. С помощью ДСЧ.\n2. Вручную");
            int command;
            int positive, negative;
            while (true)
            {
                do
                {
                    ok = Int32.TryParse(Console.ReadLine(), out command);
                    if (!ok)
                        Console.WriteLine("Ошибка ввода. Выберите способ формирования списка.");
                    if (command <= 0 || command >= 3)
                    {
                        Console.WriteLine("Ошибка ввода. Выберите способ формирования списка.");
                        ok = false;
                    }
                } while (!ok);
                switch (command)
                {
                    case 1:
                        Console.Clear();
                        Point RndList = Point.MakeRndList(N);
                        Point.Sum(RndList, out positive, out negative);
                        Console.WriteLine("Сумма положительных элементов списка: {0}\nСумма отрицательных элементов списка: {1}",
                            positive, negative);
                        break;
                    case 2:
                        Console.Clear();
                        Point OwnList = Point.MakeList(N);
                        Point.Sum(OwnList, out positive, out negative);
                        Console.WriteLine("Сумма положительных элементов списка: {0}\nСумма отрицательных элементов списка: {1}",
                            positive, negative);
                        break;
                }
                break;
            }
            Console.ReadLine();
        }
    }
}

