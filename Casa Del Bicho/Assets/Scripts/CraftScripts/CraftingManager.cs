using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    private Item currentItem;
    public Image customCursor;
    public Slot[] craftingSlots;
    public Slot[] inventory;
    public Item[] items;
    public Sprite[] Results;


    private void Update(){
        if(Input.GetMouseButtonUp(0)){
            if(currentItem != null){
                customCursor.gameObject.SetActive(false);
                Slot nearestSlot = null;
                float shortestDistance = float.MaxValue;

                foreach(Slot slot in craftingSlots){
                    float dist = Vector2.Distance(Input.mousePosition, slot.transform.position);

                    if(dist < shortestDistance){
                        shortestDistance = dist;
                        nearestSlot = slot;
                    }
                }
                nearestSlot.gameObject.SetActive(true);
                nearestSlot.GetComponent<Image>().sprite = currentItem.GetComponent<Image>().sprite;
                nearestSlot.item = currentItem;
                currentItem.Amount--;
                currentItem = null;
            }
        }
        
    }

    public void OnMouseDownItem(Item item){
        if(currentItem == null){
            currentItem = item;
            customCursor.gameObject.SetActive(true);
            customCursor.sprite = currentItem.GetComponent<Image>().sprite;
            
        }
    }

    public void Craft(){
        if(craftingSlots[0].getItem() == items[0] && craftingSlots[1].getItem() == items[1] && craftingSlots[2].getItem() == items[2]){
            Debug.Log("craft test");
            craftingSlots[3].GetComponent<Image>().sprite = Results[0];
        }
        else{
            foreach(Slot slot in craftingSlots){
                if(slot.getItem() != null){
                    slot.getItem().Amount++;
                }
            }
        }
    }


}
