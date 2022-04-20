using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu]
public class CraftingRecipe : MonoBehaviour
{
    public Item[] Materials;
    public Item[] Results;

    public bool CanCraft(IItemContainer itemContainer){
        foreach(Item item in Materials){
            if(itemContainer.ItemCount(item) < item.Amount){
                return false;
            }
        }
        return true;
    }

    public void Craft(IItemContainer itemContainer){
        if(CanCraft(itemContainer)){
            foreach(Item item in Materials){
                for(int i = 0; i < item.Amount; i++){
                    itemContainer.RemoveItem(item);
                }
            }

            foreach(Item item in Results){
                for(int i = 0; i < item.Amount; i++){
                    itemContainer.AddItem(item);
                }
            }
        }
    }

}
