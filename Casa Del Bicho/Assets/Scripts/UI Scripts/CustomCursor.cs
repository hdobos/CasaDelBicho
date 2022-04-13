using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    
    void Awake(){
        transform.position = Input.mousePosition;
    }
    
    void Update()
    {
        transform.position = Input.mousePosition;
    }
}
