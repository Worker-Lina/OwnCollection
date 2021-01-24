using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace OwnCollection
{
    public class MyCollection<T> : IList<T> where T: IComparable<T>
    {

        private T[] _list;
        private int _count = 0;

        public T this[int index] 
        {
            get
            {
                return _list[index];
            }
            set
            {
                _list[index] = value;
            }
        }

        public int Count { get { return _count; } }

        public bool IsReadOnly { get { return false; } }

        public void Add(T item)
        {
            T[] newList = new T[_count + 1];
            for (int i = 0; i < _count; i++)
            {
                newList[i] = _list[i];
            }
            newList[_count] = item;
            _count++;
            _list = newList;
        }

        public void Clear()
        {
            _list = null;
            _count = 0;
        }


        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (item.Equals(_list[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < Count; i++)
            {
                array.SetValue(_list[i], arrayIndex++);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (item.Equals(_list[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if ((_count + 1 <= _list.Length) && (index < Count) && (index >= 0))
            {
                _count++;

                for (int i = Count - 1; i > index; i--)
                {
                    _list[i] = _list[i - 1];
                }
                _list[index] = item;
            }
        }

        public bool Remove(T item)
        {
            if (item.Equals(_list))
            {
                RemoveAt(IndexOf(item));
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveAt(int index)
        {
            if ((index >= 0) && (index < Count))
            {
                for (int i = index; i < Count - 1; i++)
                {
                    _list[i] = _list[i + 1];
                }
                _count--;
            }
        }

        public void Sort() 
        {
            for (int i = 0; i < Count; i++)
            {
                for (int j = 1; j < Count; j++)
                {
                    if (_list[j].CompareTo(_list[j - 1]) < 0)
                    {
                        T temp = _list[j];
                        _list[j] = _list[j - 1];
                        _list[j - 1] = temp;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Reverse()
        {
            var newList = new T[Count];
            for (int i = Count-1, j=0; i >= 0; i--, j++)
            {
                newList[j] = _list[i];
            }
            _list = newList;
            newList = null;
        }

    }
}

