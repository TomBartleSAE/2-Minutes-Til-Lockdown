using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartCountdown : MonoBehaviour
{
    TextMeshProUGUI countdownText;
    Animator anim;

    private void Start()
    {
        GameManager.gameState = GameManager.GameState.MainMenu; // Prevent player input during initial countdown
        
        countdownText = GetComponent<TextMeshProUGUI>();
        anim = GetComponent<Animator>();

        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        // Change text every second to align with text animation
        countdownText.text = "3";
        yield return new WaitForSeconds(1);

        countdownText.text = "2";
        yield return new WaitForSeconds(1);

        countdownText.text = "1";
        yield return new WaitForSeconds(1);

        anim.SetTrigger("Text");
        countdownText.text = "Shop!";
        yield return new WaitForSeconds(2);

        GameManager.gameState = GameManager.GameState.Play; // Allow player to move once countdown is complete
        Destroy(gameObject);
    }
}
