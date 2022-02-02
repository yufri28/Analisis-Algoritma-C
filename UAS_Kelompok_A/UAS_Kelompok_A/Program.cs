using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_Kelompok_A
{
    class Program
    {
       
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
        static void Main(string[] args)
        {
          
            Console.Write("Masukan Ukuran Data: ");
            int ukuranData = int.Parse(Console.ReadLine());
            Console.WriteLine();
            int[,] matriks = new int[ukuranData, ukuranData];
            int[,] matriks1 = new int[ukuranData, ukuranData];
            int[,] matriks2 = new int[ukuranData, ukuranData];
            int[,] result = new int[ukuranData, ukuranData];
            Stopwatch st = new Stopwatch();

            matriks1 = GenerateRandomMatriks(matriks);
            matriks2 = GenerateRandomMatriks(matriks);

            Console.WriteLine("Process Dimulai");
            st.Start();
            penjumlahanSequential(matriks1, matriks2, ukuranData);
            st.Stop();
            Console.WriteLine("Process Selesai");
            Console.WriteLine("Total Waktu Sebelum Dioptimasi : {0} ms", st.Elapsed.TotalMilliseconds);
            st.Reset();
            Console.WriteLine();

            Console.WriteLine("Process Dimulai");
            st.Start();
            penjumlahanParallel(matriks1, matriks2, ukuranData);
            st.Stop();
            Console.WriteLine("Process Selesai");
            Console.WriteLine("Total Waktu Sesudah Dioptimasi: {0} ms", st.Elapsed.TotalMilliseconds);
           

        }
        private static int [,] penjumlahanParallel(int[,]matriks1, int[,]matriks2, int ukuranData)
        {
            int[,] result = new int[ukuranData,ukuranData];
            Parallel.For(0, result.GetLength(0), i =>
            {
                Parallel.For(0, result.GetLength(0), j =>
                {
                    result[i, j] = matriks1[i, j] + matriks2[i, j];
                });
            });
            return result;
        }
        private static int[,] penjumlahanSequential(int [,] matriks1, int [,] matriks2, int ukuranData)
        {
            int[,] result = new int[ukuranData, ukuranData];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(0); j++)
                {
                    result[i, j] = matriks1[i, j] + matriks2[i, j];
                }
            }
            return result;
        }
    }
}
