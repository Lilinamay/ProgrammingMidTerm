using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class interactBehavior : MonoBehaviour
{
    //[SerializeField] TMP_Text interactText;
    //[SerializeField] Image aim;
    public bool triggered;
    [SerializeField] Renderer render1;
    [SerializeField] Renderer render2;
    // Start is called before the first frame update
    void Start()
    {
        //interactText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //interactText.enabled = true;
            //aim.enabled = false;
            triggered = true;
        }

        if(other.tag == "snow")
        {
            render1.material.color = other.GetComponent<Renderer>().material.color;
            render2.material.color = other.GetComponent<Renderer>().material.color;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //interactText.enabled = false;
            triggered = false;
        }
    }




}
