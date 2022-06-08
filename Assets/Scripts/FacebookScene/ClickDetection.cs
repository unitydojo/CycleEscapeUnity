using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetection : MonoBehaviour
{
    [SerializeField] private FacebookSceneBrain _sceneBrain;
    [SerializeField] private float areaBoundsMinX;
    [SerializeField] private float areaBoundsMinY;
    [SerializeField] private float areaBoundsMaxX;
    [SerializeField] private float areaBoundsMaxY;

    [Header("Object Type")] 
    [SerializeField] private bool isEmail;
    [SerializeField] private bool isBandName;
    void Update() {  
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("X:" + Input.mousePosition.x + " y:" + Input.mousePosition.y);
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;
            if (mouseX >= areaBoundsMinX && mouseX <= areaBoundsMaxX && mouseY >= areaBoundsMinY &&
                mouseY <= areaBoundsMaxY)
            {
                _sceneBrain.ItemClicked(isEmail, isBandName);
            }
        }  
    }  
}
