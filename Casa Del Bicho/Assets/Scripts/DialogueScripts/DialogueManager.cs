using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject gameobject;
    public GameObject CamController, crossHatch;
    private Queue<string> sentences;

    public Text nameText;
    public Text dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue d){
        gameobject.SetActive(true);
        CamController.GetComponent<FirstPersonLook>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        crossHatch.SetActive(false);

        //Time.timeScale = 0f;

        nameText.text = d.name;
        
        sentences.Clear();

        foreach(string sentence in d.sentences){
            sentences.Enqueue(sentence);
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

    void EndDialogue(){
        gameobject.SetActive(false);
        CamController.GetComponent<FirstPersonLook>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        crossHatch.SetActive(true);
        
        Time.timeScale = 1f;
    }
}
