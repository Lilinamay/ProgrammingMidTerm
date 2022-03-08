using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//snowball behavior attached to the prefab snowball
public class snowball : MonoBehaviour
{
    private Rigidbody snowbody;
    Renderer render;
    //
    public Color myColor;       //snowball color changable in other script


    private void Awake()
    {
        snowbody = GetComponent<Rigidbody>();
        render= GetComponent<Renderer>();
        render.material.color = myColor;
    }
    void Start()
    {
        float speed = 35f;
        snowbody.velocity = transform.forward * speed;      //movement
        render.material.color = myColor;

    }

    // Update is called once per frame
    void Update()
    {
        render.material.color = myColor;        //color same as my color changable in other script
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.tag != "ignore")     //if not player or things to ignore, hit anything, destroy itself
        {
            Audiomanager.Instance.PlaySound(Audiomanager.Instance.hit, Audiomanager.Instance.hitVolume);
            Destroy(gameObject);
           
        }
    }
}
