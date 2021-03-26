using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
	public string levelToLoad;
	private float timer = 70f;
	private Text timerText;
	private float minutes;
	private float seconds;
	private bool changeMusic = false;
	public AudioSource firstTrack;
	public AudioSource secondTrack;
	
	
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
		if (timer <= 60 && !changeMusic)
		{
			Destroy(firstTrack.gameObject);
			secondTrack.Play();
			changeMusic = true;
		}

		if (GameManager.gameState == GameManager.GameState.Play)
		{
			timer -= Time.deltaTime;
		}
		
		DisplayTime();
		// When time runs out, scene changes
		if (timer <= 0)
		{
			Application.LoadLevel("GameOver");
		}
    }
}
