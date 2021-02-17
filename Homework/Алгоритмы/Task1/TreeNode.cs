using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class TreeNode<T>
    {
        public T Data { get; }

        public List<TreeNode<T>> Child { get; set; }

        public TreeNode(T data)
        {
            this.Data = data;
            this.Child = new List<TreeNode<T>>();
        }

        public IEnumerable<TreeNode<T>> DepthFirstTraversal()
        {
           
        }

        public IEnumerable<TreeNode<T>> BreadthFirstTraversal()
        {
          
        }
    }

    // thid code:
    var tree = new TreeNode<int>(0)
    {
        Child = new List<TreeNode<int>>
    {
        new TreeNode<int>(10)
        {
            Child = new List<TreeNode<int>>
            {
                new TreeNode<int>(11),
                new TreeNode<int>(12)
            }
        },
        new TreeNode<int>(20)
        {
            Child = new List<TreeNode<int>>
            {
                new TreeNode<int>(21),
                new TreeNode<int>(22)
            }
        },
        new TreeNode<int>(30)
        {
            Child = new List<TreeNode<int>>
            {
                new TreeNode<int>(31)
            }
        }
    }
    };
}
