namespace Codewars.BreadthFirstSearch;

public class BreadthFirstSearch
{
    private enum NodeState
    {
        Undiscovered,
        Discovered,
        Processed
    }
    
    public bool IsSameTree(BinaryTree.TreeNode p, BinaryTree.TreeNode q) {
        Queue<(BinaryTree.TreeNode, BinaryTree.TreeNode)> queue = new Queue<(BinaryTree.TreeNode, BinaryTree.TreeNode)>();

        queue.Enqueue((p, q));

        while (queue.Count > 0) {
            var (node1, node2) = queue.Dequeue();
            
            if (node1 == null && node2 == null) {
                continue;
            }
            if (node1 == null || node2 == null) {
                return false;
            }
            
            if (node1.val != node2.val) {
                return false;
            }
            
            queue.Enqueue((node1.left, node2.left));
            queue.Enqueue((node1.right, node2.right));
        }
        
        return true;
    }
    
    public void BFS(BinaryTree.TreeNode root) 
    {
        if (root == null)
        {
            Console.WriteLine("Tree is empty.");
            return;
        }

        // Dictionary to keep track of node states and parents
        Dictionary<BinaryTree.TreeNode, NodeState> state = new Dictionary<BinaryTree.TreeNode, NodeState>();
        Dictionary<BinaryTree.TreeNode, BinaryTree.TreeNode> parent = new Dictionary<BinaryTree.TreeNode, BinaryTree.TreeNode>();
        
        // Initialize the root
        state[root] = NodeState.Discovered;
        parent[root] = null; // Root has no parent
        
        // Create queue for BFS
        Queue<BinaryTree.TreeNode> queue = new Queue<BinaryTree.TreeNode>();
        queue.Enqueue(root);
        
        // For collecting the traversal result
        List<int> traversalResult = new List<int>();
        
        while (queue.Count > 0)
        {
            // Dequeue a node
            BinaryTree.TreeNode current = queue.Dequeue();
            
            // Process current node
            Console.WriteLine($"Processing node: {current.val}");
            traversalResult.Add(current.val);
            
            // Process left child if it exists
            if (current.left != null)
            {
                Console.WriteLine($"Examining edge: ({current.val} -> {current.left.val})");
                
                // Initialize state if we haven't seen this node before
                if (!state.ContainsKey(current.left))
                {
                    state[current.left] = NodeState.Undiscovered;
                }
                
                if (state[current.left] == NodeState.Undiscovered)
                {
                    state[current.left] = NodeState.Discovered;
                    parent[current.left] = current;
                    queue.Enqueue(current.left);
                }
            }
            
            // Process right child if it exists
            if (current.right != null)
            {
                Console.WriteLine($"Examining edge: ({current.val} -> {current.right.val})");
                
                // Initialize state if we haven't seen this node before
                if (!state.ContainsKey(current.right))
                {
                    state[current.right] = NodeState.Undiscovered;
                }
                
                if (state[current.right] == NodeState.Undiscovered)
                {
                    state[current.right] = NodeState.Discovered;
                    parent[current.right] = current;
                    queue.Enqueue(current.right);
                }
            }
            
            // Mark current node as processed
            state[current] = NodeState.Processed;
        }
        
        // Print the traversal result
        Console.WriteLine("\nBFS Traversal Result:");
        Console.WriteLine(string.Join(", ", traversalResult));
        
        // Print the BFS tree (parent relationships)
        Console.WriteLine("\nBFS Tree (Parent Relationships):");
        foreach (var entry in parent)
        {
            string parentValue = entry.Value == null ? "null" : entry.Value.val.ToString();
            Console.WriteLine($"Node {entry.Key.val}: Parent = {parentValue}");
        }
    }
    
    // A simpler implementation of BFS for level-order traversal
    public List<int> LevelOrderTraversal(BinaryTree.TreeNode root)
    {
        List<int> result = new List<int>();
        
        if (root == null)
            return result;
            
        Queue<BinaryTree.TreeNode> queue = new Queue<BinaryTree.TreeNode>();
        queue.Enqueue(root);
        
        while (queue.Count > 0)
        {
            BinaryTree.TreeNode current = queue.Dequeue();
            result.Add(current.val);
            
            if (current.left != null)
                queue.Enqueue(current.left);
                
            if (current.right != null)
                queue.Enqueue(current.right);
        }
        
        return result;
    }
    
    // If you want to get the levels separately
    public List<List<int>> LevelOrderTraversalByLevel(BinaryTree.TreeNode root)
    {
        List<List<int>> result = new List<List<int>>();
        
        if (root == null)
            return result;
            
        Queue<BinaryTree.TreeNode> queue = new Queue<BinaryTree.TreeNode>();
        queue.Enqueue(root);
        
        while (queue.Count > 0)
        {
            int levelSize = queue.Count;
            List<int> currentLevel = new List<int>();
            
            for (int i = 0; i < levelSize; i++)
            {
                BinaryTree.TreeNode current = queue.Dequeue();
                currentLevel.Add(current.val);
                
                if (current.left != null)
                    queue.Enqueue(current.left);
                    
                if (current.right != null)
                    queue.Enqueue(current.right);
            }
            
            result.Add(currentLevel);
        }
        
        return result;
    }
    
    
}