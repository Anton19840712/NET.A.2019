using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace NET.W._2019.Gridushko._13

{
    [TestFixture]
    public class BinaryTreeTester
    {
        [Test]
        public void CreateTree_NullComparer_NullException()
        {
            Assert.Throws<ArgumentNullException>(() => new BinaryTree<string>(new List<string>(), null));
        }

        [Test]
        public void CreateTree_NullIEnumerable_NullException()
        {
            Assert.Throws<ArgumentNullException>(() => new BinaryTree<string>(null, Comparer<string>.Default));
        }

        [Test]
        public void AddingElementInTree_3ElementTreeAndAdd1Element_TreeOn4Elements()
        {
            BinaryTree<int> binTree = new BinaryTree<int>(new List<int> { 1, 2, 3 });
            binTree.Add(5);
            Assert.AreEqual(binTree, new BinaryTree<int>(new List<int> { 1, 2, 3, 5 }));
        }

        [Test]
        public void DeleteElementFromTree_TreeWith11ElementAndDelete1Element()
        {
            BinaryTree<int> binTree = new BinaryTree<int>(new List<int> { 115, 50, 1555, 50, 150, 305, 124, 535, 633, 565, 56 });
            binTree.Delete(50);
            Assert.AreEqual(binTree, new BinaryTree<int>(new List<int> { 115, 50, 1555, 50, 150, 305, 124, 535, 633, 565, 56 }));
        }

        [TestCase(new int[] { 10, 12, 11 }, 10, ExpectedResult = true)]
        [TestCase(new int[] { 10, 12, 11 }, 9, ExpectedResult = false)]
        public bool IsExistsTests_CorrectWork(IEnumerable<int> list, int element)
        {
            return new BinaryTree<int>(list).IsExists(element);
        }
        [Test]
        public void SymmetricalBypesse_ValidArgumentsBook()
        {
            Comparer<PointStruct> comparer = new PointComparer();
            BinaryTree<PointStruct> points = new BinaryTree<PointStruct>(new PointStruct[] { new PointStruct(5, 5), new PointStruct(3, 3), new PointStruct(4, 4) }, comparer);
        }

    }
}
