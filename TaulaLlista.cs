using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace EstructuresDeDades
{
    internal class TaulaLlista<T> : ICollection<T>, IList<T>
    {
        public const int DEFAULT_SIZE = 10;
        private T[] dades;
        private int nElem;
        /// <summary>
        /// Propietat que retorna la quantitat de elements que te lobjecte. 
        /// </summary>
        public int Count => nElem;
        /// <summary>
        /// Propietat que retorna false per donar a entendre que en aquesta clase no es IsReadOnly. 
        /// </summary>
        public bool IsReadOnly => false;
        /// <summary>
        /// Aquesta propietat permet obtenir i establir el valor que es troba a la posició index especificada.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index > nElem - 1) { throw new ArgumentOutOfRangeException("EL INDEX ESTA FORA DE RANG"); }
                return dades[index];
            }
            set
            {
                if (index < 0 || index > nElem - 1) { throw new ArgumentOutOfRangeException("EL INDEX ESTA FORA DE RANG"); }
                if (this.IsReadOnly) throw new NotSupportedException("NO ES PODEN AFAGIR VALORS PERQUE NOMES ES DE LECTURA");
                dades[index] = value;
            }
        }
        /// <summary>
        /// Constructor TaulaLlista amb la capacidad marcada.
        /// </summary>
        /// <param name="capacitatInicial"></param>
        public TaulaLlista(int capacitatInicial)
        {
            dades = new T[capacitatInicial];
            nElem = 0;
        }
        public TaulaLlista() : this(DEFAULT_SIZE) { }
        /// <summary>
        /// Constructor TaulaLlista desde una TaulaLlista per doplicar la capacidad.
        /// </summary>
        /// <param name="TaulaLlista2"></param>
        public TaulaLlista(TaulaLlista<T> TaulaLlista2)
        {
            this.dades = new T[TaulaLlista2.dades.Length];
            this.nElem = TaulaLlista2.nElem;
            for (int i = 0; i < nElem; i++)
            {
                this.dades[i] = TaulaLlista2.dades[i];
            }
        }
        /// <summary>
        /// Constructor TaulaLlista des de un array de base.
        /// </summary>
        /// <param name="array"></param>
        public TaulaLlista(T[] array)
        {
            dades = new T[array.Length * 2];
            nElem = 0;
            for (int i = 0; i < array.Length; i++)
            {
                dades[i] = array[i];
                nElem++;
            }
        }
        /// <summary>
        /// metoda que afageix elements a la llista.
        /// </summary>
        /// <param name="dada"></param>
        public void Afegir(T dada)
        {
            dades[nElem] = dada;
            nElem++;
        }
        /// <summary>
        /// Metoda que retorna un 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new ElMeuEnumerator(this.dades, this.nElem);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// afegeix un nou element de tipus genèric T a la següent posició lliure de
        /// l'array (nElem). Si l'array està ple, primer duplicara la seva capacitat utilitzant un
        /// mètode privat
        /// </summary>
        /// <param name="item">valor que es vol afagir</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        public void Add(T item)
        {
            if (this.IsReadOnly) throw new NotSupportedException("NO ES PODEN AFAGIR VALORS PERQUE NOMES ES DE LECTURA");
            if (nElem == dades.Length)
            {
                DoubleCapacity();
            }
            dades[nElem] = item;
            nElem++;
        }
        /// <summary>
        /// Metoda privat que duplica la capacidad de l'array
        /// al doble de capacidad mantenint el contingut.
        /// </summary>
        private void DoubleCapacity()
        {
            T[] nou = new T[this.dades.Length * 2];
            for (int i = 0; i < nElem; i++)
            {
                nou[i] = dades[i];
            }
            dades = nou;
        }
        /// <summary>
        /// Borra el contingut de tot el array.
        /// </summary>
        /// <exception cref="NotSupportedException"></exception>
        public void Clear()
        {
            if (this.IsReadOnly) throw new NotSupportedException("NO ES POT BORRAR LA TAULA PERQUE NOMES ES DE LECTURA");
            for (int i = 0; i < nElem; i++)
            {
                dades[i] = default(T);
            }
            nElem = 0;
        }
        /// <summary>
        /// Retorna true si troba el element
        /// </summary>
        /// <param name="item">element a buscar</param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }
        /// <summary>
        /// Copia tots els elements del array T[] this a l’array T[] array passat per
        /// paràmetre, començant per la posició arrayIndex.
        /// </summary>
        /// <param name="array">T[] array passat per paràmetre</param>
        /// <param name="arrayIndex">La posició per la cual comença</param>
        /// <exception cref="ArgumentNullException">Exception surt cuanto el array es null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Exception surt cuanto el arrayIndex esta fora de rang</exception>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException("AQUEST ARRAY NO A ESTAT INIZIALITZAT");
            if (array.Length - arrayIndex < this.nElem) throw new ArgumentOutOfRangeException("NO ES POT MODIFICAR PERQUE ES SURT DEL ARRAY");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException("EL ARRAYINDEX INTRODUIT ES SURT DEL ESPAI DEL ARRAY");
            for (int i = 0; i < nElem; i++)
            {
                array[arrayIndex + i] = dades[i];
            }
        }
        /// <summary>
        /// Retorna true si aconseguix trobar el element igual i borrarlo si no retorno false
        /// </summary>
        /// <param name="item">element per borrar</param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        public bool Remove(T item)
        {
            if (this.IsReadOnly) throw new NotSupportedException("NO ES POT BORRAR EL CONTINGUT DE LA TAULA PERQUE NOMES ES DE LECTURA");
            int i = IndexOf(item);
            bool trobat = i != -1;
            if (trobat)
            {
                for (int j = i; j < nElem - 1; j++)
                {
                    dades[j] = dades[j + 1];
                }
                dades[nElem - 1] = default(T);
                nElem--;
            }
            return trobat;
        }
        /// <summary>
        /// Metoda public que fa de Equals. 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool igual;
            if (ReferenceEquals(null, obj)) igual = false;
            else if (ReferenceEquals(this, obj)) igual = true;
            else if (obj.GetType() != this.GetType()) igual = false;
            else igual = this.Equals((TaulaLlista<T>)obj);
            return igual;
        }
        private bool Equals(TaulaLlista<T> other)
        {
            int i = 0;
            bool igual = false;
            bool fi = false;
            if (dades.Length == other.dades.Length && nElem == other.nElem)
            {
                while (i < nElem && !fi)
                {
                    if (!Equals(this.dades[i], other.dades[i]))
                    {
                        fi = true;
                    }
                    else i++;
                }
                if (i == nElem) igual = true;
            }
            return igual;
        }
        /// <summary>
        /// Retorna la primera posició on es troba l'element passat com a paràmetre (item). Si no es
        /// troba, retorna -1
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(T item)
        {
            bool trobat = false;
            int i = 0;
            while (i < nElem && !trobat)
            {
                if (this.dades[i].Equals(item))
                {
                    trobat = true;
                }
                else i++;
            }
            if (!trobat) { i = -1; }
            return i;
        }
        /// <summary>
        /// Insereix l'element item a la posició index especificada. Per fer-ho, el mètode desplaça els
        /// elements existents una posició cap a sota per deixar espai per el nou element. 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        /// <exception cref="ArgumentOutOfRangeException">Exception surt cuanto el index esta fora de rang</exception>
        /// <exception cref="NotSupportedException">Exception surt cuanto es IsReadOnly</exception>
        public void Insert(int index, T item)
        {
            if (index < 0 || index > nElem - 1) { throw new ArgumentOutOfRangeException("EL INDEX ESTA FORA DE RANG"); }
            if (IsReadOnly) { throw new NotSupportedException("LA LLISTA NOMES ES DE LECTURA"); }
            if (nElem == dades.Length) { DoubleCapacity(); }
            for (int i = nElem; i > index; i--)
            {
                dades[i] = dades[i - 1];
            }
            dades[index] = item;
            nElem++;
        }
        /// <summary>
        /// Elimina l'element situat a la posició index.
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="ArgumentOutOfRangeException">Exception surt cuanto el index esta fora de rang</exception>
        /// <exception cref="NotSupportedException">Exception surt cuanto es IsReadOnly</exception>
        public void RemoveAt(int index)
        {
            if (index < 0 || index > nElem - 1) { throw new ArgumentOutOfRangeException("EL INDEX ESTA FORA DE RANG"); }
            if (IsReadOnly) { throw new NotSupportedException("LA LLISTA NOMES ES DE LECTURA"); }
            for (int i = index; i < nElem - 1; i++)
            {
                dades[i] = dades[i + 1];
            }
            nElem--;
            dades[nElem] = default(T);
        }
        /// <summary>
        /// El metoda ToString amb un cursor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            int posicio = 1;
            StringBuilder sb = new StringBuilder("[ ");
            IEnumerator<T> cursor = ((IEnumerable<T>)this).GetEnumerator();
            cursor.Reset();
            while (cursor.MoveNext())
            {
                if (posicio != nElem)
                {
                    sb.AppendLine($"{cursor.Current},");
                    posicio++;
                }
                else
                {
                    sb.AppendLine($"{cursor.Current} ] ");
                }
            }
            return sb.ToString();
        }

        /// El meu IEnumerator:


        public class ElMeuEnumerator : IEnumerator<T>
        {
            private int limit;
            private int posicio;
            private T[] dades;
            /// <summary>
            /// Constructor principal.
            /// </summary>
            /// <param name="dades"></param>
            /// <param name="nElement"></param>
            public ElMeuEnumerator(T[] dades, int nElement)
            {
                this.dades = dades;
                this.posicio = -1;
                this.limit = nElement;
            }
            /// <summary>
            /// Propietat Reset que retorna a la posicio -1 per tal que quan
            /// es faci el primer MoveNext ens situem en el primer.
            /// </summary>
            public void Reset()
            {
                this.posicio = -1;
            }
            /// <summary>
            /// Propietat que et dona el valor per la posicio. 
            /// </summary>
            public T Current
            {
                get
                {
                    if (posicio == -1 || posicio >= limit) throw new Exception("OUT OF RANGE");
                    return dades[posicio];
                }
            }
            /// <summary>
            /// 
            /// </summary>
            object IEnumerator.Current => throw new NotImplementedException();
            /// <summary>
            /// Si hi ha un següent element a recòrrer, es posiciona en
            /// l’element i retorna true. Si no hi ha següent, no es posiciona 
            /// i retorna false.
            /// </summary>
            /// <returns></returns>
            public bool MoveNext()
            {
                bool retorna = false;
                if (posicio < limit - 1)
                {
                    posicio++;
                    retorna = true;
                }
                return retorna;
            }

            public void Dispose()
            {
                this.dades = null;
                Reset();
            }
        }
    }
}
