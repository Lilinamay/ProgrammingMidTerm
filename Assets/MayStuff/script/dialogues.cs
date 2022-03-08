using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class dialogues : MonoBehaviour
{
    public dialogueClass[] mydialogues;

    public dialogueClass dialogue;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] Image textboxSprite;
    private bool haveTriggered = false;
    private bool triggered = false;
    private bool first = false;
    public bool dialogueComplete = false;
    [SerializeField] GameObject player;
    [SerializeField] GameObject wall;

    [SerializeField] Queue<string> sentences;
    [SerializeField] Queue<string> names; //a list of strings
    public int myPlotNum = 0;
    [SerializeField] TMP_Text interactText;

    void Start()
    {
        names = new Queue<string>();
        sentences = new Queue<string>();
        textboxSprite.enabled = false; //disable without dialogue
        interactText.enabled = false;
    }

    private void triggerConversation()
    {
        if (haveTriggered == false && !dialogueComplete && GetComponent<interactBehavior>().triggered )
        {
            Debug.Log("trigger conversation");
            triggered = true;
            haveTriggered = true;
            sentences.Clear();
            names.Clear();

            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }

            textboxSprite.enabled = true;
            interactText.enabled = true;
            foreach (string name in dialogue.names)
            {
                names.Enqueue(name);
            }

        }
    }


    void EndDialogue()
    {
        if (myPlotNum == 2 && triggered && wall != null)
        {
            wall.SetActive(false);
        }
        //Debug.Log("End conversation ");// + names.Peek());
        textboxSprite.enabled = false;
        interactText.enabled = false;
        nameText.text = "";
        dialogueText.text = "";
        names.Clear();
        sentences.Clear();
        haveTriggered = false;
        GetComponent<interactBehavior>().triggered = false;
        //dialogue2Complete = true;
        first = false;
        triggered = false;


    }


    void Update()
    {
        //if (mydialogues.Length <= plotNumber.Globals.maxPlotNum)
        //{
        //    dialogue = mydialogues[plotNumber.Globals.plotNum];
        //}
        dialogue = mydialogues[myPlotNum];      //my current dialogue
        if (!GetComponent<interactBehavior>().triggered && triggered)      //if leave conversation
        {
            StopAllCoroutines();
            EndDialogue();
        }
        triggerConversation();
        if (triggered && GetComponent<interactBehavior>().triggered)
        {
            if (first == false)
            {
                string name = names.Dequeue();
                string sentence = sentences.Dequeue();
               //go down list and put into a sprite/string
               
                textboxSprite.enabled = true;   //show image
                interactText.enabled = true;
                nameText.text = name;
                dialogueText.text = sentence;
                StopAllCoroutines();
                StartCoroutine(TypeSentence(sentence));
                Debug.Log(name);
                Debug.Log(sentence);
                first = true;
            }
            else if (Input.GetKeyDown(KeyCode.V))
            {

                if (sentences.Count == 0)   //if queue empty, end dialogue
                {
                    StopAllCoroutines();
                    EndDialogue();
                    return;
                }

                string name2 = names.Dequeue();
                string sentence2 = sentences.Dequeue();
                dialogueText.text = sentence2;
                StopAllCoroutines();
                StartCoroutine(TypeSentence(sentence2));

                textboxSprite.enabled = true;   //show image
                interactText.enabled = true;
                nameText.text = name2;
                Debug.Log(sentence2);
            }
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            Audiomanager.Instance.PlaySound(Audiomanager.Instance.text, Audiomanager.Instance.textVolume);
            yield return null;
        }
    }
}

