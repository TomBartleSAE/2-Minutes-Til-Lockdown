using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public AudioSource track;

    ShoppingList list;
    UIMessage message;

    Collider2D foundItem;

    [SerializeField]
    LayerMask itemLayer;

    private void Start()
    {
        // TODO: Find a better way to get shopping list, maybe events or static function?
        list = FindObjectOfType<ShoppingList>();
        message = FindObjectOfType<UIMessage>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GameManager.gameState == GameManager.GameState.Play)
        {
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
            track.Play();
        }
        else
        {
            // Show warning message
            StartCoroutine(message.ShowMessage("This item is not on your shopping list!", 3));
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            collision.GetComponent<ItemPickup>().EnableGlow(true);
            foundItem = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<ItemPickup>())
        {
            collision.GetComponent<ItemPickup>().EnableGlow(false);
            foundItem = null;
        }
    }
}
