using System;
using System.Collections.Generic;

namespace Codewars
{
    public class BinaryTree
    { 
        public class TreeNode { 
            public int val; 
            public TreeNode left; 
            public TreeNode right; 
            public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) { 
                this.val = val; 
                this.left = left; 
                this.right = right; 
            }
        }
        
        public TreeNode CreateBinaryTree(int?[] values)
        {
            if (values == null || values.Length == 0)
                return null;
            
            // First value cannot be null for the root
            if (values[0] == null)
                return null;
            
            TreeNode root = new TreeNode(values[0].Value);
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
        
            int i = 1;
            while (queue.Count > 0 && i < values.Length)
            {
                TreeNode current = queue.Dequeue();
            
                // Add left child
                if (i < values.Length)
                {
                    if (values[i] != null)
                    {
                        current.left = new TreeNode(values[i].Value);
                        queue.Enqueue(current.left);
                    }
                }
                i++;
            
                // Add right child
                if (i < values.Length)
                {
                    if (values[i] != null)
                    {
                        current.right = new TreeNode(values[i].Value);
                        queue.Enqueue(current.right);
                    }
                }
                i++;
            }
        
            return root;
        }
    }
}