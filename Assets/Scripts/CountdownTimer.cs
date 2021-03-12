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
    
	void DisplayTime()
	{
		minutes = Mathf.FloorToInt(timer / 60);
		seconds = Mathf.FloorToInt(timer % 60);
		timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
	}
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
		DisplayTime();
		if (timer <= 0)
		{
			Application.LoadLevel("TestSceneTom");
		}
    }
}
