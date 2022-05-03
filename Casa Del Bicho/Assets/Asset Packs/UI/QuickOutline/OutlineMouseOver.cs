using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineMouseOver : MonoBehaviour
{
    // Start is called before the first frame update
    void OnMouseOver()
    {
        var outline = gameObject.AddComponent<Outline>();

        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 8f;
    }

    // Update is called once per frame
    void OnMouseExit()
    {
        
    }
}
