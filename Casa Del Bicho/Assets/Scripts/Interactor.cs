using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    public LayerMask interactableLayerMask = 6;
    Interactable interactable;
    public Image interactImage;
    //public RectTransform iconTransform;
    public Sprite defaultIcon;
    public Sprite defaultInteractIcon;

    // Start is called before the first frame update
    void Start()
    {
        interactImage.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 20, interactableLayerMask)){
            if(hit.collider.GetComponent<Interactable>() != false){

                if(interactable == null || interactable.GetID() != hit.collider.GetComponent<Interactable>().GetID()){
                    interactable = hit.collider.GetComponent<Interactable>();
                }

                if(interactable.interactIcon != null){
                    interactImage.GetComponent<RectTransform>().localScale = new Vector3(3.0f, 3.0f, 3.0f);
                    interactImage.sprite = interactable.interactIcon;
                }

                else{
                    interactImage.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    interactImage.sprite = defaultInteractIcon;
                }

                if(Input.GetKeyDown(KeyCode.F)){
                    interactable.onInteract.Invoke();
                }
            }
        } else{
            if(interactImage.sprite != defaultIcon){
                interactImage.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
                interactImage.sprite = defaultIcon;
            }
        }
    }
}
