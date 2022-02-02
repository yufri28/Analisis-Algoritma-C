using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MencariSelisih
{
    class Program
    {
        public static void Main(string[] args)
        {
            Timing sortTime = new Timing();
            Random r = new Random();
            int[] array = new int[100000];
            for (int i = 0; i < 100000; i++)
            {
                array[i] = r.Next(1, 20);
            }
            sortTime.startTime();
            Console.WriteLine(" {0} ", YufridonLuttuTuning(array));
            sortTime.stopTime();
            Console.WriteLine(" Waktu dibutuhkan untuk YufridonLuttuTuning: " + sortTime.getResult().TotalMilliseconds);
        }
        public static int YufridonLuttuTuning(int[] array)
        {
            return array.Max() - array.Min();
        }
        public static int YufridonLuttu(int[] array)
        {
            int a = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i; j < array.Length; j++)
                {
                    if (Math.Abs(array[i] - array[j]) > a)
                    {
                        a = Math.Abs(array[i] - array[j]);
                    }
                }
            }
            return a;
        }
       

    }
    class Timing
    {
        public DateTime start;
        public DateTime stop;
        public void startTime()
        {
            DateTime start = DateTime.Now;
            this.start = start;
        }
        public void stopTime()
        {
            DateTime stop = DateTime.Now;
            this.stop = stop;
        }
        public TimeSpan getResult()
        {
            return (this.stop - this.start);
        }
    }
}
