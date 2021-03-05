using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMessage : MonoBehaviour
{
    Text uiText;

    private void Start()
    {
        uiText = GetComponent<Text>();
        StartCoroutine(ShowMessage("You have 2 minutes to find all the items on your shopping list and reach the checkout!", 5));
    }

    public IEnumerator ShowMessage(string messageText, float duration)
    {
        uiText.text = messageText;
        uiText.enabled = true;

        yield return new WaitForSeconds(duration);

        uiText.enabled = false;
    }
}
