using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingList : MonoBehaviour
{
    [SerializeField]
    int listLength;

    [SerializeField]
    List<Item> currentList;

    List<Item> completeList;

    [SerializeField]
    Transform listContents;

    [SerializeField]
    GameObject itemSlotPrefab;

    GameObject[] itemSlots;

    [SerializeField]
    Item[] allItems;

    private void Start()
    {
        WriteList();
    }

    public void WriteList()
    {
        itemSlots = new GameObject[listLength];

        completeList = new List<Item>();
        completeList.Add(allItems[0]); // Toilet Paper should always be index 0 of allItems

        // Add Toilet Paper to the shopping list UI
        GameObject tpSlot = Instantiate(itemSlotPrefab, listContents);
        itemSlots[0] = tpSlot;
        tpSlot.transform.GetChild(0).GetComponent<Image>().sprite = allItems[0].GetItemSprite();
        tpSlot.transform.GetChild(1).GetComponent<Text>().text = allItems[0].name;

        int nextSlot = 1;

        // Randomise the rest of the items
        while (completeList.Count < listLength)
        {
            // Get a random item (that isn't TP) and check if it's already on the list
            Item newItem = allItems[Random.Range(1, allItems.Length)];

            if (!completeList.Contains(newItem))
            {
                // Add the item and add it to the list UI if it's not already in it
                completeList.Add(newItem);
                GameObject newSlot = Instantiate(itemSlotPrefab, listContents);
                newSlot.transform.GetChild(0).GetComponent<Image>().sprite = newItem.GetItemSprite();
                newSlot.transform.GetChild(1).GetComponent<Text>().text = newItem.name;
                itemSlots[nextSlot] = newSlot;
                nextSlot++;
            }
        }

        currentList = new List<Item>(completeList);
    }

    public void CollectItem(Item collectedItem)
    {
        // Enable the crossout sprite on the collected item then remove it from the list
        itemSlots[completeList.IndexOf(collectedItem)].transform.GetChild(2).GetComponent<Image>().enabled = true;
        currentList.Remove(collectedItem);

        if (currentList.Count == 0)
        {
            EventManager.OnListComplete();
        }
    }

    public List<Item> GetShoppingList()
    {
        return currentList;
    }
}
