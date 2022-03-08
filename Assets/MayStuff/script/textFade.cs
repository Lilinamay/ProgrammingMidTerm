using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class textFade : MonoBehaviour
{
    [SerializeField] TMP_Text title;

    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        //title.color = startColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (title.color.a > 0) {
            //float alpha = 1- Time.deltaTime * speed;
            title.color = new Color(title.color.r, title.color.g, title.color.b, title.color.a- (Time.deltaTime * speed));
         }
    }
}
