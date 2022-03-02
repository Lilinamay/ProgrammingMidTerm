using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public GameObject pBox;
    public bool trigger = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("running");
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = new Vector3(this.transform.position.x - .1f, this.transform.position.y, this.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        if(other.gameObject== pBox)
        {
            trigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == pBox)
        {
            trigger = false;
        }
    }
}
