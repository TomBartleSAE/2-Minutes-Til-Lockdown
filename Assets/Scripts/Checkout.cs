using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkout : MonoBehaviour
{
    ShoppingList list;
    UIMessage message;

    private void Start()
    {
        list = FindObjectOfType<ShoppingList>();
        message = FindObjectOfType<UIMessage>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if player is entering trigger
        if (collision.CompareTag("Player"))
        {
            // Check if player has collected all the items on their list
            if (list.GetShoppingList().Count > 0)
            {
                StartCoroutine(message.ShowMessage("You don't have all the items on your shopping list yet!", 3));
            }
            else
            {
                GameManager.gameState = GameManager.GameState.MainMenu;
                SceneManager.LoadScene("Victory");
            }
        }
    }

    // Show glowing particle ring when all items have been collected
    public void EnableGlow()
    {
        GetComponentInChildren<ParticleSystem>().Play();
    }

    private void OnEnable()
    {
        EventManager.ListCompleted += EnableGlow;
    }

    private void OnDisable()
    {
        EventManager.ListCompleted -= EnableGlow;
    }
}
