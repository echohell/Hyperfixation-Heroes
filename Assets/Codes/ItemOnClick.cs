using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemOnClick : MonoBehaviour
{
    public Image thisImage;
    public Button btn;
    
    void Start()
    {
        thisImage = GetComponent<Image>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            try
            {
                if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>())
                {
                    btn = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
                    thisImage.sprite = btn.GetComponentInChildren<Transform>().Find("ItemImage").GetComponent<Image>().sprite;
                }
            }
            
            catch(NullReferenceException)
            {
               return;
            }
    }
}
