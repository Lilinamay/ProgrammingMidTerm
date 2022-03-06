using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum snowColor { purple, red, green, yellow, white};
public class ColorManager : MonoBehaviour
{
    // This is private, so that we can show an error if its not set up yet
    public snowColor playerColor;
    [SerializeField] Image ColorImage;
    public Color pColor;

    //public static GameManager Instance


    //{
    //    get
    //    {
    //        // If the static instance isn't set yet, throw an error
    //        if (staticInstance is null)
    //        {
    //            Debug.LogError("Game Manager is NULL");
    //        }

    //        return staticInstance;
    //    }
    //}

    //private void Awake()
    //{
    //    // Set the static instance to this instance
    //    staticInstance = this;
    //}
    void Start()
    {
        playerColor = snowColor.white;
    }
    void Update()
    {
        switch (playerColor)
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
