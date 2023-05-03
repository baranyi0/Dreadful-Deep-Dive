using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour
{
    private Transform player;
    bool canBePickedUp;
    BoxCollider boxCollider;

    public ObjectController obj;

    public bool key = true;

    public BigDoor bgi;

    public Proximity p;

    public void PickUp()
    {
        if(p.i == 2)
        {
            this.GetComponent<ObjectController>().extraInfo = "You picked up a Door Handle!";
            boxCollider.enabled = false;
            canBePickedUp = true;

            bgi.canDoSomething = true;

            obj.extraInfo = "";
            obj.objectName = "Door";
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
