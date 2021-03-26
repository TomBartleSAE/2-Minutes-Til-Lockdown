using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    AudioSource bgm;

    private void Start()
    {
        bgm = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(!bgm.isPlaying && GameManager.gameState == GameManager.GameState.Play)
        {
            bgm.Play(0);
        }
    }
}
