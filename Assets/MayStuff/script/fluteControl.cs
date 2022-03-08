using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class fluteControl : MonoBehaviour
{
    //using audio mixer to change the sound the flute plays according to the color of the snowman musican
    [SerializeField] AudioMixerSnapshot normal;     //different snapshot that has different stats
    [SerializeField] AudioMixerSnapshot reverb;
    [SerializeField] AudioMixerSnapshot sad;
    [SerializeField] AudioMixerSnapshot happy;
    //[SerializeField] TMP_Text mytext;
    [SerializeField] Renderer snowmanR;     //to get snowman color from its renderer
    //public GameObject FlutePlayer;
    //public GameObject player;

     float normalMaxVol = 1;        //set normal to 1
     float normalAttackTime = 1;

    public float FmaxVolume = 1;    //valume accessable to flute manager
    public float FattackTime = 1;
    public float FreleaseTime = 1;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (snowmanR.material.color == Color.white)
        {
            normal.TransitionTo(0);
            Debug.Log("normal");
            FmaxVolume = normalMaxVol;
            FattackTime = normalAttackTime;
            FreleaseTime = 0.5f;

        }
        if (snowmanR.material.color == Color.yellow)
        {
            reverb.TransitionTo(0);
            Debug.Log("reverb");
            FmaxVolume = normalMaxVol;
            FattackTime = normalAttackTime;
            FreleaseTime = 4F;

        }
        if (snowmanR.material.color == Color.green)
        {
            sad.TransitionTo(0);
            Debug.Log("sad");
            FmaxVolume = 0.8F;
            FattackTime = 2F;
            FreleaseTime = 2F;

        }
        if (snowmanR.material.color == Color.red)
        {
            happy.TransitionTo(0);
            Debug.Log("happy");
            FmaxVolume = 1F;
            FattackTime = 0.4F;
            FreleaseTime = 0.5F;

        }

        if (snowmanR.material.color == Color.magenta)
        {
            normal.TransitionTo(0);
            Debug.Log("tired");
            FmaxVolume = 0.6F;
            FattackTime = 4F;
            FreleaseTime = 1.5F;

        }


    }

}



