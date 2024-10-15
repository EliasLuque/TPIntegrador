namespace tpfinal {
    public class MaxHeap {
        private Proceso[] arreglo;
        private int tam;

        public MaxHeap(int tam) {
            arreglo = new Proceso[tam + 1];
            this.tam = 0;
        }

        internal void swap(int idx1, int idx2) {
            Proceso aux = this.arreglo[idx1];
            this.arreglo[idx1] = this.arreglo[idx2];
            this.arreglo[idx2] = aux;
        }

        internal void upperFilter(int idx) {
            int idx2 = idx / 2;
            if (idx2 != 0 && arreglo[idx].prioridad > arreglo[idx2].prioridad) {
                swap(idx, idx2);
                upperFilter(idx2);
            }
        }

        internal void lowerFilter(int idx) {
            int l_idx = idx * 2;
            int r_idx = l_idx + 1;

            // No tiene hijos
            if(l_idx > tam)
                return;

            // Tiene hijo Izquierdo pero no derecho
            if(l_idx == tam) {
                if(arreglo[l_idx].prioridad > arreglo[idx].prioridad)
                    swap(idx, l_idx);
                return;
            }
            
            // Existen ambos hijo Izquierdo y Derecho
            if(arreglo[idx].prioridad < arreglo[l_idx].prioridad || arreglo[idx].prioridad < arreglo[r_idx].prioridad) {
                if(arreglo[l_idx].prioridad > arreglo[r_idx].prioridad){
                    swap(idx, l_idx);
                    lowerFilter(l_idx);
                } else {
                    swap(idx, r_idx);
                    lowerFilter(r_idx);
                }
            }
        }

        public void Insert(Proceso dato) {
            tam++;
            arreglo[tam] = dato;
            upperFilter(tam);
        }

        public Proceso DeleteMax() {
            Proceso aux = arreglo[1];
            arreglo[1] = arreglo[tam];
            tam--;
            lowerFilter(1);
            
            return aux;
        }

        public int Lenght() {
            return tam;
        }
        
        public int Height() {
            int h = 0;
            for(int i = tam; i != 0; i /= 2) {
                h++;
            }
            return h;
        }

        public Proceso[] GetHojas() {
            int h = (int)System.Math.Pow(2,Height()-1);
            return arreglo[h..(tam + 1)];
        }
    }
}