using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, IItemContainer
{
    [SerializeField] GameObject[] itemSlots;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool ContainsItem(Item item){
        return false;
    }

    public bool RemoveItem(Item item){
        return false;
    }

    public bool AddItem(Item item){
        return false;
    }

    public bool IsFull(){
        return false;
    }
    public int ItemCount(Item item){
        return 0;
    }
}
