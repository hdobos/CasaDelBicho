// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// [System.Serializable]
// public class SlotContainer : MonoBehaviour
// {
//     public Sprite itemSprite; //sprite of item inside slot
//     public int itemCount; //number of items inside slot

//     [HideInInspector]
//     public int tableID;

//     [HideInInspector]
//     public SlotTemplate slot;

//     [HideInInspector]
//     public CraftItem craftController;

//     public void InitializeSlotTable(RectTransform container, SlotTemplate tempSlotTemplate, SlotContainer[] slots, int margin, int tempTableID)
//     {
//         int resetIndex = 0;
//         int tempRow = 0;

//         for(int i = 0; i < slots.Length; i++){
//             if(slots[i] == null){
//                 slots[i] = new SlotContainer();
//             }
//             GameObject newSlot = Instantiate(tempSlotTemplate.gameObject, container.transform);
//             slots[i].slot = newSlot.GetComponent<SlotTemplate>();
//             slots[i].slot.gameObject.SetActive(true);
//             slots[i].tableID = tempTableID;

//             float tempX = (int)((margin + slots[i].slot.container.rectTransform.sizeDelta.x) * (i - resetIndex));
//             if( (tempX + slots[i].slot.container.rectTransform.sizeDelta.x + margin) > (container.rect.width) ){
//                 resetIndex = i;
//                 tempRow++;
//                 tempX = 0;
//             }
//             slots[i].slot.container.rectTransform.anchoredPosition = new Vector2(margin + tempX, -margin - ( (margin + slots[i].slot.container.rectTransform.sizeDelta.y) * tempRow));
//         }
//     }

//     public SlotContainer GetClickedSlot()
//     {
//         for(int i = 0; i < craftController.inventorySlots.Length; i++){
//             if(craftController.inventorySlots[i].slot.hasClicked){
//                 craftController.inventorySlots[i].slot.hasClicked = false;
//                 return craftController.inventorySlots[i];
//             }
//         }

//         for(int i = 0; i < craftController.craftingSlots.Length; i++){
//             if(craftController.craftingSlots[i].slot.hasClicked){
//                 craftController.craftingSlots[i].slot.hasClicked = false;
//                 return craftController.craftingSlots[i];
//             }
//         }

//         if(craftController.resultSlot.slot.hasClicked){
//             craftController.resultSlot.slot.hasClicked = false;
//             return craftController.resultSlot;
//         }

//         return null;
//     }
    
// }
