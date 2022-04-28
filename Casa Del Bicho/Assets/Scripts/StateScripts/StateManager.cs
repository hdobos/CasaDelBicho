using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public ObjectState[] items;
    public ObjectState[] results;
    bool firstQuest, secondQuest = false;

    [System.Serializable]
    public class HasItem
    {
        bool hasItem;
    }

    public ObjectState getResultState(string name)
    {
        foreach(ObjectState s in results){
            if(s.name == name){
                return s;
            }
        }

        return null;
    }

    void FirstQuest()
    {
        foreach(ObjectState state in items){
            if(state.name == "FirstQuest" && !state.state){
                break;
            }
            else{
                ObjectState s = getResultState("Villager");
                s.GetComponent<DialogueTrigger>().ChangeDialogue();
                GameObject.FindGameObjectWithTag("BlockedPath").SetActive(false);
                firstQuest = true;
            }
        }
    }

    void SecondQuest()
    {

    }

    void Update()
    {
        if(!firstQuest) FirstQuest();
        else{
            
        }
    }

}
