using System;
using System.Collections.Generic;

namespace List
{
    public class List<T>
    {
        private static readonly int MULTIPLES_OF_CAPACITY = 2;
        private T[] _itemArray;

        private int _currentSize;
        public int Count => _currentSize;
        
        public List(int size = 0)
        {
            _currentSize = 0;
            _itemArray = new T[size];
        }
        
        public T this[int index]
        {
            get => _itemArray[index];
            set => _itemArray[index] = value;
        }

        public void Add(T value)
        {
            if (IsCapacityFull())
            {
                IncreaseCapacity();
            }
            
            _itemArray[_currentSize++] = value;
        }

        public void Remove(T item)
        {
            var index = Array.IndexOf(_itemArray, item);
            if (index == -1)
            {
                return;
            }
            
            RemoveAt(index);
        }


        public void RemoveAt(int index)
        {
            _currentSize--;

            for (int arrayIndex = index; arrayIndex < _itemArray.Length; arrayIndex++)
            {
                _itemArray[arrayIndex] = _itemArray[arrayIndex + 1];
            }
            _itemArray[_itemArray.Length - 1] = default(T);
        }


        private void IncreaseCapacity()
        {
            var newArray = new T[_itemArray.Length * MULTIPLES_OF_CAPACITY];

            Array.Copy(_itemArray, 0, newArray, 0, _currentSize);
            
            _itemArray = newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int arrayIndex = 0; arrayIndex < _itemArray.Length; arrayIndex++)
            {
                yield return _itemArray[arrayIndex];
            }
        }

        private bool IsCapacityFull() => _currentSize >= _itemArray.Length; 
    }
}