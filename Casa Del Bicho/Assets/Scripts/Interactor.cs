using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    Interactable interactable;

    public LayerMask interactableLayerMask = 6;
    public Image interactImage;
    //public RectTransform iconTransform;
    public Sprite defaultIcon;
    public Sprite defaultInteractIcon;

    //used for checking is menus are open
    private PauseMenu p;
    private CraftMenu c;

    // Start is called before the first frame update
    void Start()
    {
        interactImage.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
        p = GameObject.FindGameObjectWithTag("Menu").GetComponent<PauseMenu>();
        c = GameObject.FindGameObjectWithTag("Menu").GetComponent<CraftMenu>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        System.Console.WriteLine("BEFORE RAYCAST HIT ////////////////////");
        Debug.LogError("BEFORE RAYCAST HIT ////////////////////");

        RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 20, interactableLayerMask)){

            System.Console.WriteLine("ENTERED PHYSICS RAYCAST////////////////////////////////////////////////////////");
            Debug.LogError("ENTERED PHYSICS RAYCAST //////////////////////////////////////////////");

            if(hit.collider.GetComponent<Interactable>()){

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

                if(Input.GetMouseButtonDown(0) && interactable.interactionInProgress() == false && p.IsGamePaused() == false && c.isCrafting() == false){
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
