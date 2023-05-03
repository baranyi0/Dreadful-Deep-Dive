using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floats : MonoBehaviour
{
    public float moveDistance = 1.0f; 
    public float moveSpeed = 1.0f; 
    public bool moveUp = true;
    [SerializeField] GameObject main;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
        
    }

    void Update()
    {
        if (moveUp)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }

        if (transform.position.y >= initialPosition.y + moveDistance)
        {
            moveUp = false;
        }
        else if (transform.position.y <= initialPosition.y)
        {
            moveUp = true;
        }
    }
}
