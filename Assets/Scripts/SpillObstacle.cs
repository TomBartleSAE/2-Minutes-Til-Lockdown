using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpillObstacle : MonoBehaviour
{
    private PlayerMovement player;
    public float slowSpeed = 2.5f;
    private float savedSpeed;
    private AudioSource track;

    // Start is called before the first frame update
    void Start()
    {
        print("whoops a spill");
        player = FindObjectOfType<PlayerMovement>();
        track = GetComponent<AudioSource>();
    }

   void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            savedSpeed = player.movementSpeed;
            player.movementSpeed = slowSpeed;
            track.Play();
        }
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            player.movementSpeed = savedSpeed;
            track.Stop();
        }
    }
}
