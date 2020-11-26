using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Stack
    {
        private const int MaxSize = 8;
        private object[] _items = new object[MaxSize];
        private int _currentIndex = -1;
        public Stack()
        {
        }
        public void Push(object element)
        {
            if (_currentIndex >= MaxSize - 1)
            {
                throw new InvalidOperationException("Stack is full");
            }
            _currentIndex++;
            _items[_currentIndex] = element;
        }
        public object Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("No elements in stack");
            }
            object element = _items[_currentIndex];
            _items[_currentIndex] = null;
            _currentIndex--;
            return element;
        }
        public object Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("No elements in stack");
            }
            return _items[_currentIndex];
        }
        public bool IsEmpty()
        {
            if (_currentIndex < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
