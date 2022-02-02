using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tugas_pertemuan_6_kel_A
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
            * KELOMPOK A
            * 1. Yufridon Chrisma Luttu (1906080070)
            * 2. Andre F. Temaluru (1906080065)
            * 3. DESWITA LORI LAKA (1906080043)
            * 4. GERARDUS LASBAUN (1706080117)
            * 5. GRACELA N. D. FANGGIDAE (1906080054)
            * 6. RAINER TAEBENU (1706080100)
            */

            Timing sortTime = new Timing();
            int[] data = new int[100000];

            for (int i = 0; i < 100000; i++)
            {
                data[i] = i+i;
            }

            ////Linear Search
            //rekursif
            //sortTime.startTime();
            //linSearchRekursif(data, 3, 0);
            //sortTime.stopTime();
            //Console.WriteLine("Waktu untuk linear search rekursif = {0} ", sortTime.getResult().TotalMilliseconds);

            //iteratif
            //sortTime.startTime();
            //linSearchIteratif(data, 3, 0);
            //sortTime.stopTime();
            //Console.WriteLine("Waktu untuk linear search iteratif = {0} ", sortTime.getResult().TotalMilliseconds);


            //Binary Search
            //rekursif
            //sortTime.startTime();
            //binSearchRekursif(data, 3, 0, data.Length - 1);
            //sortTime.stopTime();
            //Console.WriteLine("Waktu untuk binary search rekursif = {0} ", sortTime.getResult().TotalMilliseconds);

            //iteratif
            //sortTime.startTime();
            //binSearchIteratif(data, 3);
            //sortTime.stopTime();
            //Console.WriteLine("Waktu untuk binary search iteratif = {0} ", sortTime.getResult().TotalMilliseconds);

            //sortTime.startTime();
            //binSearchRekursif(data, 100, 0, data.Length - 1);
            //sortTime.stopTime();
            //Console.WriteLine("Ditemukan pada index ke : {0} ", binSearchIteratif(data, 350));
            //Console.WriteLine("Ditemukan pada index ke : {0} ",binSearchRekursif(data, 100, 0, data.Length - 1));
        }
        //Binary Search dengan Iteratif
        public static object binSearchIteratif(int []data, int dicari)
        {
            int min = 0;
            int max = data.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (dicari == data[mid])
                {
                    return ++mid;
                }
                else if (dicari < data[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return "Tidak ditemukan";
        }
        //binary search dengan metode rekursif
        public static object binSearchRekursif(int []data, int dicari, int min, int max)
        {
            if (min > max)
            {
                return "Tidak ditemukan";
            }
            else
            {
                int mid = (min + max) / 2;
                if (dicari == data[mid])
                {
                    return ++mid;
                }
                else if (dicari < data[mid])
                {
                    return binSearchRekursif(data, dicari, min, mid - 1);
                }
                else
                {
                    return binSearchRekursif(data, dicari, mid + 1, max);
                }
            }
        }
        //metode linear search dengan iteratif
        public static object linSearchIteratif(int []data, int dicari, int i)
        {
            
            while (i < data.Length)
            {
                if (dicari == data[i])
                {
                    return i+1;
                }

                i++;
            }
            return "Tidak ditemukan";
        }
        //metode linear search dengan rekursif
        public static object linSearchRekursif(int[] data, int dicari, int i)
        {
            if(i > data.Length || dicari != data[i])
            {
                return "Tidak ditemukan";
            }
            else
            {
                if (dicari == data[i])
                {
                    return i + 1;
                }
                else
                {
                    return linSearchRekursif(data, dicari, i + 1);
                }
            }
        }
    }
    //untuk mengukur kecepatan
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
