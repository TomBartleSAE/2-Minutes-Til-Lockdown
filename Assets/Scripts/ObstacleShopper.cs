using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleShopper : MonoBehaviour
{
    [SerializeField]
    Transform startPoint, endPoint;

    [SerializeField]
    float speed;

    Vector3 startPosition, endPosition, direction;

    [SerializeField]
    float pushForce;

    private void Start()
    {
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
        }
        
        if (transform.position == endPosition)
        {
            direction = startPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
/*            Vector2 pushDirection = collision.transform.position - transform.position;
            pushDirection = pushDirection.normalized;

            collision.GetComponent<Rigidbody2D>().AddForce(pushDirection * pushForce, ForceMode2D.Impulse);*/
        }
    }
}
