using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class snowmanBehavior : MonoBehaviour
{
    [SerializeField] TMP_Text interactText;
    //[SerializeField] Image aim;
    
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
        }
    }


}
