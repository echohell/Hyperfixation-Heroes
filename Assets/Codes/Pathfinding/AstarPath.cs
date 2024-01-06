using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstarPath : MonoBehaviour
{
    private static Vector2 gridSize;

    private class Node
    {
        public Vector2Int position;
        public Node parent;
        public int gCost;
        public int hCost;
        public int fCost => gCost + hCost;
        public bool isObstacle;

        public Node(Vector2Int position, Node parent, int gCost, int hCost, bool isObstacle)
        {
            this.position = position;
            this.parent = parent;
            this.gCost = gCost;
            this.hCost = hCost;
            this.isObstacle = isObstacle;
        }
    }

    public static List<Vector2> FindThePath(Vector2 start, Vector2 end, Vector2 gridcellSize, System.Func<Vector2, bool> isObstacle)
    {
        gridSize = gridcellSize;

        Vector2Int startGridPosition = GridUtility.WorldtoGridSnap(start);
        Vector2Int targetGridPosition = GridUtility.WorldtoGridSnap(end);

        List<Node> openList = new List<Node>();
        HashSet<Vector2Int> closed = new HashSet<Vector2Int>();

        Node startNode = new Node(startGridPosition, null, 0, CalculateHCost(startGridPosition, targetGridPosition), false);
        openList.Add(startNode);

        while (openList.Count > 0)
        {
            Node currentNode = GetLowestFCost(openList);

            openList.Remove(currentNode);
            closed.Add(currentNode.position);

            if (currentNode.position == targetGridPosition)
            {
                return GeneratePath(currentNode);
            }

            foreach (Vector2Int adjacentPositions in GetAdjacentPositions(currentNode.position))
            {
                if (closed.Contains(adjacentPositions) || isObstacle(GridUtility.GridSnaptoWorld(adjacentPositions)))
                {
                    continue;
                }

                int gCost = currentNode.gCost + 1;
                int hCost = CalculateHCost(adjacentPositions, targetGridPosition);

                Node adjacentNode = new Node(adjacentPositions, currentNode, gCost, hCost, false);

                int index = openList.FindIndex(node => node.position == adjacentPositions);
                if (index != -1)
                {
                    if (gCost < openList[index].gCost)
                    {
                        openList[index].parent = currentNode;
                        openList[index].gCost = gCost;
                    }
                }

                else
                {
                    openList.Add(adjacentNode);
                }
            }
        }

        return null;
    }

    private static Node GetLowestFCost(List <Node> nodes)
    {
        Node lowestCostNode = nodes[0];

        for (int i = 1; i < nodes.Count; i++)
        {
            if (nodes[i].fCost < lowestCostNode.fCost || (nodes[i].fCost == lowestCostNode.fCost && nodes[i].hCost < lowestCostNode.hCost))
            {
                lowestCostNode = nodes[i];
            }
        }
        
        return lowestCostNode;
    }

    private static int CalculateHCost(Vector2Int current, Vector2Int target)
    {
        return Mathf.Abs(current.x - target.x) + Mathf.Abs(current.y - target.y);
    }

    private static List<Vector2> GeneratePath(Node endNode)
    {
        List<Vector2> path = new List<Vector2>();
        Node currentNode = endNode;

        while (currentNode != null)
        {
            path.Add(GridUtility.GridSnaptoWorld(currentNode.position));
            currentNode = currentNode.parent;
        }

        path.Reverse();
        return path;
    }

    private static List<Vector2Int> GetAdjacentPositions(Vector2Int position)
    {
        return new List<Vector2Int>
        {
            position + Vector2Int.up,
            position + Vector2Int.down,
            position + Vector2Int.left,
            position + Vector2Int.right
        };
    }
}
