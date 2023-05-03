using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnVol : MonoBehaviour
{
    [SerializeField] VolumetricLightRenderer vol;

    void Start()
    {
        vol.enabled = true;
    }

}
