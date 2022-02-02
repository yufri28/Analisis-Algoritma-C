using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pertemuan_12
{
    //Kelompok A
    //1. Yufridon Chrisma Luttu(1906080070)
    //2. Andre F. Temaluru (1906080065)
    //3. DESWITA LORI LAKA (1906080043) 
    //4. GERARDUS LASBAUN (1706080117)
    //5. GRACELA N. D. FANGGIDAE (1906080054)
    //6. RAINER TAEBENU (1706080100)
    class Program
    {
        static void CopyLine(int[,] destArr, int destIndex, int[,] sourceArr, int sourceIndex)
        {
            for (int i = 0; i < destArr.GetLength(1); ++i)
            {
                destArr[destIndex, i] = sourceArr[sourceIndex, i];
            }
        }

        //array merging
        static void Merge(int[,] num, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1, num.GetLength(1)];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (num[left, 0] < num[right, 0])
                {
                    CopyLine(tempArray, index, num, left);
                    left++;
                }
                else
                {
                    CopyLine(tempArray, index, num, right);
                    right++;
                }

                index++;
            }

            for (var j = left; j <= middleIndex; j++)
            {
                CopyLine(tempArray, index, num, j);
                index++;
            }

            for (var j = right; j <= highIndex; j++)
            {
                CopyLine(tempArray, index, num, j);
                index++;
            }

            for (var j = 0; j < tempArray.GetLength(0); j++)
            {
                CopyLine(num, lowIndex + j, tempArray, j);
            }
        }

        //merge sorting
        static void MergeSort(int[,] num, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(num, lowIndex, middleIndex);
                MergeSort(num, middleIndex + 1, highIndex);
                Merge(num, lowIndex, middleIndex, highIndex);
            }
        }

        public static void MergeSort(int[,] num)
        {
            MergeSort(num, 0, num.GetLength(0) - 1);
        }

        static void WriteArray(string description, int[,] arr)
        {
            Console.WriteLine(description);
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            var sw = new Stopwatch();
            int[,] matriks = new int[1000, 1000];
            int[,] dataTerurut = new int[1000, 1000];
            Console.WriteLine("Program Mulai");
            sw.Start();
            MergeSort(GenerateRandomMatriks(matriks));
            dataTerurut = GenerateRandomMatriks(matriks);
            GetMedianBarisMatriks(dataTerurut);
          
            CetakArray(GetMedianBarisMatriks(dataTerurut));
            sw.Stop();
            Console.WriteLine("Program Selesai");
            Console.WriteLine("total waktu : {0} ms", sw.Elapsed.TotalMilliseconds);
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
        private static int[] GetMedianBarisMatriks(int[,] matriks)
        {
            int jumlahBaris = matriks.GetLength(0);
            int jumlahKolom = matriks.GetLength(1);
            int[] result = new int[jumlahBaris];
            int Me = (((jumlahBaris / 2) + ((jumlahBaris / 2) + 1)) / 2);
            int Me2 = Me - 1;
            for (int i = 0; i < jumlahBaris; i++)
            {
                int a = 0;
                for (int j = 0; j < jumlahKolom; j++)
                {
                    a = (matriks[i, Me] + matriks[i, Me2]) / 2;
                }
                result[i] = a;
            }
            return result;
        }
        private static int[,] bubbleSort(int[,] array)
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
                            int temp = array[i, k];
                            array[i, k] = array[i, k + 1];
                            array[i, k + 1] = temp;
                        }
                    }
                }
            }
            return array;
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
            Console.WriteLine();
        }

        private static void CetakArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(" {0} ", array[i]);
            }

        }
    }
}
