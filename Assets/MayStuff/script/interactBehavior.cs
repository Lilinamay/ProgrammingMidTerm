using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class interactBehavior : MonoBehaviour
{
    [SerializeField] TMP_Text interactText;
    //Renderer renderer1;
    //Renderer renderer2;
    //[SerializeField] Image aim;
    public bool triggered;
    // Start is called before the first frame update
    void Start()
    {
        interactText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            interactText.enabled = true;
            //aim.enabled = false;
            triggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            interactText.enabled = false;
            triggered = false;
        }
    }




}
