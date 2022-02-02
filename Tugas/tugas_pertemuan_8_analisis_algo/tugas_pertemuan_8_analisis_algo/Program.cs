using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tugas_pertemuan_8_analisis_algo
{
    class Program
    {

        //NIM  : 1906080070
        //Nama : Yufridon Chrisma Luttu
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            int[,] matriks = new int[1000, 1000];
            Console.WriteLine("Proses Mulai");
            GetRerataBarisMatriks(GenerateRandomMatriks(matriks));
            sw.Start();
            GenerateRandomMatriks(matriks);
            CetakMatriks(GenerateRandomMatriks(matriks));
            Console.WriteLine("\n");
            CetakArray(GetRerataBarisMatriks(matriks));
            sw.Stop();
            Console.WriteLine("total waktu : {0} ms",sw.Elapsed.TotalMilliseconds);
            Console.WriteLine("Proses Selesai");
            Console.ReadKey();
        }
        private static int[,] GenerateRandomMatriks(int[,] matriks)
        {
            Random random = new Random();
            for (int i = 0; i < matriks.GetLength(0); i++)
            {
                for (int j = 0; j < matriks.GetLength(0); j++)
                {
                    matriks[i, j] = (byte)random.Next(0, 100);
                }
            }
            return matriks;
        }
        private static double[] GetRerataBarisMatriks(int[,] matriks)
        {
            int jumlahBaris = matriks.GetLength(0);
            int jumlahKolom = matriks.GetLength(1);
            double[] result = new double[jumlahBaris];

            for (int i = 0; i < jumlahBaris; i++)
            {
                double a = 0;
                for (int j = 0; j < jumlahKolom; j++)
                {
                    a += matriks[i, j];
                }
                result[i] = a / jumlahKolom;
            }
            return result;
        }
        private static void CetakMatriks(int[,] matriks)
        {
         
            for (int i = 0; i < matriks.GetLength(0); i++)
            {
                string strKolom = "";
                for (int j = 0; j < matriks.GetLength(1); j++)
                {
                    string nilaiMatriks = matriks[i, j].ToString();
                    nilaiMatriks = nilaiMatriks.PadLeft(3, ' ');
                    strKolom = strKolom + " " + nilaiMatriks;
                }
                Console.WriteLine(strKolom);
            }
        }

        private static void CetakArray(double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(Math.Round(array[i], 2));
            }
        }
    }
}
