using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenerics.Structures
{
    public class HashTable<S, T> where T : IComparable
    {


        //ListArray. 
        List<T>[] dataArray;
        int arrayLength;
        /// <summary>
        /// Constructor of HashTable. 
        /// Write the arrayLength param in order to set the array of the hash teble. 
        /// </summary>
        /// <param name="arrayLength"></param>
        public HashTable(int arrayLength)
        {
            this.arrayLength = arrayLength;
            dataArray = new List<T>[arrayLength];

            for (int i = 0; i < dataArray.Length; i++)
            {
                dataArray[i] = new List<T>();
            }
        }


        private int Hash(string key)
        {
            int sumaDeElementos = 0;

            for (int i = 0; i < key.Length; i++)
                sumaDeElementos += Convert.ToInt32(key[i]) * (i + 1);

            int retorno = sumaDeElementos % arrayLength;
            return retorno;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>Retorna false cuando la llave existe con anterioridad</returns>
        public void Insert(S key, T value)
        {
            if (!KeyExist(key))
            {
                int arrayIndex = Hash(key.ToString());
                dataArray[arrayIndex].Add(value);
            }
        }

        public bool KeyExist(S key)
            => (Search(key) != null) ? true : false;

        public void Delete(S key)
        {
            int arrayIndex = Hash(key.ToString());

            foreach (var item in dataArray[arrayIndex])
            {
                //Use a custom object whith own compareTo method. 
                if (item.CompareTo(key.ToString()) == 0)
                {
                    dataArray[arrayIndex].Remove(item);
                    break;
                }
            }
        }

        public T Search(S key)
        {
            int Index = Hash(key.ToString());

            List<T> element = dataArray[Index];

            T retorno = element.Find((data) => {
                if (data.CompareTo(key.ToString()) == 0)
                    return true;
                else
                    return false;
            });

            return retorno;

        }

        /// <summary>
        /// Return the complete data set in the hashmap, 
        /// like List<T>
        /// </summary>
        /// <returns></returns>
        public List<T> AllDataLikeList()
        {
            List<T> retorno = new List<T>();

            foreach (var item in this.dataArray)
            {
                if (item != null)
                {
                    foreach (var internItem in item)
                    {
                        retorno.Add(internItem);
                    }
                }
                
            }

            return retorno;

        }

    }
}
