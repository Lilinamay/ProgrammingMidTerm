using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//snowball with stump  trigger, if same color, activate dash and UI
public class stumpTrigger : MonoBehaviour
{
    [SerializeField] snowManager snowManager;
    [SerializeField] snowColor myColor;
    [SerializeField] ColorManager colorManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "snow")
        {
            if (colorManager.playerColor == myColor) //If same color
            {
                //Debug.Log("is my color!");
                snowManager.hitStump = true;        //set conditions
                snowManager.startTimer = true;
                snowManager.stump = gameObject;
            }
        }
    }
}
