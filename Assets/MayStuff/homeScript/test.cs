using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class test : MonoBehaviour
{
    public float x = 0;
    public float y = 0;
    public float z = 0;
    public Vector3 target;
    public Vector3 pos;
    public Vector3 space;
    public float curTime;
    public GameObject gameManager;
    [SerializeField] TMP_Text KillText;
    int kill = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KillText.text = "killed " + kill + " / 10 dummies";
        curTime = Mathf.Clamp(curTime + Time.deltaTime, 0.0f, 0.3f);
        transform.position = Vector3.Lerp(pos, target-space, curTime/0.3f);

        if (curTime >= 0.3f)
        {
            Debug.Log(gameManager.GetComponent<snowManager>().enemy.transform.parent.gameObject);
            if (gameManager.GetComponent<snowManager>().enemy.transform.parent.gameObject != null)
            {
                kill++;
                KillText.text = "killed " + kill + " / 10 dummies";
                Destroy(gameManager.GetComponent<snowManager>().enemy.transform.parent.gameObject, 0.1f);
            }
            enabled = false;
            
            curTime = 0;
        }
    }
}
