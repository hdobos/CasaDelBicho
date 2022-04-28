using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class State
{
    public bool complete = false;
    public string name;

    public string getState()
    {
        return name;
    }
}
