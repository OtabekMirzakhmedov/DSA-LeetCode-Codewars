namespace Codewars.DepthFirstSearch;

public class FindPath
{
    public bool ValidPath(int n, int[][] edges, int source, int destination) {
        List<List<int>> graph = new List<List<int>>();
        
        for (int i = 0; i < n; i++) {
            graph.Add(new List<int>());
        }
        
        foreach (var edge in edges) {
            int u = edge[0];
            int v = edge[1];
            graph[u].Add(v);
            graph[v].Add(u);
        }
        
        bool[] visited = new bool[n];
        
        Stack<int> stack = new Stack<int>();
        stack.Push(source);
        
        while (stack.Count > 0) {
            int current = stack.Pop();
            
            if (current == destination) {
                return true;
            }
            
            if (visited[current]) {
                continue;
            }
            
            visited[current] = true;
            
            foreach (int neighbor in graph[current]) {
                if (!visited[neighbor]) {
                    stack.Push(neighbor);
                }
            }
        }
        return false;
    }
}