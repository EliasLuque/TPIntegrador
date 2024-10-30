
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.IO.Packaging;
using System.Numerics;
using tp1;

namespace tpfinal
{

    public class Estrategia
    {

        public String Consulta1(List<Proceso> datos)
        {
            string resutl = "Las hojas de las Heaps son:\n\n";

            MinHeap minHeap = new MinHeap(datos);
            MaxHeap maxHeap = new MaxHeap(datos);

            Proceso[] hojasMinHeap = minHeap.GetHojas();
            Proceso[] hojasMaxHeap = maxHeap.GetHojas();

            resutl += "Hojas MinHeap:";
            foreach(Proceso dato in hojasMinHeap) {
                resutl += "\n";
                resutl += dato.ToString();
            }

            resutl += "\n\nHojas MaxHeap:";
            foreach(Proceso dato in hojasMaxHeap) {
                resutl += "\n";
                resutl += dato.ToString();
            }

            return resutl;
        }

        public String Consulta2(List<Proceso> datos)
        {
            string resutl = "Las alturas de las Heaps son:\n\n";
            MinHeap minHeap = new MinHeap(datos);
            MaxHeap maxHeap = new MaxHeap(datos);

            resutl += "MinHeap:" + minHeap.Height();
            resutl += "\n";
            resutl += "MaxHeap: " + maxHeap.Height();
            return resutl;
        }



        public String Consulta3(List<Proceso> datos)
        {
            /* Retorna un texto que contiene los datos de las Heaps utilizadas
            en los métodos anteriores, explicitando en el texto resultado los
            niveles en los que se encuentran ubicados cada uno de los datos*/
            MinHeap minHeap = new MinHeap(datos);
            MaxHeap maxHeap = new MaxHeap(datos);
            
            int altura = minHeap.Height();
            Proceso[] nivel;
            
            string resutl = "MinHeap:";
            for(int i = 1; i <= altura; i++) {
                resutl += "\nNivel " + i + "\n";
                
                if(i < minHeap.Height())
                    nivel = minHeap.GetNivel(i);
                else
                    nivel = minHeap.GetHojas();
                
                foreach(Proceso dato in nivel) {
                    resutl += dato.ToString() + "\n";
                }
            }
            resutl += "\nMaxHeap:";
            for(int i = 1; i <= altura; i++) {
                resutl += "\nNivel " + i + "\n";
                
                if(i < maxHeap.Height())
                    nivel = maxHeap.GetNivel(i);
                else
                    nivel = maxHeap.GetHojas();

                foreach(Proceso dato in nivel) {
                    resutl += dato.ToString() + "\n";
                }
            }
            return resutl;
        }


        public void ShortesJobFirst(List<Proceso> datos, List<Proceso> collected)
        {
            MinHeap heap = new MinHeap(datos.Count);

            foreach(Proceso dato in datos) {
                heap.Insert(dato);
            }

            while(heap.Length() != 0) {
                collected.Add(heap.DeleteMin());
            }
        }


        public void PreemptivePriority(List<Proceso> datos, List<Proceso> collected)
        {
            MaxHeap heap = new MaxHeap(datos.Count);

            foreach(Proceso dato in datos) {
                heap.Insert(dato);
            }

            while(heap.Length() != 0) {
                collected.Add(heap.DeleteMax());
            }
        }
        
    }
}