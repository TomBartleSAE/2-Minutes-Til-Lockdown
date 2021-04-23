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
                // Pauses game and sets button sprite to play button
                Time.timeScale = 0;
                GameManager.gameState = GameManager.GameState.Paused;
                image.sprite = playSprite;

                // Find all audio sources, pause any that are playing audio and store them in a list
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
                // Unpauses games and sets button sprite to pause button
                Time.timeScale = 1;
                GameManager.gameState = GameManager.GameState.Play;
                image.sprite = pauseSprite;

                // Resume all audio sources that were previously playing audio
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
