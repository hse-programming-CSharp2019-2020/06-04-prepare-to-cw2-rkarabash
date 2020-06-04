using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKRLib
{
    public class Collection<T> : IEnumerable<T> where T : Item
    {
        List<T> items = new List<T>();

        public Collection()
        {
        }

        public Collection(List<T> items)
        {
            this.items = items;
        }

        public void Add(T item) => items.Add(item);
        public IEnumerator<T> GetEnumerator()
        {
            return new CollectionEnumerator<T>(items);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class CollectionEnumerator<T> : IEnumerator<T> where T : Item
    {
        int position = -1;
        List<T> items = new List<T>();

        public CollectionEnumerator(List<T> items)
        {
            this.items = items.Where(x => x.Weight != 0).ToList();
        }

        public T Current => items[position];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            Reset();
        }

        public bool MoveNext()
        {
            position++;
            return position < items.Count;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
