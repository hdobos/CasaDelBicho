using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent onInteract;
    public Sprite interactIcon;
    
    private static int totalIDs = 0;
    private int ID;
    
    // Start is called before the first frame update
    void Start()
    {
        ID = totalIDs;
        totalIDs++;
    }

    public int GetID(){
        return ID;
    }
}
