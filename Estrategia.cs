
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

            // Se crean ambas Heaps
            MinHeap minHeap = new MinHeap(datos.Count);
            MaxHeap maxHeap = new MaxHeap(datos.Count);

            // Se cargan los datos en las Heaps
            foreach(Proceso dato in datos) {
                minHeap.Insert(dato);
                maxHeap.Insert(dato);
            }

            // Se obtienen las hojas de las Heaps
            Proceso[] hojasMinHeap = minHeap.GetHojas();
            Proceso[] hojasMaxHeap = maxHeap.GetHojas();

            // Se arma el resultado
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

            // Se crean ambas Heaps
            MinHeap minHeap = new MinHeap(datos.Count);
            MaxHeap maxHeap = new MaxHeap(datos.Count);

            // Se cargan los datos en las Heaps
            foreach(Proceso dato in datos) {
                minHeap.Insert(dato);
                maxHeap.Insert(dato);
            }

            resutl += "MinHeap:" + minHeap.Height();
            resutl += "\n";
            resutl += "MaxHeap: " + maxHeap.Height();
            return resutl;
        }



        public String Consulta3(List<Proceso> datos)
        {
            // Se crean ambas Heaps
            MinHeap minHeap = new MinHeap(datos.Count);
            MaxHeap maxHeap = new MaxHeap(datos.Count);

            // Se cargan los datos en las Heaps
            foreach(Proceso dato in datos) {
                minHeap.Insert(dato);
                maxHeap.Insert(dato);
            }

            int altura = minHeap.Height();
            Proceso[] nivel; // almacena cada nivel
            
            string resutl = "MinHeap:";
            for(int i = 1; i <= altura; i++) {
                resutl += "\nNivel " + i + "\n";
                
                // Se comprueba que no sea el ultimo nivel (Hojas)
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
                
                // Se comprueba que no sea el ultimo nivel (Hojas)
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
            // Se construye una MinHeap utilizando la lista de datos
            MinHeap heap = new MinHeap(datos);

            // Se vacía la MinHeap y se almacenan los datos en la variable collected
            while(heap.Length() != 0) {
                collected.Add(heap.DeleteMin());
            }
        }


        public void PreemptivePriority(List<Proceso> datos, List<Proceso> collected)
        {
            // Se contruye una MaxHeap utilizando la lista de datos
            MaxHeap heap = new MaxHeap(datos);

            // Se vacía la MaxHeap y se almacenan los datos en la variable collected
            while(heap.Length() != 0) {
                collected.Add(heap.DeleteMax());
            }
        }
        
    }
}