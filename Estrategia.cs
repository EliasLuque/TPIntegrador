
using System;
using System.Collections.Generic;
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

            MinHeap minHeap = new MinHeap(datos.Count);
            MaxHeap maxHeap = new MaxHeap(datos.Count);
            foreach(Proceso dato in datos) {
                minHeap.Insert(dato);
                maxHeap.Insert(dato);
            }

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
            string resutl = "Implementar";

            return resutl;
        }



        public String Consulta3(List<Proceso> datos)
        {
            string resutl = "Implementar";

            return resutl;
        }


        public void ShortesJobFirst(List<Proceso> datos, List<Proceso> collected)
        {
            MinHeap heap = new MinHeap(datos.Count);

            foreach(Proceso dato in datos) {
                heap.Insert(dato);
            }

            while(heap.Lenght() != 0) {
                collected.Add(heap.DeleteMin());
            }
        }


        public void PreemptivePriority(List<Proceso> datos, List<Proceso> collected)
        {
            MaxHeap heap = new MaxHeap(datos.Count);

            foreach(Proceso dato in datos) {
                heap.Insert(dato);
            }

            while(heap.Lenght() != 0) {
                collected.Add(heap.DeleteMax());
            }
        }
        
    }
}