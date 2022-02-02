using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tugas_pertemuan_13
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] listVertex = { "Jln Yos Sudarso", "Jln cempaka", "Jln Amabi", "Jln Sultan Agung", "Jln Merdeka", "Jln Ahmat Yani", "Jln Oeleta Raya", "Jln Kecapi"};

            double[,] adjacMatrix = { 
                { 0, 5, 3.8, 7, 0, 0, 0, 0}, 
                { 5, 0, 0, 0, 0, 6, 0, 9.4 }, 
                { 3.8, 0, 0, 0, 4, 0, 0, 0}, 
                { 7, 0, 0, 0, 2, 0, 5, 0},
                { 0, 0, 0, 2, 0, 0, 14, 17},
                { 0, 6, 4, 0, 3, 7, 9, 0 },
                { 0, 0, 0, 5, 14, 3, 0, 0 },
                { 0, 9.4, 0, 7, 0, 0, 24, 0}
            };

            bool[] visited = new bool[listVertex.Length];

            int IndexVertexAwal = 6;
            int IndexVertexAkhir = 0;

            double totalBobot = 0;
            int vertexAsal = IndexVertexAwal;
            visited[vertexAsal] = true;
            Console.WriteLine("Tujuan: Jln Oeleta Raya ke Jln Yos Sudarso");
            Console.WriteLine();
            Console.Write("Jalur : " + listVertex[vertexAsal]);
            while (vertexAsal != IndexVertexAkhir)
            {
                int vertexTujuan = -1;
                List<int> kandidatVertexTujuan = new List<int>();
                double MIN = Double.MaxValue;
                for (int i = 0; i < adjacMatrix.GetLength(1); i++)
                {
                    double bobot = adjacMatrix[vertexAsal, i];
                    bool isVisited = visited[i];
                    if(bobot > 0 && !isVisited && bobot < MIN)
                    {
                        MIN = bobot;
                        vertexTujuan = i;
                    }
                }
                if(vertexTujuan != -1)
                {
                    visited[vertexTujuan] = true;
                    Console.Write(" ==> " + listVertex[vertexTujuan]);
                    double bobot = adjacMatrix[vertexAsal, vertexTujuan];
                    totalBobot += bobot;
                    vertexAsal = vertexTujuan;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Total Jarak: {0}", totalBobot);
        }
    }
}
