using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using TMPro;

using UnityEngine.InputSystem;

public class playerShoot : MonoBehaviour
{
    [SerializeField] LayerMask aimColliderMask = new LayerMask();

    //[SerializeField] Transform pfSnow;
    [SerializeField] GameObject mySnow;
    //public GameObject[] snowArray = new GameObject[10];
    //int x = 0;
    [SerializeField] Transform spawnSnowPos;
    [SerializeField] GameObject gameManager;
    [SerializeField] TMP_Text snowText;
    
    //public GameObject testObject;
    snowManager snowManager;
    ColorManager colorManager;
    //Vector3 originalPos;

    public int snowCount = 0;


    //[SerializeField] Transform DebugTransform;
    private StarterAssetsInputs starterAssetsInputs;
    // Start is called before the first frame update
    void Start()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        snowManager = gameManager.GetComponent<snowManager>();
        colorManager = gameManager.GetComponent<ColorManager>();

        //for (int i = 0; i < 10; i++)
        //{
        //    snowArray[i] = Instantiate(mySnow, transform.position, Quaternion.identity);
        //    snowArray[i].SetActive(false);

        //}
    }

    // Update is called once per frame
    void Update()
    {

        //if (Time.timeSinceLevelLoad >= 8f)
        //{
        this.gameObject.GetComponent<ThirdPersonController>().LockCameraPosition = false;
        //}

        snowText.text = "Snowball: " + snowCount;
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 myCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(myCenter);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderMask))
        {
            //DebugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }
        
        //if (x >= 10)
        //{
        //    x = 0;
        //}
        if (snowCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Audiomanager.Instance.PlaySound(Audiomanager.Instance.shoot, Audiomanager.Instance.shootVolume);
                Vector3 aimDir = (mouseWorldPosition - spawnSnowPos.position).normalized;
                //Instantiate(pfSnow, spawnSnowPos.position, Quaternion.LookRotation(aimDir, Vector3.forward));
                GameObject mysnow = Instantiate(mySnow, spawnSnowPos.position, Quaternion.LookRotation(aimDir, Vector3.forward));
                //if (x < 10)
                //{
                //    snowArray[x].SetActive(true);
                //    snowArray[x].GetComponent<snowball>().myColor = colorManager.pColor;
                //    snowArray[x].transform.position = spawnSnowPos.position;
                //    snowArray[x].transform.rotation = Quaternion.LookRotation(aimDir, Vector3.forward);
                //    Debug.Log(snowArray[x].transform.rotation);
                //    x++;
                //}
                
                mysnow.GetComponent<snowball>().myColor = colorManager.pColor;
                snowCount--;
                
            }
        }

        if (starterAssetsInputs.dash)
        {
            moveToEnemy();
            starterAssetsInputs.dash = false;
        }


    }

    void moveToEnemy()
    {
        if (snowManager.hitStump)
        {

            GetComponent<test>().space = (snowManager.stump.transform.position - transform.position).normalized;
            //normalize the space between the player and stump,use it to land before the stump
            GetComponent<test>().target = snowManager.stump.transform.position;
            GetComponent<test>().pos = transform.position;
            GetComponent<test>().enabled = true;
            Debug.Log(snowManager.stump.transform.position);
            snowManager.img1.enabled = false;
            snowManager.img2.enabled = false;
            snowManager.hitStump = false;
            if (!snowManager.go)
            {
                //originalPos = transform.position;
                snowManager.go = true;
            }

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "chuck")
        {
            snowCount += 3;
            Destroy(other.gameObject);
        }
    }
}

