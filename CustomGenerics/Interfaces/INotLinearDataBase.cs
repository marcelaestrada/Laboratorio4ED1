using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenerics.Interfaces
{
    public interface INotLinearDataBase<T>
    {
        void Insert(T[] array, int size);
    }
}
