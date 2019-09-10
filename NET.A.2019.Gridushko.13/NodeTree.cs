using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Gridushko._13
{
    internal class NodeTree<T>
    {
        internal T Data { get; set; }
        internal NodeTree<T> LeftNode { get; set; }
        internal NodeTree<T> RightNode { get; set; }

        /// <summary>
        /// Constructor of tree node
        /// </summary>
        /// <param name="data">Data of node</param>
        public NodeTree(T data)
        {
            Data = data;
            LeftNode = null;
            RightNode = null;
        }
        public NodeTree() { }
    }
}
