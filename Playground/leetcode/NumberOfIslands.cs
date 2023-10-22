namespace PlaygroundTests.leetcode;

public static class NumberOfIslands
{
    public static int 
        calcNumberOfIslands(string[][] grid)
    {
        var maxWidth = grid[0].Length;
        var maxLength = grid.Length;
        var visitedSquares = Enumerable.Range(0, maxLength)
            .Select(c => Enumerable.Range(0, maxWidth)
            .Select(r => false)
            .ToArray())
            .ToArray();

        var rowIndex = 0;
        var columnIndex = 0;
        var mapIsland = buildMapIsland(maxLength, maxWidth, grid);
        var foundIslands = 0;
        while(columnIndex < maxLength) {
            var value = grid[columnIndex][rowIndex];
            var isIsland = value == "1";
            var visited = visitedSquares[columnIndex][rowIndex];
            var unvisitedIsland = !visited && isIsland;
            var endOfRow = rowIndex + 1 == maxWidth;
            if (unvisitedIsland)
            {
                foundIslands++;
                visitedSquares = mapIsland(columnIndex, rowIndex, visitedSquares);
            }
            if(endOfRow)
            {
                rowIndex = 0;
                columnIndex++;
            } else
            {
                rowIndex++;
            }
        }
        return foundIslands;
    }

    private static Func<int, int, bool[][], bool[][]> 
        buildMapIsland(int maxLength, int maxWidth, string[][] grid)
    {
        Func<int, int, bool[][], bool[][]> checkIfIsland = null; 
        checkIfIsland = (columnIndex, rowIndex, visited) =>
        {
            visited[columnIndex][rowIndex] = true;
            var eastIndex = rowIndex + 1;
            var eastOOBORWater = eastIndex == maxWidth || grid[columnIndex][eastIndex] == "0";
            var southIndex = columnIndex + 1;
            var southOOBORWater = southIndex == maxLength || grid[southIndex][rowIndex] == "0";
            if(!eastOOBORWater)
            {
                visited = checkIfIsland(columnIndex, eastIndex, visited);
            }
            if(!southOOBORWater)
            {
                visited = checkIfIsland(southIndex, rowIndex, visited);
            }
            return visited;
        };
        return checkIfIsland;
    }
}