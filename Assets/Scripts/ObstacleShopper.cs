using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleShopper : MonoBehaviour
{
    Animator anim;
    
    [SerializeField]
    Transform startPoint, endPoint;

    [SerializeField]
    float speed;

    Vector3 startPosition, endPosition, direction;

    [SerializeField]
    float pushForce;

    enum StartDirection { Right, Left}
    [SerializeField]
    StartDirection startDirection;

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
        transform.position = Vector3.MoveTowards(transform.position, direction, speed * Time.deltaTime);
        
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
