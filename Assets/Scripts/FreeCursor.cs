using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCursor : MonoBehaviour
{
    [SerializeField] FPSController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            controller.enabled = false;
        }
    }
}
