using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tugas_pertemuan_5_Kel_A
{
    class Program
    {
        static void Main(string[] args)
        {
            string lanjut = "Ya";
            while (lanjut == "Ya")
            {
                Console.WriteLine(" =========== Kelompok A =============");
                Console.WriteLine();
                /* 
                1. Yufridon Chrisma Luttu (1906080070)
                2. Andre F. Temaluru (1906080065)
                3. DESWITA LORI LAKA (1906080043)
                4. GERARDUS LASBAUN (1706080117)
                5. GRACELA N. D. FANGGIDAE (1906080054)
                6. RAINER TAEBENU (1706080100)
                */
                Console.WriteLine();
                Console.WriteLine("1. Algoritma Fibonaci");
                Console.WriteLine("2. Algoritma Pangkat");
                Console.WriteLine("====================================");
                Console.WriteLine("Masukan pilihan dari antara dua algoritma diatas : ");
                Console.Write("ketik 1 untuk Algoritma Fibonaci dan 2 untuk Algoritma Pangkat : ");
                int pilihan = int.Parse(Console.ReadLine());
            
                if (pilihan == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("1. Algoritma Fibonaci");
                    Console.WriteLine("=====================");
                    Console.Write("Masukan ukuran : ");
                    int ukuran = int.Parse(Console.ReadLine());
                    Console.WriteLine("====================");
                    Console.WriteLine("======= Rekursif ======");
                    Console.Write("Hasil dengan Rekursif : {0} \n", fibonaciRekursif(ukuran));
                    Console.WriteLine("======= Iterasi ======");
                    Console.Write("Hasil dengan Iterasi : {0} \n", fibonaciIterasi(ukuran));
                    Console.WriteLine("======= Tail Call ======");
                    Console.Write("Hasil dengan Tail Call : {0} \n", fibonaci_tc(ukuran));
                }
                else if (pilihan == 2)
                {
                    Console.WriteLine();
                    Console.WriteLine("2. Algoritma Pangkat");
                    Console.WriteLine("=====================");
                    Console.Write("Masukan angka: ");
                    int a = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write("Masukan Pangkat: ");
                    int p = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine("====================");
                    Console.WriteLine("======= Rekursif ======");
                    Console.Write("Hasil dengan Rekursif : {0}\n", pangkatRekursif(a, p));
                    Console.WriteLine("======= Iterasi ======");
                    Console.Write("Hasil dengan Iterasi : {0}\n", pangkatIterasi(a, p));
                    Console.WriteLine("======= Tail Call ======");
                    Console.Write("Hasil dengan Tail Call : {0}\n", pangkat_tc(a, p));
                }
                else
                {
                    Console.WriteLine("Error");
                }
                Console.WriteLine("Ketik Ya, untuk lanjut dan Ketik Tidak, untuk berhenti");
                Console.WriteLine();
                Console.Write("Lanjut ? : ");
                lanjut = Console.ReadLine();
            }
        }
        // rekursif
        //fibonaci
        public static int fibonaciRekursif(int a)
        {
            if (a <= 2)
            {
                return 1;
            }
            else
            {
                return fibonaciRekursif(a - 1) + fibonaciRekursif(a - 2);
            }
        }
        //pangkat
        public static int pangkatRekursif(int a, int p)
        {
            if (p > 0)
            {
                return a * pangkatRekursif(a, p - 1);
            }
            else
            {
                return 1;
            }
        }
        //rekursif dan iterasi
        //fibonaci
        public static int fibonaciIterasi(int a)
        {
            int res = 0;
            if (a <= 2)
            {
                return 1;
            }
            else
            {

                for (int j = 3; j <= a; j++)
                {
                    res = fibonaciIterasi(j - 1) + fibonaciIterasi(j - 2);
                }
                return res;
            }
        }
        //pangkat
        public static int pangkatIterasi(int a, int p)
        {
            int res = 0;
            if (p != 0)
            {
                for (int j = 1; j <= p; j++)
                {
                    res = a * pangkatIterasi(a, j - 1);
                }
                return res;
            }
            else
            {
                return 1;
            }
        }
        //tail call
        //fibonaci
        public static int fibonaci_tc(int a)
        {

            if (a <= 2)
            {
                return 1;
            }
            else
            {
                return fungsiLain_Fib(a);
            }
        }

        public static int fungsiLain_Fib(int a)
        {
            int res = 0;
            for (int j = 3; j <= a; j++)
            {
                res = fibonaci_tc(a - 1) + fibonaci_tc(a - 2);
            }
            return res;
        }
        //pangkat
        public static int pangkat_tc(int a, int p)
        {
            if (p > 0)
            {
                return fungsilain_pangkat(a, p);
            }
            else
            {
                return 1;
            }
        }
        public static int fungsilain_pangkat(int a, int p)
        {
            int res = 0;
            for (int j = 1; j <= p; j++)
            {
                res = a * pangkat_tc(a, j - 1);
            }
            return res;
        }
    }
}
