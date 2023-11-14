using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorActivity : MonoBehaviour
{
    public void TurnOn()
    {
        Cursor.visible = true;
    }

    public void TurnOff()
    { 
        Cursor.visible = false; 
    }
}
