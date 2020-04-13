using System;
using CustomGenerics.Interfaces;
using System.IO;

namespace CustomGenerics.Interfaces
{
    public interface ILinearDataBase<T>
    {
        void Insert(bool priority, T value);
        T Delete();
    }
}
