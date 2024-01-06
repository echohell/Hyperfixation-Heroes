using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementDirections
{
    Up, Down, Left, Right
}

public class CombatMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Vector2 gridSize = new Vector2(1f, 1f);
    [SerializeField] private obstacleTiles obstacleTile;
    [SerializeField] private TileSelect tileSelect;

    private Vector2 targetPos;
    private bool isMoving = false;
    private MovementDirections currentDirection = MovementDirections.Down;

    private void Update()
    {
        HandleMovementInput();
    }

    private void HandleMovementInput()
    {
        if (!isMoving && Input.GetMouseButtonDown(0))
        {
            targetPos = tileSelect.GetHighlightTilePos();
            Vector2Int clickedTile = GridUtility.WorldtoGridSnap(targetPos);

            if (!obstacleTile.IsTileAnObstacle(clickedTile))
            {
                if (targetPos != Vector2.zero)
                {
                    FindPathToTargetPos();
                }
            }
        }

        if (isMoving)
        {
            MoveTowardsTarget();
        }
    }

    private void FindPathToTargetPos()
    {
        Vector2 startPosition = GridUtility.GridSnaptoWorld(GridUtility.WorldtoGridSnap(transform.position));
        List<Vector2> path = AstarPath.FindThePath(startPosition, targetPos, gridSize, obstacleTile.IsTileAnObstacle);

        if (path != null && path.Count > 0)
        {
            StartCoroutine(MoveAlongPath(path));
        }
    }

    private IEnumerator MoveAlongPath(List<Vector2> path)
    {
        isMoving = true;
        int currentWaypointIndex = 0;

        while (currentWaypointIndex < path.Count)
        {
            targetPos = path[currentWaypointIndex] + gridSize / 2;

            while ((Vector2)transform.position != targetPos)
            {
                float step = moveSpeed * Time.fixedDeltaTime;
                transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

                yield return new WaitForFixedUpdate();
            }

            currentWaypointIndex++;
        }

        isMoving = false;
    }

    private void MoveTowardsTarget()
    {
        Vector2 direction = (targetPos - (Vector2)transform.position).normalized;

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0) currentDirection = MovementDirections.Right;
            else currentDirection = MovementDirections.Left;
        }
        else
        {
            if (direction.y > 0) currentDirection = MovementDirections.Up;
            else currentDirection = MovementDirections.Down;
        }
    }
}
