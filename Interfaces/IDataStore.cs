using System;
using System.Collections.Generic;
using System.Text;

namespace App_Dev_VisalStudio
{
    public interface IDataStore<T>
    {
        void CreateItem(T data);
        T ReadItem();
        void UpdateItem(T data);
        void DeleteItem();
    }
}
