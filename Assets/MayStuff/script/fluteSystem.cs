using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//individual keys to play a note
public class fluteSystem : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    fluteControl fluteControl;
    float maxVolume;
    float attackTime;
    float releaseTime;
    
    [SerializeField] KeyCode keyToPlay;
    [SerializeField] fluteTrigger fluteTrigger;

    public enum ASRState { inactive = 0, attack, sustain, release }     //the four stages of playing sound
                                                                        //inactive: not playing,  attack: rising volume, sustain: maintain the highing volume, release: after release key, gradually lower volume to zero, similar to how a flute plays
    public ASRState asrState;



    // Start is called before the first frame update
    void Start()
    {
        asrState = ASRState.inactive;           //default to not play
        audioSource.volume = 0f;
        fluteControl = GetComponent<fluteControl>();

    }

    // Update is called once per frame
    void Update()
    {

        maxVolume = fluteControl.FmaxVolume;        //get the values from flute control
        attackTime = fluteControl.FmaxVolume;
        releaseTime = fluteControl.FreleaseTime;
        if (fluteTrigger.playflute)         //if in range to play
        {
            //if we press down keys for the length of attack time, we reach max volume
            if (Input.GetKey(keyToPlay))
            {
                //Debug.Log ("")
                switch (asrState)
                {
                    case ASRState.inactive:
                        asrState = ASRState.attack;     //switch to attack
                        break;
                    case ASRState.attack:                           //in attack
                        if (audioSource.volume < maxVolume)
                        {
                            audioSource.volume += (Time.deltaTime / attackTime) * maxVolume;        //rise volume to max
                        }

                        else if (audioSource.volume >= maxVolume)       //if max volume, go to sustain stage
                        {
                            audioSource.volume = maxVolume;
                            asrState = ASRState.sustain;
                        }
                        break;
                    case ASRState.sustain:
                        break;
                    case ASRState.release:
                        asrState = ASRState.attack;
                        break;
                }
            }

            else
            {
                switch (asrState)
                {
                    case ASRState.inactive:
                        break;
                    case ASRState.attack:
                        asrState = ASRState.release;
                        break;
                    case ASRState.sustain:
                        asrState = ASRState.release;
                        break;
                    case ASRState.release:                  //otherwise in release state, lower volume until zero
                        if (audioSource.volume > 0f)
                        {
                            audioSource.volume -= (Time.deltaTime / releaseTime) * maxVolume;
                        }
                        else
                        {
                            audioSource.volume = 0f;        //when 0 volume, become inactive
                            asrState = ASRState.inactive;
                        }
                        break;
                }
            }
        }

    }
}

