using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.UI;
public class iceCold : MonoBehaviour
{
    public Image bar;
    float spaPercent;
    public ThirdPersonController thirdPersonController;
    public float cutoff = 0.1f;
    float maxHeat = 100;
    public float myHeat = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float currentSpeed = thirdPersonController.getSpeed();
        if (currentSpeed < cutoff && myHeat > maxHeat)
        {
            myHeat -= Time.deltaTime*2f;
            //print("cold");
        }
        if (currentSpeed >= cutoff && myHeat<maxHeat)
        {
            myHeat += Time.deltaTime * 1.3f;
        }

        spaPercent = (myHeat / maxHeat);   //get sparkle percentage
        //Debug.Log(spaPercent);
        bar.fillAmount = spaPercent;        //fill in circle

    }
}
