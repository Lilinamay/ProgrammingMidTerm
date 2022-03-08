using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//when player travel through the arch, change player snow color to the arch color
public class archTrigger : MonoBehaviour
{

    [SerializeField] snowColor myColor;
    [SerializeField] ColorManager colorManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            colorManager.playerColor = myColor;     //chanhe player snow color and play sound
            Audiomanager.Instance.PlaySound(Audiomanager.Instance.arch, Audiomanager.Instance.archVolume);
        }
    }
}
