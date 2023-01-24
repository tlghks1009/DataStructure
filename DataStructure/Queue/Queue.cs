namespace List.Queue
{
    public class Queue<T>
    {
        private class QueueNode<T>
        {
            public T value;
            public QueueNode<T> nextNode;
        }

        private QueueNode<T> _currentNode;
        private QueueNode<T> _nextNode;
        
        private int _size;

        public Queue() { }

        public int Count => _size;
        
        public void Enqueue(T item)
        {
            var newNode = CreateQueueNode(item);
            
            if (_currentNode == null)
            {
                _currentNode = newNode;
            }

            _currentNode.nextNode = _nextNode;

            _nextNode = newNode;
            _nextNode.nextNode = newNode;
            
            _size++;
        }
        
        public T Dequeue()
        {
            if (_currentNode == null)
            {
                return default(T);
            }
            
            var result = _currentNode.value;

            _currentNode = _currentNode.nextNode;

            _size--;
            
            return result;
        }

        private QueueNode<T> CreateQueueNode(T item)
        {
            var newQueueNode = new QueueNode<T>
            {
                value = item
            };

            return newQueueNode;
        }
    }
}