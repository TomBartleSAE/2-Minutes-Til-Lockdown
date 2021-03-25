using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkout : MonoBehaviour
{
    ShoppingList list;
    UIMessage message;

    [SerializeField]
    GameObject victoryScreen;

    bool listComplete = false;

    private void Start()
    {
        list = FindObjectOfType<ShoppingList>();
        message = FindObjectOfType<UIMessage>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (list.GetShoppingList().Count > 0)
            {
                StartCoroutine(message.ShowMessage("You don't have all the items on your shopping list yet!", 3));
            }
            else
            {
                GameManager.gameState = GameManager.GameState.Paused;
                victoryScreen.SetActive(true);
            }
        }
    }

    public void EnableGlow()
    {
        GetComponentInChildren<ParticleSystem>().Play();
    }
}
