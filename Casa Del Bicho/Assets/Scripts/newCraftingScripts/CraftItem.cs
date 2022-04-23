using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftItem : MonoBehaviour
{
    public RectTransform inventorySlotsContainer;
    public RectTransform craftingSlotsContainer;
    public RectTransform resultSlotContainer;
    public Button craftButton;
    public SlotTemplate slotTemplate;
    public SlotTemplate resultSlotTemplate;


    public SlotContainer[] inventorySlots;
    SlotContainer[] craftingSlots = new SlotContainer[3]; //array of all the available crafting slots -> change to 3 once u understand this code
    SlotContainer resultSlot = new SlotContainer(); //only one results slot
    
    public _Item[] items; //array of all available items

    SlotContainer selectedItemSlot = null;

    int craftTableID = -1; //ID of table where items are placed
    int resultTableID = -1; //ID of table where items are taken from

    ColorBlock defaultButtonColors;

    void Start()
    {
        //set up slot element template
        slotTemplate.container.rectTransform.pivot = new Vector2(0, 1);
        slotTemplate.container.rectTransform.anchorMax = slotTemplate.container.rectTransform.anchorMin = new Vector2(0, 1);
        slotTemplate.craftController = this;
        slotTemplate.gameObject.SetActive(false);

        //set up of results slot template
        resultSlotTemplate.container.rectTransform.pivot = new Vector2(0, 1);
        resultSlotTemplate.container.rectTransform.anchorMax = resultSlotTemplate.container.rectTransform.anchorMin = new Vector2(0, 1);
        resultSlotTemplate.craftController = this;
        resultSlotTemplate.gameObject.SetActive(false);

        //attach click event to craft button
        craftButton.onClick.AddListener(PerformCrafting);

        //save craft button default colors
        defaultButtonColors = craftButton.colors;

        //Initialize crafting slots
        InitializeSlotTable(craftingSlotsContainer, slotTemplate, craftingSlots, 5, 0);
        UpdateItems(craftingSlots);
        craftTableID = 0;

        //Initialize inventory slots
        InitializeSlotTable(inventorySlotsContainer, slotTemplate, inventorySlots, 5, 1);
        UpdateItems(inventorySlots);

        //Initialize result slot
        InitializeSlotTable(resultSlotContainer, resultSlotTemplate, new SlotContainer[] {resultSlot}, 0, 2);
        UpdateItems(new SlotContainer[] {resultSlot});
        resultTableID = 2;

        //reset slot element template
        slotTemplate.container.rectTransform.pivot = new Vector2(0.5f, 0.5f);
        slotTemplate.container.raycastTarget = slotTemplate.item.raycastTarget = slotTemplate.count.raycastTarget = false;
    }

    //updates table UI
    public void UpdateItems(SlotContainer[] slots)
    {
        for(int i = 0; i < slots.Length; i++){
            _Item slotItem = FindItem(slots[i].itemSprite);
            //item in slot
            if(slotItem != null){
                if(!slotItem.stackable){
                    slots[i].itemCount = 1;
                }

                //apply total item count
                if(slots[i].itemCount > 1){
                    slots[i].slot.count.enabled = true;
                    slots[i].slot.count.text = slots[i].itemCount.ToString();
                }
                else{
                    slots[i].slot.count.enabled = false;
                }

                //apply item icon
                slots[i].slot.item.enabled = true;
                slots[i].slot.item.sprite = slotItem.itemSprite;
            }
            //no item in slot
            else{
                slots[i].slot.count.enabled = false;
                slots[i].slot.item.enabled = false;
            }
        }
    }

    //finds item from the items list using the sprite as a reference
    public _Item FindItem(Sprite sprite)
    {
        if(!sprite){
            return null;
        }

        for(int i = 0; i < items.Length; i++){
            if(items[i].itemSprite == sprite){
                return items[i];
            }
        }

        return null;
    }

    //finds item from items list using recipe as reference
    public _Item FindItem(string recipe)
    {
        if(recipe == ""){
            return null;
        }

        for(int i = 0; i < items.Length; i++){
            if(items[i].craftingRecipe == recipe){
                return items[i];
            }
        }

        return null;
    }

    public void ClickEventRecheck()
    {
        if(selectedItemSlot == null){
            //get clicked slot
            selectedItemSlot = GetClickedSlot();
            if(selectedItemSlot != null){
                if(selectedItemSlot.itemSprite != null){
                    selectedItemSlot.slot.count.color = selectedItemSlot.slot.item.color = new Color(1, 1, 1, 0.5f); //changed color of slot
                }
                else{
                    selectedItemSlot = null;
                }
            }
        }

        else{
            SlotContainer newClickedSlot = GetClickedSlot();
            if(newClickedSlot != null){
                bool swapPositions = false;
                bool releaseClick = true;

                if(newClickedSlot != selectedItemSlot){
                    //clicked on the same table but diff slots
                    if(newClickedSlot.tableID == selectedItemSlot.tableID){
                        //check if new clicked item is the same (stack if it is, swap if its not)
                        if(newClickedSlot.itemSprite == selectedItemSlot.itemSprite){
                            _Item slotItem = FindItem(selectedItemSlot.itemSprite);
                            if(slotItem.stackable){
                                //item is same and is stackable
                                selectedItemSlot.itemSprite = null;
                                newClickedSlot.itemCount += selectedItemSlot.itemCount;
                                selectedItemSlot.itemCount = 0;
                            }

                            else{
                                swapPositions = true;
                            }
                        }

                        else{
                            swapPositions = true;
                        }
                    }

                    else{
                        //moving to a diff table
                        if(resultTableID != newClickedSlot.tableID){
                            if(craftTableID != newClickedSlot.tableID){
                                if(newClickedSlot.itemSprite == selectedItemSlot.itemSprite){
                                    _Item slotItem = FindItem(selectedItemSlot.itemSprite);
                                    if(slotItem.stackable){
                                        //item is the same & stackable
                                        selectedItemSlot.itemSprite = null;
                                        newClickedSlot.itemCount += selectedItemSlot.itemCount;
                                        selectedItemSlot.itemCount = 0;
                                    }

                                    else{
                                        swapPositions = true;
                                    }
                                }
                                
                                else{
                                    swapPositions = true;
                                }
                            }

                            else{
                                if(newClickedSlot.itemSprite == null || newClickedSlot.itemSprite == selectedItemSlot.itemSprite){
                                    //add one item from selectedItemSlot
                                    newClickedSlot.itemSprite = selectedItemSlot.itemSprite;
                                    newClickedSlot.itemCount++;
                                    selectedItemSlot.itemCount--;
                                    if(selectedItemSlot.itemCount <= 0){
                                        //placed last item
                                        selectedItemSlot.itemSprite = null;
                                    }

                                    else{
                                        releaseClick = false;
                                    }
                                }

                                else{
                                    swapPositions = true;
                                }
                            }
                        }
                    }
                }

                //swap items
                if(swapPositions){
                    Sprite previousItemSprite = selectedItemSlot.itemSprite;
                    int previousItemCount = selectedItemSlot.itemCount;

                    selectedItemSlot.itemSprite = newClickedSlot.itemSprite;
                    selectedItemSlot.itemCount = newClickedSlot.itemCount;

                    newClickedSlot.itemSprite = previousItemSprite;
                    newClickedSlot.itemCount = previousItemCount;
                }

                //release mouse
                if(releaseClick){
                    selectedItemSlot.slot.count.color = selectedItemSlot.slot.item.color = Color.white;
                    selectedItemSlot = null;
                }

                //Update UI
                UpdateItems(inventorySlots);
                UpdateItems(craftingSlots);
                UpdateItems(new SlotContainer[] {resultSlot});
            }
        }
    }

    public void InitializeSlotTable(RectTransform container, SlotTemplate tempSlotTemplate, SlotContainer[] slots, int margin, int tempTableID)
    {
        int resetIndex = 0;
        int tempRow = 0;

        for(int i = 0; i < slots.Length; i++){
            if(slots[i] == null){
                slots[i] = new SlotContainer();
            }
            GameObject newSlot = Instantiate(tempSlotTemplate.gameObject, container.transform);
            slots[i].slot = newSlot.GetComponent<SlotTemplate>();
            slots[i].slot.gameObject.SetActive(true);
            slots[i].tableID = tempTableID;

            float tempX = (int)((margin + slots[i].slot.container.rectTransform.sizeDelta.x) * (i - resetIndex));
            if( (tempX + slots[i].slot.container.rectTransform.sizeDelta.x + margin) > (container.rect.width) ){
                resetIndex = i;
                tempRow++;
                tempX = 0;
            }
            slots[i].slot.container.rectTransform.anchoredPosition = new Vector2(margin + tempX, -margin - ( (margin + slots[i].slot.container.rectTransform.sizeDelta.y) * tempRow));
        }
    }

    public SlotContainer GetClickedSlot()
    {
        for(int i = 0; i < inventorySlots.Length; i++){
            if(inventorySlots[i].slot.hasClicked){
                inventorySlots[i].slot.hasClicked = false;
                return inventorySlots[i];
            }
        }

        for(int i = 0; i < craftingSlots.Length; i++){
            if(craftingSlots[i].slot.hasClicked){
                craftingSlots[i].slot.hasClicked = false;
                return craftingSlots[i];
            }
        }

        if(resultSlot.slot.hasClicked){
            resultSlot.slot.hasClicked = false;
            return resultSlot;
        }

        return null;
    }

    public void PerformCrafting()
    {
        string[] itemRecipe = new string[craftingSlots.Length];

        craftButton.colors = defaultButtonColors;

        for(int i = 0; i < craftingSlots.Length; i++){
            _Item slotItem = FindItem(craftingSlots[i].itemSprite);
            if(slotItem != null){
                itemRecipe[i] = slotItem.itemSprite.name + (craftingSlots[i].itemCount > 1 ? "(" + craftingSlots[i].itemCount + ")" : "");
            }

            else{
                itemRecipe[i] = "";
            }
        }

        string combinedRecipe = string.Join(",", itemRecipe);
        print(combinedRecipe);

        //search for recipe
        _Item craftedItem = FindItem(combinedRecipe);
        if(craftedItem != null){
            //clear crafting slots
            for(int i = 0; i < craftingSlots.Length; i++){
                craftingSlots[i].itemSprite = null;
                craftingSlots[i].itemCount = 0;
            }

            resultSlot.itemSprite = craftedItem.itemSprite;
            resultSlot.itemCount = 1;

            UpdateItems(craftingSlots);
            UpdateItems(new SlotContainer[] {resultSlot});
        }

        else{
            ColorBlock colors = craftButton.colors;
            colors.selectedColor = colors.pressedColor = new Color(0.8f, 0.55f, 0.55f, 1);
            craftButton.colors = colors;
        }
    }

    void Update()
    {
        //moving items around w mouse
        if(selectedItemSlot != null){
            if(!slotTemplate.gameObject.activeSelf){
                slotTemplate.gameObject.SetActive(true);
                slotTemplate.container.enabled = false;

                //copy item values into slot tempalte
                slotTemplate.count.color = selectedItemSlot.slot.count.color;
                slotTemplate.item.sprite = selectedItemSlot.slot.item.sprite;
                slotTemplate.item.color = selectedItemSlot.slot.item.color;
            }

            //making template slot follow mouse
            slotTemplate.container.rectTransform.position = Input.mousePosition;

            //update item count
            slotTemplate.count.text = selectedItemSlot.slot.count.text;
            slotTemplate.count.enabled = selectedItemSlot.slot.count.enabled;
        }

        else{
            if(slotTemplate.gameObject.activeSelf){
                slotTemplate.gameObject.SetActive(false);
            }
        }
    }

}
