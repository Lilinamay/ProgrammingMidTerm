using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class fluteControl : MonoBehaviour
{
    [SerializeField] AudioMixerSnapshot normal;
    [SerializeField] AudioMixerSnapshot reverb;
    [SerializeField] AudioMixerSnapshot sad;
    [SerializeField] AudioMixerSnapshot happy;
    //[SerializeField] TMP_Text mytext;

    public GameObject FlutePlayer;
    //public GameObject player;

    public float normalMaxVol = 1;
    public float normalAttackTime = 1;
    public float normalReleaseTime = 1;

    public float FmaxVolume = 1;
    public float FattackTime = 1;
    public float FreleaseTime = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            normal.TransitionTo(0);
            Debug.Log("normal");
            FmaxVolume = normalMaxVol;
            FattackTime = normalAttackTime;
            FreleaseTime = 0.5f;

        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            reverb.TransitionTo(0);
            Debug.Log("reverb");
            FmaxVolume = normalMaxVol;
            FattackTime = normalAttackTime;
            FreleaseTime = 4F;

        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            sad.TransitionTo(0);
            Debug.Log("sad");
            FmaxVolume = 0.8F;
            FattackTime = 2F;
            FreleaseTime = 2F;

        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            happy.TransitionTo(0);
            Debug.Log("happy");
            FmaxVolume = 1F;
            FattackTime = 0.4F;
            FreleaseTime = 0.5F;

        }

        if (Input.GetKey(KeyCode.Alpha6))
        {
            normal.TransitionTo(0);
            Debug.Log("tired");
            FmaxVolume = 0.6F;
            FattackTime = 4F;
            FreleaseTime = 1.5F;

        }


    }

}



