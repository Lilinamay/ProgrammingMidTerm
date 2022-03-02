using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using TMPro;

using UnityEngine.InputSystem;

public class playerShoot : MonoBehaviour
{
    [SerializeField] LayerMask aimColliderMask = new LayerMask();

    [SerializeField] Transform pfSnow;
    [SerializeField] Transform spawnSnowPos;
    [SerializeField] GameObject gameManager;
    [SerializeField] TMP_Text snowText;
    public GameObject testObject;
    snowManager snowManager;
    Vector3 originalPos;
    public float maxTime =5.0f; // Time taken to lerp

    public float curTime = 100f;

    public int snowCount = 0;


    //[SerializeField] Transform DebugTransform;
    private StarterAssetsInputs starterAssetsInputs;
    // Start is called before the first frame update
    void Start()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        snowManager = gameManager.GetComponent<snowManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.timeSinceLevelLoad >= 8f)
        {
            this.gameObject.GetComponent<ThirdPersonController>().LockCameraPosition = false;
        }

        snowText.text = "Snowball: " + snowCount;
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 myCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(myCenter);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderMask))
        {
            //DebugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }

        if (snowCount > 0)
        {
            if (starterAssetsInputs.shoot)
            {
                if (snowCount > 0)
                {
                    Vector3 aimDir = (mouseWorldPosition - spawnSnowPos.position).normalized;
                    Instantiate(pfSnow, spawnSnowPos.position, Quaternion.LookRotation(aimDir, Vector3.forward));
                    snowCount--;
                    starterAssetsInputs.shoot = false;
                }
            }
        }

        if (starterAssetsInputs.dash)
        {
            moveToEnemy();
            starterAssetsInputs.dash = false;
        }

        moveFunction();

    }

    void moveToEnemy()
    {
        if (snowManager.hitEnemy)
        {

            GetComponent<test>().space = (snowManager.enemy.transform.position - transform.position).normalized;

            GetComponent<test>().target = snowManager.enemy.transform.position;
            GetComponent<test>().pos = transform.position;
            GetComponent<test>().enabled = true;
            Debug.Log(snowManager.enemy.transform.position);

            snowManager.img1.enabled = false;
            snowManager.img2.enabled = false;
            snowManager.hitEnemy = false;
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            if (!snowManager.go)
                {
                    originalPos = transform.position;
                    curTime = 0;
                    snowManager.go = true;
                }

            //}
        }
    }

    void moveFunction()
    {
        if (snowManager.enemy != null && curTime < maxTime) {
            //Debug.Log("dash");
            
            //testObject.transform.position = Vector3.Lerp(originalPos, snowManager.enemy.transform.position-space, curTime / maxTime);
            //testObject.transform.position = Vector3.Lerp(snowManager.enemy.transform.position , originalPos + space, curTime / maxTime);
            //testObject.transform.position = Vector3.Lerp(originalPos, transform.position, curTime / maxTime);
            //Debug.Log(snowManager.enemy.transform.position);

        }
        if (snowManager.enemy != null && curTime >= maxTime)
        {
            snowManager.go = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "chuck")
        {
            snowCount += 3;
            Destroy(other.gameObject);
        }
    }
}
