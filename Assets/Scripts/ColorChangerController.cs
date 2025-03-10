using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangerController : MonoBehaviour
{
    // This is the SpriteRenderer component in charge of drawing this object's sprite
    public SpriteRenderer SR;

    // This is the color we want the object to turn
    public Color TargetColor = Color.red;

    // Any code inside of Update's {} brackets runs once per frame
    void Update()
    {
        // This if statement can be read "If I hit space, change the sprite's color"
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Check if SR is not null before changing color
            if (SR != null)
            {
                // Here we update the SpriteRenderer's color to be whatever TargetColor is set to be
                SR.color = TargetColor;
            }
            else
            {
                Debug.LogWarning("SpriteRenderer is not assigned!");
            }
        }
    }
}
