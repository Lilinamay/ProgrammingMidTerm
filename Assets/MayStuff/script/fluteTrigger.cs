using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fluteTrigger : MonoBehaviour
{
    public bool playflute = false;
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
        if (other.tag == "Player")
        {
            playflute = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playflute = false;
        }
    }
}
