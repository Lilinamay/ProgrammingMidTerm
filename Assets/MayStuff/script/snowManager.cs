using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class snowManager : MonoBehaviour
{
    public bool hitStump = false;
    public bool startTimer = false;
    public bool go = false;
    public float Timer;
    public float maxTime = 5f;
    public GameObject stump;
    public GameObject player;
    public Image img1;
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
        //if (Timer > 0)
        //{
        //    hitEnemy = true;
        //    Timer -= Time.deltaTime;
        //}
        else if (Timer <= 0)
        {
            hitStump = false;
            go = false;
        }

        if  (hitStump)
        {
            img1.enabled = true;
            img2.enabled = true;
        }
        if (go)
        {
            //img1.enabled = false;
            //img2.enabled = false;
        }
    }
}
