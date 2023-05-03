using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proximity : MonoBehaviour
{
    public Transform[] targets;
    public int i = 0;
    public float beepInterval = 0.5f;
    public AudioClip beepSound; 

    private AudioSource audioSource;
    private float timer;
    public float distance;

    public MeshRenderer proxiDevice;
    public Material red;
    public Material defa;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        timer = beepInterval;
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, targets[i].position);

        timer -= Time.deltaTime;

        if (timer <= 0)
        {

            StartCoroutine("ChangeMat");
            audioSource.PlayOneShot(beepSound);
            timer = distance / 15; 
        }
    }

    IEnumerator ChangeMat()
    {
        proxiDevice.material = red;
        yield return new WaitForSeconds(0.05f);
        proxiDevice.material = defa;
    }
}
