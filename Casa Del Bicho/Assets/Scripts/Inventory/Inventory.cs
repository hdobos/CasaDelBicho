// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.EventSystems;
// using UnityEditor.Events;

// public class Inventory : MonoBehaviour
// {
//     public bool[] isFull;
//     public Slot[] slots;
//     public GameObject gameobject;

//     void Start(){
//         // EventTrigger trigger = slots[i].GetComponent<EventTrigger>();
//         // EventTrigger.Entry entry = new EventTrigger.Entry();
//         // entry.eventID = EventTriggerType.PointerDown;
//         // entry.callback.AddListener(data => OnPointerDownDelegate((PointerEventData)data));
//         // trigger.triggers.Add(entry);
//     }

//     public void AddItem(Item item){
//         for(int i = 0; i < slots.Length; i++){
//             if(isFull[i] == false){
//                 //slots[i].GetComponent<Item>() = item;
//                 if(item.CompareTag("Item")){
//                     slots[i].getItem().GetComponent<Image>().sprite = item.GetComponent<SpriteMask>().sprite;
//                 }
//                 else{
//                     slots[i].getItem().GetComponent<Image>().sprite = item.GetComponent<Image>().sprite;
//                 }
                

//                 isFull[i] = true;
//                 break;
//             }
//         }
//     }

//     // public void OnPointerDownDelegate(PointerEventData data)
//     // {
//     //     gameobject = GameObject.FindGameObjectWithTag("CraftingManager");
//     //     gameobject.GetComponent<CraftingManager>();

//     // }
// }
