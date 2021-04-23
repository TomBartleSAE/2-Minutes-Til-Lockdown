using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleShopper : MonoBehaviour
{
    Animator anim;
    
    [SerializeField]
    Transform startPoint, endPoint; // Transforms that will show where the shopper moves between

    [SerializeField]
    float speed; // Distance travelled per second

    Vector3 startPosition, endPosition, direction; // Position vectors for the start and end point transforms

    [SerializeField]
    float pushForce; // Force applied to player when collided with

    enum StartDirection { Right, Left}
    [SerializeField]
    StartDirection startDirection; // Sets starting animation to be facing the direction shopper is moving

    private void Start()
    {
        anim = GetComponent<Animator>();

        if (startDirection == StartDirection.Left)
        {
            anim.SetTrigger("Change");
        }
        
        startPosition = startPoint.position;
        endPosition = endPoint.position;
        direction = endPoint.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, direction, speed * Time.deltaTime); // Move toward desired position
        
        // If shopper reaches target position, change target to be the other position
        if (transform.position == startPosition)
        {
            direction = endPosition;
            anim.SetTrigger("Change");
        }
        if (transform.position == endPosition)
        {
            direction = startPosition;
            anim.SetTrigger("Change");
        }
    }
}
