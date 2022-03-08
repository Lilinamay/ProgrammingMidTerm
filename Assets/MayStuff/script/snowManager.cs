using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class snowManager : MonoBehaviour
{
    //if snowball hit a stump the same color as the snowball, dashable, manage the conditions 
    public bool hitStump = false;
    public bool startTimer = false;
    public bool go = false;
    public float Timer;
    public float maxTime = 5f;
    public GameObject stump;
    public GameObject player;
    public Image img1;      //UI
    public Image img2;
    
    // Start is called before the first frame update
    void Start()
    {
        img1.enabled = false;
        img2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (startTimer)
        {
            Timer = maxTime;
            startTimer = false;
        }
        else if (Timer <= 0)
        {
            hitStump = false;
            go = false;
        }

        if  (hitStump)
        {
            img1.enabled = true;    //show UI if hit a stump
            img2.enabled = true;
        }

    }
}
