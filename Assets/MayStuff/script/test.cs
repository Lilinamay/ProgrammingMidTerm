using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//get stats from playershoot to lerp player to the stump
public class test : MonoBehaviour
{
    public float x = 0;
    public float y = 0;
    public float z = 0;
    public Vector3 target;
    public Vector3 pos;
    public Vector3 space;
    private float spaceMultipler = 3;   //the space mutipler the player leave  between the stump
    public float curTime;
    public GameObject gameManager;
    
    float maxtime = 1F;
   
    void Update()
    {

        curTime = Mathf.Clamp(curTime + Time.deltaTime, 0.0f, maxtime);
        transform.position = Vector3.Lerp(pos, target-space*spaceMultipler, curTime/maxtime);  //lerp player to in front of stump  

        if (curTime >= maxtime)
        {
            //Debug.Log(gameManager.GetComponent<snowManager>().stump.transform.gameObject);
            enabled = false;
            curTime = 0;
        }
    }
}
