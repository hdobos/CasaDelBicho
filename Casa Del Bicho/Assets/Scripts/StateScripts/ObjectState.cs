using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectState : MonoBehaviour
{
    public string name;
    public bool state;

    public void setState(bool b)
    {
        state = b;
    }
}
