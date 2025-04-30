namespace Codewars;

public class Program
{
    public static void Main2()
    {
        int[] rootp = { 1,2,2,3,4,4,3};
        int [] rootq = { 1,2,2,3,4,4,3};
        BinaryTree binaryTree = new BinaryTree();
        BinaryTree.TreeNode RootTreep = binaryTree.CreateBinaryTree(rootp);
        BinaryTree.TreeNode RootTreeq = binaryTree.CreateBinaryTree(rootq);
        BreadthFirstSearch.BreadthFirstSearch breadthFirstSearch = new BreadthFirstSearch.BreadthFirstSearch();
        var res = breadthFirstSearch.IsSameTree(RootTreep, RootTreeq);
        breadthFirstSearch.BFS(RootTreep);


    }

}