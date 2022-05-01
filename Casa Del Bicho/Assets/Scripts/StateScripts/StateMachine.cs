using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State[] items; //list of items that player needs to have
    public State villager;
    bool itemState = false;


    bool CheckItemState()
    {
         foreach(State s in items){
            if(!s.state){
                return false;
            }
        }
        return true;
    }

    void RemoveItems()
    {
        foreach(State s in items){
            if(s.state){
                FindObjectOfType<CraftItem>().RemoveItem(s);
            }
        }
    }

    public void Metalon()
    {
        foreach(State s in items){
            if(!s.state){
                break;
            }
            else if(!villager.state){
                RemoveItems();
                GameObject.FindGameObjectWithTag("Blocked").SetActive(false);
                villager.state = true;
                break;
            }
        }
    }

    public void Tiger()
    {
        State s = items[0];
        //if the player has the item
        if(s.state){
            RemoveItems();
        }
    }

    public void Spider()
    {
        State s = items[0];
        if(s.state){
            RemoveItems();
        }
    }

    void Update()
    {
        if(villager.name == "Metalon" && CheckItemState() && !itemState){
            villager.GetComponent<DialogueTrigger>().ChangeDialogue();
            itemState = true;
        }

        if(villager.name == "Tiger" && items[0].state && !villager.state){
            villager.GetComponent<DialogueTrigger>().ChangeDialogue();
            villager.state = true;
        }

        if(villager.name == "Spider" && items[0].state && !villager.state){
            villager.GetComponent<DialogueTrigger>().ChangeDialogue();
            villager.state = true;
        }
      
    }

}
