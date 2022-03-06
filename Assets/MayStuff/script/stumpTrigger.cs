using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stumpTrigger : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    
    
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
            gameManager.GetComponent<snowManager>().hitStump = true;
            gameManager.GetComponent<snowManager>().startTimer = true;
            gameManager.GetComponent<snowManager>().stump = gameObject;
        }
    }
}
