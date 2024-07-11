using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Crosshair : MonoBehaviour
{
    [SerializeField] private GameObject inventory_Open_Close;
   
    public Texture2D crosshairTexture; // The texture for the crosshair
    public int size = 32; // The size of the crosshair

    void OnGUI()
    {

        // Get the center position of the screen
        float centerX = Screen.width / 2 - size / 2;
        float centerY = Screen.height / 2 - size / 2;


        if (inventory_Open_Close.activeSelf)
        {

        }
        else
        {
            // Draw the crosshair at the center of the screen
            GUI.DrawTexture(new Rect(centerX, centerY, size, size), crosshairTexture);
        }
           
      
          
        


    }
}


