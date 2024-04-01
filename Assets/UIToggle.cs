using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIToggle : MonoBehaviour
{
    public GameObject uiElement;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            uiElement.SetActive(!uiElement.activeSelf);
        }
    }
}
