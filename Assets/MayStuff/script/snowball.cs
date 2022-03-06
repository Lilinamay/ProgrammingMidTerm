using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class snowball : MonoBehaviour
{
    private Rigidbody snowbody;
    Cinemachine.CinemachineImpulseSource source;
    Renderer render;
    [SerializeField] Image ColorImage;

    //[SerializeField] GameObject gameManager;
    //playerShoot playershoot;
    // Start is called before the first frame update
    private void Awake()
    {
        snowbody = GetComponent<Rigidbody>();
        render= GetComponent<Renderer>();
        //source = GetComponent<Cinemachine.CinemachineImpulseSource>();
        //playershoot = ;
    }
    void Start()
    {
        float speed = 20f;
        snowbody.velocity = transform.forward * speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        //snowbody.AddForce(transform.forward * (100 * Random.Range(1.3f, 1.7f)), ForceMode.Impulse);
        source.GenerateImpulse(Camera.main.transform.forward);
        render.material.color = ColorImage.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {

            Destroy(gameObject);
        }
    }
}
