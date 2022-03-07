using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class test : MonoBehaviour
{
    public float x = 0;
    public float y = 0;
    public float z = 0;
    public Vector3 target;
    public Vector3 pos;
    public Vector3 space;
    private float spaceMultipler = 3;
    public float curTime;
    public GameObject gameManager;
    
    float maxtime = 2;
    //public GameObject testobj;
    void Start()
    {
        
    }
    //

    // Update is called once per frame
    void Update()
    {
        //KillText.text = "killed " + kill + " / 10 dummies";
        curTime = Mathf.Clamp(curTime + Time.deltaTime, 0.0f, maxtime);
        transform.position = Vector3.Lerp(pos, target-space*spaceMultipler, curTime/maxtime);
        //Instantiate(testobj, transform.position, Quaternion.identity);
        if (curTime >= maxtime)
        {
            //Debug.Log(gameManager.GetComponent<snowManager>().stump.transform.gameObject);
            if (gameManager.GetComponent<snowManager>().stump.transform.gameObject != null)
            {
                //kill++;
                //KillText.text = "killed " + kill + " / 10 dummies";
                //Destroy(gameManager.GetComponent<snowManager>().stump.transform.gameObject, 0.1f);
            }
            enabled = false;
            
            curTime = 0;
        }
    }
}
