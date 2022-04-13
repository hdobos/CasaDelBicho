using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemContainer
{
    bool ContainsItem(GameObject obj);
    bool RemoveItem(GameObject obj);
    bool AddItem(GameObject obj);
    bool IsFull();
    int ItemCount(GameObject obj);
}
