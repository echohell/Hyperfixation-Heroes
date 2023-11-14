using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private bool isRepeating = false;
    [SerializeField] private float moveDuration = .1f;
    [SerializeField] private float gridSize = 1f;

    private bool isMoving;
    public bool isInCombat = false;

    public GridManager gridManager;

    private void Update()
    {
        if (!isInCombat)
        {
            if (!isMoving)
            {
                System.Func<KeyCode, bool> inputFunction;
                if (isRepeating)
                {
                    inputFunction = Input.GetKey;
                }
                else
                {
                    inputFunction = Input.GetKeyDown;
                }

                if (inputFunction(KeyCode.W)) { StartCoroutine(Move(Vector2.up)); }
                else if (inputFunction(KeyCode.S)) { StartCoroutine(Move(Vector2.down)); }
                else if (inputFunction(KeyCode.A)) { StartCoroutine(Move(Vector2.left)); }
                else if (inputFunction(KeyCode.D)) { StartCoroutine(Move(Vector2.right)); }
            }
        }
    }

    private IEnumerator Move(Vector2 direction)
    {
        isMoving = true;

        Vector2 startPos = transform.position;
        Vector2 endPos = startPos + (direction * gridSize);

        float elapsedTime = 0;
        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;
            float percent = (elapsedTime / moveDuration);
            transform.position = Vector2.Lerp(startPos, endPos, percent);
            yield return null;
        }

        transform.position = endPos;
        isMoving = false;
    }

    public void UpdateCombatState()
    {
        if (isInCombat == true)
        {
            gridManager.SetActive(false);
            isInCombat = false;
            Cursor.visible = true;
            gridManager.DumpGrid();
        }
        else if (isInCombat == false)
        {
            gridManager.SetActive(true);
            gridManager.GenerateGrid();
            isInCombat = true;
        }
    }
}
