// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// [System.Serializable]
// public class _Item
// {
//     public Sprite itemSprite; //item sprite
//     public bool stackable = false; //can item be stacked
//     public string craftingRecipe; //crafting recipes separated by commas

//     [HideInInspector]
//     public CraftItem craftController;

//     //updates table UI
//     public void UpdateItems(SlotContainer[] slots)
//     {
//         for(int i = 0; i < slots.Length; i++){
//             _Item slotItem = FindItem(slots[i].itemSprite);
//             //item in slot
//             if(slotItem != null){
//                 if(!slotItem.stackable){
//                     slots[i].itemCount = 1;
//                 }

//                 //apply total item count
//                 if(slots[i].itemCount > 1){
//                     slots[i].slot.count.enabled = true;
//                     slots[i].slot.count.text = slots[i].itemCount.ToString();
//                 }
//                 else{
//                     slots[i].slot.count.enabled = false;
//                 }

//                 //apply item icon
//                 slots[i].slot.item.enabled = true;
//                 slots[i].slot.item.sprite = slotItem.itemSprite;
//             }
//             //no item in slot
//             else{
//                 slots[i].slot.count.enabled = false;
//                 slots[i].slot.item.enabled = false;
//             }
//         }
//     }

//     //finds item from the items list using the sprite as a reference
//     public _Item FindItem(Sprite sprite)
//     {
//         if(!sprite){
//             return null;
//         }

//         for(int i = 0; i < craftController.items.Length; i++){
//             if(craftController.items[i].itemSprite == sprite){
//                 return craftController.items[i];
//             }
//         }

//         return null;
//     }

//     //finds item from items list using recipe as reference
//     public _Item FindItem(string recipe)
//     {
//         if(recipe == ""){
//             return null;
//         }

//         for(int i = 0; i < craftController.items.Length; i++){
//             if(craftController.items[i].craftingRecipe == recipe){
//                 return craftController.items[i];
//             }
//         }

//         return null;
//     }
// }

