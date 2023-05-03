using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityModifier : MonoBehaviour
{
    public float nu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nu = Mathf.Lerp(0.5f, -0.5f, Mathf.PingPong(Time.time, 1f));
        Physics.gravity = new Vector3(0, nu, 0);
    }
}
