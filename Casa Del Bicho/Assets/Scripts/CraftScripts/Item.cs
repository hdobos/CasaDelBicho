using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public string itemName;
    public int Amount;
    public Text text;

    public Text getText(){
        return text;
    }

    public int getAmount(){
        return Amount;
    }
}
