using System;

namespace List.Stack
{
    public class Stack<T>
    {
        private static readonly int MULTIPLES_OF_CAPACITY = 2;
        private T[] _itemArray;
        
        private int _currentSize;

        public int Count => _currentSize;

        public Stack(int size = 0)
        {
            _currentSize = 0;
            _itemArray = new T[size];
        }

        public void Push(T item)
        {
            if (IsCapacityFull())
            {
                IncreaseCapacity();
            }

            _itemArray[_currentSize++] = item;
        }

        public T Pop()
        {
            if (_currentSize < 0)
            {
                return default(T);
            }

            var obj = _itemArray[--_currentSize];

            _itemArray[_currentSize] = default(T);
            
            return obj;
        }
        
        private void IncreaseCapacity()
        {
            var newArray = new T[_itemArray.Length * MULTIPLES_OF_CAPACITY];

            Array.Copy(_itemArray, 0, newArray, 0, _currentSize);
                
            _itemArray = newArray;
        }

        private bool IsCapacityFull() => _currentSize >= _itemArray.Length;
    }
}