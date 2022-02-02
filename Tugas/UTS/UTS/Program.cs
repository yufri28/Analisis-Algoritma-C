using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTS
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matriks = { { 1, 3, 4 }, { 3, 2, 4 } };
            int[,] matriks1 = { { 5, 3, 3 }, { 3, 1, 4 } };
            Console.WriteLine(AdaElemenYangSama(matriks, matriks1));
        }
        public static int AdaElemenYangSama(int[,] matriksA, int[,] matriksB)
        {

            int jumlahBaris = matriksA.GetLength(0);
            int jumlahKolom = matriksA.GetLength(1);
            int hasil = 0;
            for (int i = 0; i < jumlahBaris; i++)
            {
                for (int j = 0; j < jumlahKolom; j++)
                {
                    if (matriksA[i, j] == matriksB[i, j])
                    {
                        hasil++;
                    }
                }  
            }
            return hasil;
        }
    }
}
