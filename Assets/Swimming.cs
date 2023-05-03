using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swimming : MonoBehaviour
{
    public Rigidbody rigidbody;
    public Transform target;
    public float swimSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            transform.position += target.forward * swimSpeed * Time.deltaTime;
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            transform.position -= target.forward * swimSpeed * Time.deltaTime;
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.position += target.right * swimSpeed * Time.deltaTime;
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.position -= target.right * swimSpeed * Time.deltaTime;
        }
    }
}
