using System;
using System.Collections.Generic;


namespace NET.W._2019.Gridushko._13
{
     public class BinaryTree<T> : IEnumerable<T>
    {
        /// <summary>
        /// Quantity of nodes
        /// </summary>
        public int Counter { get; private set; }

        private readonly Comparer<T> _comparer;
        private NodeTree<T> _root;

        /// <summary>
        /// Constructor of binary tree
        /// </summary>
        /// <param name="numbers">IEnumerables numbers</param>
        /// <exception cref="ArgumentNullException">Throws when one of parameters is null</exception>
        /// <param name="comparer">Comparer for nodes comparisons</param>
        public BinaryTree(IEnumerable<T> numbers, Comparer<T> comparer)
        {
            if (ReferenceEquals(numbers, null))
            {
                throw new ArgumentNullException($"{nameof(numbers)} should be not equal null");
            }
            if (ReferenceEquals(comparer, null))
            {
                throw new ArgumentNullException($"{nameof(comparer)} should be not equal null");
            }
            _comparer = comparer;
            foreach (var el in numbers)
            {
                this.Add(el);
            }
        }

        /// <summary>
        /// Constructor for binary tree
        /// </summary>
        /// <param name="numbers">IEnumerable numbers</param>
        public BinaryTree(IEnumerable<T> numbers) : this(numbers, Comparer<T>.Default) { }

        /// <summary>
        /// Constructor for binary tree
        /// </summary>
        /// <exception cref="ArgumentNullException">Throws when comparer is null</exception>
        /// <param name="comparer">Comparer for nodes comparisons</param>
        public BinaryTree(Comparer<T> comparer) =>
            _comparer = comparer ?? throw new ArgumentNullException($"{nameof(comparer)} should be not equal null");

        /// <summary>
        /// Constructor for binary tree
        /// </summary>
        public BinaryTree() : this(Comparer<T>.Default) { }

        /// <summary>
        /// Add data in tree
        /// </summary>
        /// <exception cref="ArgumentNullException">Throws when data is null</exception>
        /// <exception cref="InvalidOperationException">Throws when such an element in our tree already has it!</exception>
        /// <param name="data">Data for adding</param>
        public void Add(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException($"{nameof(data)} should be not equal null");
            }
            if (_root == null)
            {
                _root = new NodeTree<T>(data);
                return;
            }
            if (IsExists(data))
            {
                throw new InvalidOperationException($"{nameof(data)} our tree already has it!");
            }
            NodeTree<T> walker;
            walker = _root;
            while (walker != null)
            {
                if (_comparer.Compare(data, walker.Data) > 0)
                {
                    if (walker.RightNode == null)
                    {
                        walker.RightNode = new NodeTree<T>(data);
                        return;
                    }
                    walker = walker.RightNode;

                }
                else
                {
                    if (walker.LeftNode == null)
                    {
                        walker.LeftNode = new NodeTree<T>(data);
                        return;
                    }
                    walker = walker.LeftNode;
                }
            }
            _root = new NodeTree<T>(data);
            _root = walker;
            Counter++;
        }

        /// <summary>
        /// Delete operation from tree
        /// </summary>
        /// <exception cref="ArgumentNullException">Throws when data is null</exception>
        /// <exception cref="InvalidOperationException">Throws when there is no such element in the tree</exception>
        /// <param name="data">Data of deleting element</param>
        public void Delete(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException($"{nameof(data)} should be not equal null");
            }
            if (!IsExists(data))
            {
                throw new InvalidOperationException($"No {nameof(data)} in the tree");
            }

            NodeTree<T> walker = _root;
            NodeTree<T> previous = walker;
            while (_comparer.Compare(walker.Data, data) != 0)
            {
                previous = walker;
                walker = _comparer.Compare(walker.Data, data) > 0 ? walker.LeftNode : walker.RightNode;
            }
            if (walker.RightNode == null)
            {
                previous.LeftNode = null;
                return;
            }
            if (walker.LeftNode == null)
            {
                previous.LeftNode = null;
                return;
            }
            walker = walker.LeftNode;
            NodeTree<T> previous2 = walker;
            while (walker.RightNode != null)
            {
                previous2 = walker;
                walker = walker.RightNode;
            }
            NodeTree<T> tempNode = previous.RightNode;
            previous.RightNode = walker;
            previous2.RightNode = walker.LeftNode != null ? walker.LeftNode : null;
            walker.LeftNode = tempNode.LeftNode;
            walker.RightNode = tempNode.RightNode;
        }

        /// <summary>
        /// Сhecks for an element in a tree
        /// </summary>
        /// <param name="data">Element to search</param>
        /// <returns>True - if found, otherwise - false</returns>
        public bool IsExists(T data)
        {
            if (_root == null)
            {
                return false;
            }
            NodeTree<T> walker = _root;
            while (_comparer.Compare(walker.Data, data) != 0)
            {
                walker = _comparer.Compare(data, walker.Data) > 0 ? walker.RightNode : walker.LeftNode;
                if (walker == null)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Tree bypasse directly
        /// </summary>
        /// <returns>Sequence of bypasses numbers</returns>
        public IEnumerable<T> DirectlyBypass()
        {
            return DirectlyBypass(_root);
        }

        /// <summary>
        /// Tree bypasse symmetrically
        /// </summary>
        /// <returns>Sequence of bypasses numbers</returns>
        public IEnumerable<T> SymmetricalyBypass()
        {
            return SymmetricalyBypass(_root);
        }

        /// <summary>
        /// Tree bypasse in reverse order
        /// </summary>
        /// <returns>Sequence of bypasses numbers</returns>
        public IEnumerable<T> ReverseBypass()
        {
            return ReverseBypass(_root);
        }

        private IEnumerable<T> DirectlyBypass(NodeTree<T> node)
        {
            yield return node.Data;

            if (node.LeftNode != null)
            {
                foreach (var value in DirectlyBypass(node.LeftNode))
                {
                    yield return value;
                }
            }
            if (node.RightNode != null)
            {
                foreach (var value in DirectlyBypass(node.RightNode))
                {
                    yield return value;
                }
            }
        }

        private IEnumerable<T> SymmetricalyBypass(NodeTree<T> node)
        {
            if (node.LeftNode != null)
            {
                foreach (var value in SymmetricalyBypass(node.LeftNode))
                {
                    yield return value;
                }
            }

            yield return node.Data;

            if (node.RightNode != null)
            {
                foreach (var value in SymmetricalyBypass(node.RightNode))
                {
                    yield return value;
                }
            }
        }

        private IEnumerable<T> ReverseBypass(NodeTree<T> node)
        {
            if (node.LeftNode != null)
            {
                foreach (var value in ReverseBypass(node.LeftNode))
                {
                    yield return value;
                }
            }

            if (node.RightNode != null)
            {
                foreach (var value in ReverseBypass(node.RightNode))
                {
                    yield return value;
                }
            }

            yield return node.Data;
        }

        /// <summary>
        /// Get enumerator
        /// </summary>
        /// <returns>Enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return DirectlyBypass().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

}
