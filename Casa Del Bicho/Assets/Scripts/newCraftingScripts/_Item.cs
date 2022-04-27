using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class _Item
{
    public Sprite itemSprite; //item sprite
    public bool stackable = false; //can item be stacked
    public string craftingRecipe; //crafting recipes separated by commas

}