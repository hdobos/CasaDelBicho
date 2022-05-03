using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFadeDisable : MonoBehaviour
{
    public GameObject uiObject;
    public GameObject trigger;

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {

            Destroy(trigger);
            Destroy(uiObject);


        }
    }

}
