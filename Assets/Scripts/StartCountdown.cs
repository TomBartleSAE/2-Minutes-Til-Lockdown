using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCountdown : MonoBehaviour
{
    Text countdownText;
    Animator anim;

    private void Start()
    {
        GameManager.gameState = GameManager.GameState.MainMenu;
        
        countdownText = GetComponent<Text>();
        anim = GetComponent<Animator>();

        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        countdownText.text = "3";
        yield return new WaitForSeconds(1);

        countdownText.text = "2";
        yield return new WaitForSeconds(1);

        countdownText.text = "1";
        yield return new WaitForSeconds(1);

        anim.SetTrigger("Text");
        countdownText.text = "Shop!";
        yield return new WaitForSeconds(2);

        GameManager.gameState = GameManager.GameState.Play;
        Destroy(gameObject);
    }
}
