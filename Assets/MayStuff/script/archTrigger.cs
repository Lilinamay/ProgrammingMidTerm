using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class archTrigger : MonoBehaviour
{

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

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            colorManager.playerColor = myColor;
        }
    }
}
