using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State[] items; //list of items that player needs to have
    public State villager;
    bool itemState = false;

    private bool tiger, butterfly, spider;

    private GameObject[] fire;


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
        State s = items[0]; //roof
        State s2 = items[1]; // matchstick
        if(s.state){
            RemoveItems();
        }

        if(s2.state){
            //end game code
            fire = GameObject.FindGameObjectsWithTag("FIRE");
            foreach(GameObject obj in fire){
                Debug.Log(obj);
                obj.SetActive(true);
            }
        }
    }

    public void Spider()
    {
        State s = items[0];
        if(s.state){
            RemoveItems();
            GameObject.FindGameObjectWithTag("Bassinet").SetActive(true); //activates bassinet
            GameObject.FindGameObjectWithTag("StrawHouse").SetActive(true); //activates straw house
            GameObject.FindGameObjectWithTag("DestroyedStraw").SetActive(false); //deactivates broken house
        }

    }

    public void Butterfly()
    {
        State s = items[0];
        if(s.state){
            RemoveItems();
            GameObject.FindGameObjectWithTag("Paintbrush").SetActive(true);
            GameObject.FindGameObjectWithTag("CupHouse").SetActive(true);
            GameObject.FindGameObjectWithTag("DestroyedCup").SetActive(false);
        }
    }

    public void BlueJay()
    {
        if(tiger && spider && butterfly && !villager.state){
            villager.GetComponent<DialogueTrigger>().ChangeDialogue();
            GameObject.FindGameObjectWithTag("MatchstickRecipe").SetActive(true);
            villager.state = true;
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
            tiger = true;
        }

        if(villager.name == "Spider" && items[0].state && !villager.state){
            villager.GetComponent<DialogueTrigger>().ChangeDialogue();
            villager.state = true;
            spider = true;
        }

        if(villager.name == "Butterfly" && items[0].state && !villager.state){
            villager.GetComponent<DialogueTrigger>().ChangeDialogue();
            villager.state = true;
            butterfly = true;
        }
      
    }

}
