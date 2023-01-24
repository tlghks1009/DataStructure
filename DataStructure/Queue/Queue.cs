namespace DataStructure.Queue
{
    public class Queue<T>
    {
        private class Node<T>
        {
            public T value;
            public Node<T> nextNode;

            public Node(T value)
            {
                this.value = value;
            }
        }

        private Node<T> _currentNode;
        private Node<T> _nextNode;
        
        private int _size;

        public Queue() { }

        public int Count => _size;
        
        public void Enqueue(T item)
        {
            var newNode = CreateNode(item);
            
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

        private Node<T> CreateNode(T item) => new Node<T>(item);
    }
}