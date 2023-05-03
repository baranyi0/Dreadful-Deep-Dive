using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDoor : MonoBehaviour
{
    public GameObject animDoor, thisDoor;
    public bool canDoSomething = false;
    public GameObject enemy;

    public void DoSomething()
    {
        if (canDoSomething)
        {
            animDoor.SetActive(true);
            enemy.SetActive(false);
            Destroy(thisDoor);
        }
    }
}
