using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State[] items;
    public State[] results;
    bool firstquest = false;

    State getState(string name)
    {
        foreach(State s in results){
            if(s.name == name){
                return s;
            }
        }

        return null;
    }

    void FirstQuest()
    {



        if (items[0].state && items[1].state && items[2].state){
                State s = getState("Villager");
                s.GetComponent<DialogueTrigger>().ChangeDialogue();
                GameObject.FindGameObjectWithTag("Blocked").SetActive(false);
                firstquest = true;
            }
        
    }

    void Update()
    {
        if(!firstquest) FirstQuest();
    }

}
