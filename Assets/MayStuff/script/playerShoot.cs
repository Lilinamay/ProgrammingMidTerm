using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using TMPro;
using UnityEngine.InputSystem;
//handle player shoot snowball and dash input, left mouse button to shoot, right mouse button to dash if hit stump
public class playerShoot : MonoBehaviour
{
    [SerializeField] LayerMask aimColliderMask = new LayerMask();   //layermask for what's beening raycasted
    [SerializeField] GameObject mySnow;     //snowball
    [SerializeField] Transform spawnSnowPos;
    [SerializeField] GameObject gameManager;
    [SerializeField] TMP_Text snowText;     //show how many snowball
    snowManager snowManager;
    ColorManager colorManager;
    public int snowCount = 0; //Count snowball
    private StarterAssetsInputs starterAssetsInputs;    //access the input system from starter assets
    // Start is called before the first frame update
    void Start()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        snowManager = gameManager.GetComponent<snowManager>();
        colorManager = gameManager.GetComponent<ColorManager>();
    }

    // Update is called once per frame
    void Update()
    {

        //if (Time.timeSinceLevelLoad >= 8f)
        //{
        this.gameObject.GetComponent<ThirdPersonController>().LockCameraPosition = false;
        //}

        snowText.text = "Snowball: " + snowCount;       //show snowcount
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 myCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);  //center of screen
        Ray ray = Camera.main.ScreenPointToRay(myCenter);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderMask))
        {
            mouseWorldPosition = raycastHit.point;      //mouse position to raycast point
        }

        if (snowCount > 0)      //If has snowball, shoot with left mouse key
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Audiomanager.Instance.PlaySound(Audiomanager.Instance.shoot, Audiomanager.Instance.shootVolume);    //play shoot audio
                Vector3 aimDir = (mouseWorldPosition - spawnSnowPos.position).normalized; //direction of the snowball
                GameObject mysnow = Instantiate(mySnow, spawnSnowPos.position, Quaternion.LookRotation(aimDir, Vector3.forward));  //create snowball          
                mysnow.GetComponent<snowball>().myColor = colorManager.pColor;  //snowball color same has the color player has right now 
                snowCount--;
                
            }
        }

        if (starterAssetsInputs.dash) //if input dash(right button)
        {
            moveToEnemy();
            starterAssetsInputs.dash = false;
        }
        if (starterAssetsInputs.jump)
        {
            Audiomanager.Instance.PlaySound(Audiomanager.Instance.jump, Audiomanager.Instance.jumpVolume);
            starterAssetsInputs.jump = false;
        }


    }

    void moveToEnemy()
    {
        if (snowManager.hitStump)
        {
            //if dash and hit stump, play sound, calculate stats, unshow UI
            Audiomanager.Instance.PlaySound(Audiomanager.Instance.dash, Audiomanager.Instance.dashVolume);
            GetComponent<test>().space = (snowManager.stump.transform.position - transform.position).normalized;        //space to land before the stump
            //normalize the space between the player and stump,use it to land before the stump
            GetComponent<test>().target = snowManager.stump.transform.position;     //stump position
            GetComponent<test>().pos = transform.position;
            GetComponent<test>().enabled = true;
            //Debug.Log(snowManager.stump.transform.position);
            snowManager.img1.enabled = false;       
            snowManager.img2.enabled = false;       //unshow UI
            snowManager.hitStump = false;
            if (!snowManager.go)
            {
                //originalPos = transform.position;
                snowManager.go = true; 
            }

        }
    }


    private void OnTriggerEnter(Collider other)     //collect snowball from snow chuck
    {
        if (other.tag == "chuck")
        {
            snowCount += 3;         //get three snowball
            Audiomanager.Instance.PlaySound(Audiomanager.Instance.getsnow, Audiomanager.Instance.getsnowVolume);
            Destroy(other.gameObject);
        }
    }
}

