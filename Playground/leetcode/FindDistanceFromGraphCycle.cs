using System.Linq;
using System.Xml.Linq;

namespace PlaygroundTests.leetcode;

public class FindDistanceFromGraphCycle
{
    public static int[] calcNodeDistanceFromCycle((int, int)[] graph)
    {
        graph = new (int, int)[]
        {
            (1, 2),
            (1, 3),
            (1, 4),
            (2, 3),
            (2, 5),
            (3, 6)};
        var adjacencyList = new Dictionary<int, HashSet<int>>();
        var uniqueNodes = new HashSet<int>() { 1, 2, 3, 4, 5, 6 }; // define
        Func<Dictionary<int, HashSet<int>>, int, int, Dictionary<int, HashSet<int>>> upsert =
            (adjGraph, k, v) =>
            {
                if (adjGraph.ContainsKey(k))
                {
                    adjGraph[k].Add(v);
                }
                else
                {
                    adjGraph[k] = new HashSet<int>() { v };
                }
                return adjGraph;
            };
        foreach ( var node in graph)
        {
            var left = node.Item1;
            var right = node.Item2;
            upsert(adjacencyList, left, right);
            upsert(adjacencyList, right, left);
        }
        
        var listToVisit = adjacencyList.ToList();
        var visited = new HashSet<int>();
        var elementsWithCycle = new HashSet<int>();
        var currentVisitedStack = new HashSet<int>();
        foreach ( var node in listToVisit)
        {
            elementsWithCycle = lookForCycles(
                node.Key, node.Key, adjacencyList, 
                currentVisitedStack, visited, elementsWithCycle)["cycles"];
        }

        var numToDistanceFromCycle = new SortedDictionary<int, int>();
        foreach ( var element in elementsWithCycle)
        {
            numToDistanceFromCycle.Add(element, 0);
        }

        var nonCycleElements = uniqueNodes.Select(n => n).ToHashSet();
        nonCycleElements.ExceptWith(elementsWithCycle);
        var visitedForFilling = new HashSet<int>();
        foreach ( var element in nonCycleElements) // 10
        {
            numToDistanceFromCycle = fillWithDistanceFromCycle(adjacencyList, element, adjacencyList[element], numToDistanceFromCycle);
        }

        return numToDistanceFromCycle.Values.ToArray();
    }
    // from 10 to 7
    private static SortedDictionary<int, int> 
        fillWithDistanceFromCycle(
        Dictionary<int, HashSet<int>> adjacencyList,
        int node,
        HashSet<int> neighbors, 
        SortedDictionary<int, int> numToDistanceFromCycle)
    {
        var alreadyFoundDistanceForElement = numToDistanceFromCycle.ContainsKey(node);
        foreach(var neighbor in  neighbors)
        {
            var foundDistanceForElementNeighbor = numToDistanceFromCycle.ContainsKey(neighbor); // 7 = null (1);
            var shouldAdd = !alreadyFoundDistanceForElement && foundDistanceForElementNeighbor;
            var shouldRecur = !foundDistanceForElementNeighbor;
            if (shouldAdd)
            {
                numToDistanceFromCycle[node] = numToDistanceFromCycle[neighbor] + 1;
            }
            else if (shouldRecur)
            {
                var neighborsOfNeighbors = adjacencyList[neighbor];
                numToDistanceFromCycle = fillWithDistanceFromCycle(adjacencyList, neighbor, neighborsOfNeighbors, numToDistanceFromCycle);
            }
        }
        return numToDistanceFromCycle;
    }

    private static Dictionary<string, HashSet<int>>
        lookForCycles(
        int node, // 1
        int parent, // 4
        Dictionary<int, HashSet<int>> adjacencyList,
        HashSet<int> currentVisitStack,
        HashSet<int> visited, // 7 4 1 3
        HashSet<int> elementsWithCycle)
    {
        var neighbors = adjacencyList[node]; // 2 3 8 4
        visited.Add(node);
        var outcome = new Dictionary<string, HashSet<int>>();
        foreach (var neighbor in neighbors) { // 2
            var alreadyVisited = visited.Contains(neighbor);
            var isParent = neighbor == parent; // 4 == 4
            var isCycle = alreadyVisited && !isParent;
            if (isCycle)
            {
                elementsWithCycle.Add(neighbor);
            }
            if(!alreadyVisited)
            {
                currentVisitStack.Add(neighbor);
                outcome = lookForCycles(neighbor, node, adjacencyList, currentVisitStack, visited, elementsWithCycle);
                currentVisitStack.Remove(neighbor);
                visited = outcome["visited"];
                elementsWithCycle = outcome["cycles"];
            }
        }
        outcome["visited"] = visited;
        outcome["cycles"] = elementsWithCycle;
        return outcome;
    }
}