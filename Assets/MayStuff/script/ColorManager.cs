using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//manage player current color settings
public enum snowColor { purple, red, green, yellow, white};     //all the color player can use
public class ColorManager : MonoBehaviour
{
    
    public snowColor playerColor;   
    [SerializeField] Image ColorImage;      //show player my color
    public Color pColor;

    void Start()
    {
        playerColor = snowColor.white;
    }
    void Update()
    {
        switch (playerColor)            //set color to its states
        {
            case snowColor.white:
                pColor = Color.white;
                break;
            case snowColor.yellow:
                pColor = Color.yellow;
                break;
            case snowColor.green:
                pColor = Color.green;
                break;
            case snowColor.purple:
                pColor = Color.magenta;
                break;
            case snowColor.red:
                pColor = Color.red;
                break;
        }

        ColorImage.color = pColor;



    }



}
