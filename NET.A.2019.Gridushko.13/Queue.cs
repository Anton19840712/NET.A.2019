using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Gridushko._13
{
        public class QueueT<T> : IEnumerable<T>
        {
            private const int multiplierCoeffSize = 2;

            private T[] numbers;
            private int head;
            private int tail;
            private int capasity;
            private int count;
            private int version;

            /// <summary>
            /// Queue creation
            /// </summary>
            /// <exception cref="ArgumentException">When input parameter = 0</exception>
            /// <param name="startSize">Start queue size</param>
            public QueueT(int startSize)
            {
                if (startSize <= 0)
                {
                    throw new ArgumentException($"{nameof(startSize)} can't be 0");
                }
                head = 0;
                tail = -1;
                capasity = startSize;
                count = 0;
                version = 0;
                numbers = new T[startSize];
            }

            /// <summary>
            /// Empty queue creation
            /// </summary>
            public QueueT() : this(1) { }

            /// <summary>
            /// Queue creation from the collection
            /// </summary>
            /// <exception cref="ArgumentNullException">When input parameter is null</exception>
            /// <param name="list">Collection for the queue</param>
            public QueueT(IEnumerable<T> list) : this(list.Count())
            {
                if (ReferenceEquals(list, null))
                {
                    throw new ArgumentNullException($"{nameof(list)} should be not equal null");
                }
                foreach (var element in list)
                {
                    Enqueue(element);
                }
            }

            /// <summary>
            /// Adding element to the queue
            /// </summary>
            /// <param name="element">Element for the queue</param>
            public void Enqueue(T element)
            {
                if (isFull())
                {
                    Resize();
                }
                tail = (tail + 1) % capasity;
                numbers[tail] = element;
                version++;
                count++;
            }


            /// <summary>
            /// Leaving item from queue
            /// </summary>
            /// <exception cref="InvalidOperationException">Thrown when number of numbers in queue equals 0</exception>
            /// <returns>The item that left the queue </returns>
            public T Dequeue()
            {
                if (IsEmpty())
                {
                    throw new InvalidOperationException("Unable to remove item from empty queue");
                }
                T tempStorage = numbers[head];
                head = (head + 1) % capasity;
                count--;
                version++;
                return tempStorage;
            }

            /// <summary>
            /// Here we take the first element in the queue
            /// </summary>
            /// <exception cref="InvalidOperationException">Throws when the queue is empty</exception>
            /// <returns>First element</returns>
            public T Peek()
            {
                if (IsEmpty())
                {
                    throw new InvalidOperationException($"Queue can't be empty");
                }
                return numbers[head];
            }

            /// <summary>
            /// Checks queue is empty
            /// </summary>
            /// <returns>true when queue is empty and false when queue has 1 or more element</returns>
            public bool IsEmpty()
            {
                return count == 0 ? true : false;
            }

            /// <summary>
            /// Get number of numbers in the queue
            /// </summary>
            /// <returns>Quantity of numbers in the queue</returns>
            public int Count() => count;

            /// <summary>
            /// Get iterator for the queue
            /// </summary>
            /// <returns>Object of IEnumerator</returns>
            public IEnumerator GetEnumerator() => new QueueIterator(this);

            IEnumerator IEnumerable.GetEnumerator() => new QueueIterator(this);

            IEnumerator<T> IEnumerable<T>.GetEnumerator() => new QueueIterator(this);


            internal T GetElement(int index)
            {
                return numbers[(head + index) % count];
            }

            private void Resize()
            {
                T[] newArray = new T[capasity * multiplierCoeffSize];
                if (head > tail)
                {
                    Array.Copy(numbers, head, newArray, 0, capasity - head);
                    Array.Copy(numbers, 0, newArray, capasity - head + 1, tail);
                }
                else
                {
                    Array.Copy(numbers, head, newArray, 0, count);
                }
                capasity *= multiplierCoeffSize;
                head = 0;
                tail = count - 1;
                numbers = newArray;
            }

            private bool isFull()
            {
                return count == capasity ? true : false;
            }

            private struct QueueIterator : IEnumerator<T>
            {
                private QueueT<T> queue;
                private int index;
                private int version;
                private T currentElement;
                bool currentFlag;

                internal QueueIterator(QueueT<T> queue)
                {
                    this.queue = queue;
                    version = queue.version;
                    index = 0;
                    currentElement = default(T);
                    currentFlag = true;
                    if (queue.count == 0)
                    {
                        index = -1;
                    }
                }

                public bool MoveNext()
                {
                    currentFlag = true;
                    if (version != queue.version)
                    {
                        throw new InvalidOperationException($"{nameof(queue)} version has been changed");
                    }

                    if (index < 0)
                    {
                        currentFlag = false;
                        return false;
                    }
                    currentElement = queue.GetElement(index);
                    index++;

                    if (index == queue.count)
                    {
                        index = -1;
                    }
                    return true;

                }

                public T Current
                {
                    get
                    {
                        if (!currentFlag)
                        {
                            if (index == 0)
                            {
                                throw new InvalidOperationException();
                            }
                            else
                            {
                                throw new InvalidOperationException();
                            }
                        }
                        return currentElement;
                    }
                }

                object IEnumerator.Current => this.Current;

                public void Reset()
                {
                    if (version != queue.version)
                    {
                        throw new InvalidOperationException();
                    }
                    if (queue.count == 0)
                    {
                        index = -1;
                    }
                    else
                    {
                        index = 0;
                    }
                    currentFlag = false;
                }

                void IDisposable.Dispose() { }
            }
        }
}