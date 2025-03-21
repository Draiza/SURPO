using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZOO_ZooList
{
    abstract class ZooList<T>
    {
        //Список
        public List<T> items = new List<T>();

        //Базовые методы
        public void AddList(T item) => items.Add(item);
        public void RemoveList(T item) => items.Remove(item);
        public virtual void ShowList() { }
    }
}
