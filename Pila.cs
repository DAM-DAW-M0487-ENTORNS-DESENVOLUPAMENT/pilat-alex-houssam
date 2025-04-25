using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PILA
{
    internal class Pila<T> : ICollection<T>
    {
        private T[] data;
        const int DEFAULT_SIZE = 5;
        private int top = -1;

        /// Constructors:
        public Pila(int mida)
        {
            this.data = new T[mida];

        }
        public Pila() : this(DEFAULT_SIZE) { }
        public Pila(IEnumerable<T> dades)
        {
            data = new T[dades.Count()];
            foreach (T element in dades)
            {
                Push(element);
            }
        }
        /// <summary>
        /// Propietat que retorna la quantitat de elements que te lobjecte. 
        /// </summary>
        public int Count
        {
            get
            {
                return top + 1;
            }
        }
        /// <summary>
        /// Propietat que retorna la capacidad de la pila.
        /// </summary>
        public int Capacity
        {
            get
            {
                return data.Length;
            }
        }
        /// <summary>
        /// Propietat que retorna false per donar a entendre que en aquesta clase no es IsReadOnly. 
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Propietat que retorna true si la pila esta plena.
        /// </summary>
        public bool IsFull
        {
            get
            {
                return Count == Capacity;
            }
        }
        /// <summary>
        /// Retorna true si la pila esta vuida
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return top == -1;
            }
        }
        /// <summary>
        /// retorna el valor de la 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException("El index esta fora de rang");
                return this.data[top - index];
            }
        }
        /// <summary>
        /// Retorna un array amb els elements de la pila utilitzand el enumerator
        /// </summary>
        /// <returns></returns>
        public T[] ToArray()
        {
            T[] arrayResposta = new T[Count];
            int i = 0;

            foreach (T element in this)
            {
                arrayResposta[i++] = element;
            }
            return arrayResposta;
        }
        /// <summary>
        /// Metoda privat que duplica la capacidad de l'array
        /// al doble de capacidad mantenint el contingut.
        /// </summary>
        private void DoubleCapacity()
        {
            T[] nou = new T[Capacity * 2];
            for (int i = 0; i < top + 1; i++)
            {
                nou[i] = data[i];
            }
            data = nou;
        }
        /// <summary>
        /// Borra el contingut de tot el array.
        /// </summary>
        /// <exception cref="NotSupportedException"></exception>
        public void Clear()
        {
            if (this.IsReadOnly) throw new NotSupportedException("NO ES POT BORRAR LA PILA PERQUE NOMES ES DE LECTURA");
            for (int i = 0; i < Count; i++)
            {
                data[i] = default(T);
            }
            top = -1;
        }
        /// <summary>
        /// El metoda encarregat de afagir nous elements a la pila.
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="StackOverflowException">Excepcio de que no hiha res en la pila</exception>
        public void Push(T item)
        {
            if (IsFull) throw new StackOverflowException("NO ES POT FER PUSH PERQUE LA PILA ESTA PLENA");
            top++;
            this.data[top] = item;
        }
        /// <summary>
        /// Metoda encarregat de mostrar el ultim element de la pila i treural de la coleccio.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Excepcio de que no hiha res en la pila</exception>
        public T Pop()
        {
            if (IsEmpty) throw new InvalidOperationException("NO HI HA RES EN LA PILA NO ES POT VEURE RES");
            T resposta = this.data[top];
            this.data[top] = default(T);
            top--;
            return resposta;
        }
        /// <summary>
        /// Metoda que retorna el ultim valor de la pila sense manipular res.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Excepcio de que no hiha res en la pila</exception>
        public T Peek()
        {
            if (IsEmpty) throw new InvalidOperationException("NO HI HA RES EN LA PILA NO ES POT VEURE RES");
            return this.data[top];
        }
        /// <summary>
        /// Retorna true si es troba l'element en la pila, false si no es troba.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            bool trobat = false;
            int i = 0;
            while (i < Count && !trobat)
            {
                if (data[i++].Equals(item))
                {
                    trobat = true;
                }
            }
            return trobat;
        }
        /// <summary>
        /// amplia la capacitat de la pila en cas que la la capacitat actual sigui menor que newCapacity
        /// </summary>
        /// <param name="newCapacity"></param>
        /// <returns></returns>
        public int EnsureCapacity(int newCapacity)
        {
            if (Capacity < newCapacity)
            {
                T[] novaData = new T[newCapacity];
                for (int i = 0; i < Count; i++)
                {
                    novaData[i] = data[i];
                }
                data = novaData;
            }
            return Capacity;
        }
        /// <summary>
        /// Copia tots els elements del array T[] this a l’array T[] array passat per
        /// paràmetre, començant per la posició arrayIndex.
        /// </summary>
        /// <param name="array">T[] array passat per paràmetre</param>
        /// <param name="arrayIndex">La posició per la cual comença</param>
        /// <exception cref="ArgumentNullException">Exception surt cuanto el array es null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Exception surt cuant el arrayIndex esta fora de rang</exception>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException("AQUEST ARRAY NO A ESTAT INIZIALITZAT");
            if (array.Length - arrayIndex < this.top + 1) throw new ArgumentOutOfRangeException("NO ES POT MODIFICAR PERQUE ES SURT DEL ARRAY");
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException("EL ARRAYINDEX INTRODUIT ES SURT DEL ESPAI DEL ARRAY");
            foreach (T item in this)
            {
                array[arrayIndex++] = item;
            }
        }
        /// <summary>
        /// Implementa el enumerator personalizad per la pila
        /// </summary>
        /// <returns>Enumerator de la pila</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new EnumeradorPila<T>(this.data, this.top);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Retorna una cadena del contingut de la pila.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            int posicio = 1;
            StringBuilder sb = new StringBuilder("[ ");
            IEnumerator<T> cursor = ((IEnumerable<T>)this).GetEnumerator();
            cursor.Reset();
            if (IsEmpty) sb.Append($"]"); //Si esta vuida directamente entrega [];
            else
            {
                while (cursor.MoveNext())
                {
                    if (posicio != Count) //Si no es la ultima posicio
                    {
                        sb.Append($"{cursor.Current}, ");
                        posicio++;
                    }
                    else
                    {
                        sb.Append($"{cursor.Current} ] ");
                    }
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// Metoda Equals que retorna True;
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool igual;
            if (ReferenceEquals(null, obj)) igual = false;
            else if (ReferenceEquals(this, obj)) igual = true;
            else if (obj.GetType() != this.GetType()) igual = false;
            else igual = this.Equals((Pila<T>)obj);
            return igual;
        }
        private bool Equals(Pila<T> other)
        {
            int i = 0;
            bool igual = true;
            if (Capacity == other.Capacity && Count == other.Count)
            {
                while (i < Count && igual)
                {
                    if (!Equals(this.data[i], other.data[i]))
                    {
                        igual = false;
                    }
                    else i++;
                }
            }
            return igual;
        }
        public class EnumeradorPila<T> : IEnumerator<T>
        {
            private int limit;
            private int posicio;
            private T[] dades;
            private int inici;

            /// <summary>
            /// Constructor principal.
            /// </summary>
            /// <param name="dades"></param>
            /// <param name="nElement"></param>
            public EnumeradorPila(T[] dades, int top)
            {
                this.dades = dades;
                this.limit = 0;
                this.inici = top + 1;
                this.posicio = inici;
            }
            /// <summary>
            /// Propietat Reset que retorna a la posicio -1 per tal que quan
            /// es faci el primer MoveNext ens situem en el primer.
            /// </summary>
            public void Reset()
            {
                posicio = inici;
            }
            /// <summary>
            /// Propietat que et dona el valor per la posicio. 
            /// </summary>
            public T Current
            {
                get
                {
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
                if (posicio > limit)
                {
                    posicio--;
                    retorna = true;
                }
                return retorna;
            }
            /// <summary>
            /// Restableix deixant-lo buit.
            /// </summary>
            public void Dispose()
            {
                this.dades = null;
                Reset();
            }
        }
    }
}
