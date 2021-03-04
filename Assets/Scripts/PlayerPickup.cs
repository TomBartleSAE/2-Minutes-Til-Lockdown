using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    ShoppingList list;
    
    [SerializeField]
    float pickupRadius = 5f;

    [SerializeField]
    LayerMask itemLayer;

    private void Start()
    {
        // TODO: Find a better way to get shopping list, maybe events or static function?
        list = FindObjectOfType<ShoppingList>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Check if any items are within a certain radius of the player
            Collider2D foundItem = Physics2D.OverlapCircle(transform.position, pickupRadius, itemLayer);

            if (foundItem != null)
            {
                PickupItem(foundItem);
            }
        }
    }

    void PickupItem(Collider2D foundItem)
    {
        Item type = foundItem.GetComponent<ItemPickup>().GetItemType();

        // Check if the item found is on the shopping list
        if (list.GetShoppingList().Contains(type))
        {
            // Remove it from the list and destroy the pickup object
            list.CollectItem(type);
            Destroy(foundItem.gameObject);
        }
        else
        {
            // Show warning message
            print("This item is not on your list!");
        }
    }
}
