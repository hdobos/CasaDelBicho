using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject gameobject;
    public GameObject CamController, customCursorIcon;
    private Queue<string> sentences;

    public Text nameText;
    public Text dialogueText;

    private GameObject npc;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void SetNPC(GameObject charachter){
        npc = charachter;
    }

    public void StartDialogue(Dialogue d){
        //freeze the state of the npc so they can't be re-triggered while interacing
        npc.GetComponent<Interactable>().setInteractingState(true);

        //enable the dialogue object
        gameobject.SetActive(true);
        CamController.GetComponent<FirstPersonLook>().setPositionLocked(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        customCursorIcon.SetActive(false);

        nameText.text = d.name;
        
        sentences.Clear();

        foreach(Sentence s in d.sentences){
            if(s.active){
                sentences.Enqueue(s.sentence);
            }
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void ActivateDialogue(Dialogue d)
    {
        foreach(Sentence s in d.sentences)
        {
            s.active = !s.active;
        }
    }

    void EndDialogue(){
        npc.GetComponent<Interactable>().setInteractingState(false);
        gameobject.SetActive(false);
        CamController.GetComponent<FirstPersonLook>().setPositionLocked(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        customCursorIcon.SetActive(true);
        
        Time.timeScale = 1f;
    }
}
