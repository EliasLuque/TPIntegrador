namespace tpfinal {
    public class MinHeap {
        private Proceso[] arreglo;
        private int tam;

        public MinHeap(int tam) {
            arreglo = new Proceso[tam + 1];
            this.tam = 0;
        }

        public MinHeap(List<Proceso> datos) {
            arreglo = new Proceso[datos.Count + 1];
            this.tam = 0;

            foreach(Proceso dato in datos) {
                Insert(dato);
            }
        }

        internal void swap(int idx1, int idx2) {
            Proceso aux = this.arreglo[idx1];
            this.arreglo[idx1] = this.arreglo[idx2];
            this.arreglo[idx2] = aux;
        }

        internal void upperFilter(int idx) {
            int idx2 = idx / 2;
            if (idx2 != 0 && arreglo[idx].tiempo < arreglo[idx2].tiempo) {
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
                if(arreglo[l_idx].tiempo < arreglo[idx].tiempo)
                    swap(idx, l_idx);
                return;
            }

            // Existen ambos hijo Izquierdo y Derecho
            if(arreglo[idx].tiempo > arreglo[l_idx].tiempo || arreglo[idx].tiempo > arreglo[r_idx].tiempo) {
                if(arreglo[l_idx].tiempo < arreglo[r_idx].tiempo){
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

        public Proceso DeleteMin() {
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

        public Proceso[] GetNivel(int nivel) {
            return arreglo[nivel..(int)System.Math.Pow(2,nivel)];
        }
    }
}