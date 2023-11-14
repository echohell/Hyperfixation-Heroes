using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject highlight;

    public void Initialize(bool isOffset)
    {
        spriteRenderer.color = isOffset ? offsetColor : baseColor;
    }

    public void OnMouseEnter()
    {
        highlight.SetActive(true);
        Cursor.visible = false;
    }

    public void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}
