using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public string name;
    public bool dialogue = false;
    public bool state;
    
    public void setState(bool b)
    {
        state = b;
    }

    public void Speak(bool b)
    {
        dialogue = b;
    }
}
