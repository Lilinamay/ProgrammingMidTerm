using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
// trigger snowman things for dialogue and change color
public class interactBehavior : MonoBehaviour
{
    public bool triggered;     //trigger dialogue
    public bool shot = false;
    [SerializeField] Renderer render1;  //the two parts of snowman
    [SerializeField] Renderer render2;
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
        if(other.tag == "Player")
        {
            triggered = true;       //trigger conversation 
        }

        if(other.tag == "snow")
        {
            shot = true;
            render1.material.color = other.GetComponent<Renderer>().material.color;     //change color to match snowball color
            render2.material.color = other.GetComponent<Renderer>().material.color;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggered = false;      //exit trigger
        }
    }




}
