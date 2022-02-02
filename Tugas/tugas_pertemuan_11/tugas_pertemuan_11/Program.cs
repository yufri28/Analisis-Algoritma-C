using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tugas_pertemuan_11
{
    class Program
    {
        //Kelompok A
        //1. Yufridon Chrisma Luttu(1906080070)
        //2. Andre F. Temaluru (1906080065)
        //3. DESWITA LORI LAKA (1906080043) 
        //4. GERARDUS LASBAUN (1706080117)
        //5. GRACELA N. D. FANGGIDAE (1906080054)
        //6. RAINER TAEBENU (1706080100)
        static void Main(string[] args)
        {
            double[,] matriks = new double[1000, 1000];
            double[,] dataTerurut = new double[1000, 1000];
            var sw = new Stopwatch();
            var sw1 = new Stopwatch();
            Console.WriteLine("Proses  Mulai");
            dataTerurut = bubbleSort(GenerateRandomMatriks(matriks));
            sw.Start();
            var urutData = new Task(() => dataTerurut = bubbleSort(GenerateRandomMatriks(matriks)));
            urutData.Start();
            //var cetakMatriks = new Task(() => CetakMatriks(dataTerurut));
            //cetakMatriks.Start();
            var cetakArray = new Task(() => CetakArray(GetMedianBarisMatriks(dataTerurut)));
            cetakArray.Start();
            sw.Stop();
            Task.WaitAll(new Task[] { /*cetakMatriks,*/ cetakArray });
            var cetakTotalWaktu = new Task(() => { Console.WriteLine("total waktu : {0} ms", sw.Elapsed.TotalMilliseconds); });
            cetakTotalWaktu.Start();
            var cetakJudul = new Task(() => { Console.WriteLine("Proses menggunakan Task"); });
            cetakJudul.Start();
            var cetakSelesai = new Task(() => { Console.WriteLine("Proses  Selesai"); });
            cetakSelesai.Start(); 
            Console.ReadKey();
        }
        private static double[,] GenerateRandomMatriks(double[,] matriks)
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
        private static double[] GetMedianBarisMatriks(double[,] matriks)
        {
            int jumlahBaris = matriks.GetLength(0);
            int jumlahKolom = matriks.GetLength(1);
            double[] result = new double[jumlahBaris];
            int Me = (((jumlahBaris / 2) + ((jumlahBaris / 2) + 1)) / 2);
            int Me2 = Me - 1;
            for (int i = 0; i < jumlahBaris; i++)
            {
                double a = 0;
                for (int j = 0; j < jumlahKolom; j++)
                {
                    a = (matriks[i, Me] + matriks[i, Me2]) / 2;
                }
                result[i] = a;
            }
            return result;
        }
        private static double[,] bubbleSort(double[,] array)
        {
            int jumlahBaris = array.GetLength(0);
            int jumlahKolom = array.GetLength(1);
            double[] result = new double[jumlahBaris];

            for (int i = 0; i < jumlahBaris; i++)
            {
                for (int j = jumlahKolom - 1; j > 0; j--)
                {

                    for (int k = 0; k < j; k++)
                    {
                        if (array[i, k] > array[i, k + 1])
                        {
                            double temp = array[i, k];
                            array[i, k] = array[i, k + 1];
                            array[i, k + 1] = temp;
                        }
                    }
                }
            }
            return array;
        }
        private static void CetakMatriks(double[,] matriks)
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
            Console.WriteLine();
        }

        private static void CetakArray(double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(" {0} ", array[i]);
            }

        }
    }
}
