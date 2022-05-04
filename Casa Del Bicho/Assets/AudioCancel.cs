using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCancel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Background").GetComponent<BackgroundMusic>().StopMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
