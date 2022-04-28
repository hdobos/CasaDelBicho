using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sentence 
{
    public bool active;

    [TextArea(1, 10)]
    public string sentence;
}
