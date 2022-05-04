using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateMachine : MonoBehaviour
{
    public State[] items; //list of items that player needs to have
    public State villager;
    bool itemState = false;

    private static bool tiger, butterfly, spider;

    public GameObject[] fire;
    public GameObject[] invisObjs;

    // void Awake()
    // {

    // }

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

        //checks to see if you have the matchstick
        //if yes, end game
        if(s2.state){
            //end game code
            foreach(GameObject obj in fire){
                obj.SetActive(true);
            }

            GameObject.FindGameObjectWithTag("Dialogue").SetActive(false);

            invisObjs[0].SetActive(true);
            StartCoroutine("WaitForSec");

        }
        else if(s.state){
            RemoveItems();
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("EndScene");

    }

    public void Spider()
    {
        State s = items[0];
        if(s.state){
            RemoveItems();
            invisObjs[0].SetActive(true); //activates bassinet
            invisObjs[1].SetActive(true); //activates straw house
            GameObject.FindGameObjectWithTag("DestroyedStraw").SetActive(false); //deactivates broken house

            s.state = false; //so it doesn't call this again
        }

    }

    public void Butterfly()
    {
        State s = items[0];
        if(s.state){
            RemoveItems();
            invisObjs[0].SetActive(true); //paintbrush
            invisObjs[1].SetActive(true); //cup house
            GameObject.FindGameObjectWithTag("DestroyedCup").SetActive(false); //deactivates broken cup house

            s.state = false; //disable if statement
        }
    }

    public void BlueJay()
    {

        //State bluejay

        GameObject.FindGameObjectWithTag("Bluejay").GetComponent<State>();
     
        if (tiger && butterfly && spider && !villager.state){
            villager.GetComponent<DialogueTrigger>().ChangeDialogue();
            invisObjs[0].SetActive(true);
            villager.state = true;
            
        }

    }

    void Update()
    {

        BlueJay();

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
