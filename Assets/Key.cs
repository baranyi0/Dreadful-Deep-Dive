using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private Transform player;
    bool canBePickedUp;
    BoxCollider boxCollider;

    public Door doorToUnlock;
    public ObjectController obj;

    public bool key = true;

    public GameObject monster;
    public GameObject obelisk;

    public void PickUp()
    {
        boxCollider.enabled = false;
        canBePickedUp = true;

        doorToUnlock.locked = false;
        obj.extraInfo = "";
        obj.objectName = "Door";

        if (key)
        {
            obelisk.SetActive(false);
            monster.SetActive(true);
        }
        else
        {

        }
    }

    private void Update()
    {
        if (canBePickedUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, 25 * Time.unscaledDeltaTime);

            if (transform.position == player.transform.position)
            {
                Destroy(gameObject);
            }
        }
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        boxCollider = GetComponent<BoxCollider>();
    }
}
