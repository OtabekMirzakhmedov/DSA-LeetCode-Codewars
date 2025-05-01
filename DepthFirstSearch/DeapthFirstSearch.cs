namespace Codewars.DepthFirstSearch;

public class DeapthFirstSearch
{
    public void DFS(BinaryTree.TreeNode root)
    {
        Stack<BinaryTree.TreeNode> stack = new Stack<BinaryTree.TreeNode>();
        stack.Push(root);

        while (stack.Count > 0)
        {
            BinaryTree.TreeNode node = stack.Pop();
            Console.WriteLine(node.val);
            if (node.left != null)
                stack.Push(node.left);
                
            if (node.right != null)
                stack.Push(node.right);
        }
    }
    
    public void PostorderTraversal(BinaryTree.TreeNode node)
    {
        if (node == null)
            return;

        PostorderTraversal(node.left);
        
        PostorderTraversal(node.right);
        
        Console.Write(node.val + " ");
    }
    
    public void InorderTraversal(BinaryTree.TreeNode node)
    {
        if (node == null)
            return;

        InorderTraversal(node.left);

        Console.Write(node.val + " ");
        
        InorderTraversal(node.right);
    }
}