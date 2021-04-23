using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMessage : MonoBehaviour
{
    TextMeshProUGUI uiText;

    private void Start()
    {
        uiText = GetComponent<TextMeshProUGUI>();
    }

    public IEnumerator ShowMessage(string messageText, float duration)
    {
        // Show text on screen
        uiText.text = messageText;
        uiText.enabled = true;

        // Wait for allocated seconds, then hide message
        yield return new WaitForSeconds(duration);
        uiText.enabled = false;
    }

    public void ListCompleteMessage()
    {
        StartCoroutine(ShowMessage("You have all the items you need, now get to the checkout!", 5));
    }

    private void OnEnable()
    {
        EventManager.ListCompleted += ListCompleteMessage;
    }

    private void OnDisable()
    {
        EventManager.ListCompleted -= ListCompleteMessage;
    }
}
