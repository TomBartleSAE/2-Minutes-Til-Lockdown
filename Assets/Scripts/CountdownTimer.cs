using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
	public string levelToLoad;
	private float timer = 120f;
	private Text timerText;
	private float minutes;
	private float seconds;
	
	
    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
    }
    // Displays the time left based on minutes and seconds
	void DisplayTime()
	{
		minutes = Mathf.FloorToInt(timer / 60);
		seconds = Mathf.FloorToInt(timer % 60);
		timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
	}
    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameState == GameManager.GameState.Play)
			timer -= Time.deltaTime;
		
		DisplayTime();
		// When time runs out, scene changes
		if (timer <= 0)
		{
			Application.LoadLevel("TestSceneTom");
		}
    }
}
