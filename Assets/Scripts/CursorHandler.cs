//
//Program: CursorHandler.cs
//Author: Edwin
//Date created: 2 March 2017
//Date modified: 3 March 2017
//Description: Disables cursor and stops it from getting focus
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorHandler : MonoBehaviour
{

    private GameObject lastSelectObj;

    // Use this for initialization
    void Start ()
    {
        lastSelectObj = new GameObject ();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	// Update is called once per frame
	void Update ()
    {
        ReselectObject ();
	}

    private void ReselectObject ()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject (lastSelectObj);
        }
        else
        {
            lastSelectObj = EventSystem.current.currentSelectedGameObject;
        }
    }
}
