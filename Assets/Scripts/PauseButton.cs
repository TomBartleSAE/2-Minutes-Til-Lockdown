using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] Sprite pauseSprite;
    [SerializeField] Sprite playSprite;

    Image image;

    List<AudioSource> playingAudio;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        
        switch (GameManager.gameState)
        {
            case GameManager.GameState.Play:
                Time.timeScale = 0;
                GameManager.gameState = GameManager.GameState.Paused;
                image.sprite = playSprite;
                playingAudio = new List<AudioSource>();
                foreach(AudioSource source in audioSources)
                {
                    if (source.isPlaying)
                    {
                        source.Pause();
                        playingAudio.Add(source);
                    }
                }

                break;
            case GameManager.GameState.Paused:
                Time.timeScale = 1;
                GameManager.gameState = GameManager.GameState.Play;
                image.sprite = pauseSprite;

                foreach (AudioSource source in playingAudio)
                {
                    source.Play();
                }

                break;
            default:
                break;
        }
    }
}
