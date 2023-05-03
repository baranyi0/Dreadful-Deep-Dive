using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSee : MonoBehaviour
{
    public bool canMove;

    private void OnBecameInvisible()
    {

        canMove = true;
    }

    private void OnBecameVisible()
    {
        canMove = false;
    }

}
