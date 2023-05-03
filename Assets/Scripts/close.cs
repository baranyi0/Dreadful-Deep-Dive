using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class close : MonoBehaviour
{
    [SerializeField] GameObject PDA;
    //[SerializeField] Pause p;

    [SerializeField] FPSController controller;
    public Swimming s;
    public Sway sw;


    private void OnEnable()
    {
        //  p.enabled = false;
        controller.enabled = false;
        s.enabled = false;
        sw.enabled = false;
    }
    private void OnDisable()
    {
    //    p.enabled = true;
    }

    public void Close()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PDA.SetActive(false);
        controller.enabled = true;
        s.enabled = true;
        sw.enabled = true;
    }
    
    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();
    }
}

