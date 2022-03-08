using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class textFade : MonoBehaviour
{
    [SerializeField] TMP_Text title;

    [SerializeField] float speed;

    void Update()
    {
        if (title.color.a > 0) {
            //float alpha = 1- Time.deltaTime * speed;
            title.color = new Color(title.color.r, title.color.g, title.color.b, title.color.a- (Time.deltaTime * speed));
         }
    }//fade title color at the start of the game
}
