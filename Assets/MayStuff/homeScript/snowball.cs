using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowball : MonoBehaviour
{
    private Rigidbody snowbody;
    Cinemachine.CinemachineImpulseSource source;
    //[SerializeField] GameObject gameManager;
    //playerShoot playershoot;
    // Start is called before the first frame update
    private void Awake()
    {
        snowbody = GetComponent<Rigidbody>();
        source = GetComponent<Cinemachine.CinemachineImpulseSource>();
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            //gameManager.GetComponent<snowManager>().hitEnemy = true;
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
