using Codewars.DepthFirstSearch;

namespace Codewars;

public class Program
{
    public static void Main2()
    {
        int?[] rootp = { 5,4,8,11,null,13,4,7,2,null,null,null,1};
        BinaryTree binaryTree = new BinaryTree();
        BinaryTree.TreeNode RootTreep = binaryTree.CreateBinaryTree(rootp);

        DepthFirstSearch.DeapthFirstSearch dfs = new DeapthFirstSearch();
        dfs.InorderTraversal(RootTreep);


    }

}