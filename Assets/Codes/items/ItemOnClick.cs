using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemOnClick : MonoBehaviour
{
    public Image thisImage;                         // used to add image to the left image box for description.
    public Button btn;                              // used to manipulate the button that gets called during an event firing.
    
    void Start()
    {
        thisImage = GetComponent<Image>();          // set our blank image as default to be changed later.
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))            // left click
            try                                     // try and catch for null references.
            {
                if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>())                           // if a button event fires.
                {
                    btn = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();                     // find the button that fired

                    thisImage.sprite = btn.GetComponentInChildren<Transform>().Find("ItemImage").GetComponent<Image>().sprite;  // set the button image to child image.
                }
            }
            
            catch(NullReferenceException)           // will now ignore null references and return nothing.
            {
               return;
            }
    }
}
