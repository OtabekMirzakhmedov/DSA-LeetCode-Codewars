namespace Codewars.WeightedGraph;

public class PrimAlgorithm
{
    public int MinCostConnectPoints(int[][] points) {
        if (points == null || points.Length <= 1) return 0;
        
        int n = points.Length;
        
        // Create all possible edges with their weights
        List<(int from, int to, int weight)> edges = new List<(int, int, int)>();
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                int distance = Math.Abs(points[i][0] - points[j][0]) + 
                               Math.Abs(points[i][1] - points[j][1]);
                
                edges.Add((i, j, distance));
            }
        }
        
        // Sort edges by weight
        edges.Sort((a, b) => a.weight.CompareTo(b.weight));
        
        HashSet<int> visited = new HashSet<int>();
        int totalCost = 0;
        
        // Start with the first point
        visited.Add(0);
        
        while (visited.Count < n) {
            // Find the minimum weight edge that connects a visited point to an unvisited point
            foreach (var edge in edges) {
                // Check if this edge connects a visited node to an unvisited node
                bool fromVisited = visited.Contains(edge.from);
                bool toVisited = visited.Contains(edge.to);
                
                if (fromVisited && !toVisited) {
                    visited.Add(edge.to);
                    totalCost += edge.weight;
                    break;
                } else if (!fromVisited && toVisited) {
                    visited.Add(edge.from);
                    totalCost += edge.weight;
                    break;
                }
                // Skip if both endpoints are visited or both are unvisited
            }
        }
        
        return totalCost;
    }
    
    public int MinCostConnectPoints2(int[][] points) {
        if (points == null || points.Length <= 1) return 0;
        
        int n = points.Length;
        bool[] visited = new bool[n];
        int[] minCost = new int[n];
        
        for (int i = 0; i < n; i++) {
            minCost[i] = int.MaxValue;
        }
        
        minCost[0] = 0;
        int totalCost = 0;
        
        for (int i = 0; i < n; i++) {
            int minIndex = -1;
            int min = int.MaxValue;
            
            for (int j = 0; j < n; j++) {
                if (!visited[j] && minCost[j] < min) {
                    min = minCost[j];
                    minIndex = j;
                }
            }
            
            visited[minIndex] = true;
            totalCost += min;
            
            for (int j = 0; j < n; j++) {
                if (!visited[j]) {
                    int dist = Math.Abs(points[minIndex][0] - points[j][0]) + 
                               Math.Abs(points[minIndex][1] - points[j][1]);
                    
                    if (dist < minCost[j]) {
                        minCost[j] = dist;
                    }
                }
            }
        }
        
        return totalCost;
    }
}