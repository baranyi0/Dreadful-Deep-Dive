using UnityEngine;
using UnityEngine.UI;

public class InspectRaycast : MonoBehaviour
{
    [SerializeField] private float rayLenght = 1;
    [SerializeField] private LayerMask layerMaskInteract;

    public ObjectController raycastedObj;

    private bool doOnce = false;

    public Image crosshair;

    public Color tr;


    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hit, rayLenght, layerMaskInteract.value))
        {
            if (hit.collider.CompareTag("Interact"))
            {
                doOnce = false;
                if (!doOnce)
                {
                    raycastedObj = hit.collider.gameObject.GetComponent<ObjectController>();

                    raycastedObj.ShowName();
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    switch (raycastedObj.theObject)
                    {
                        case ObjectController.Objects.Nothing:
                            break;
                        case ObjectController.Objects.Valuable:
                            hit.collider.gameObject.GetComponent<Valuable>().Steal();
                            break;
                        case ObjectController.Objects.Door:
                            hit.collider.gameObject.GetComponent<Door>().OpenClose();
                            break;
                        case ObjectController.Objects.PDA:
                            hit.collider.gameObject.GetComponent<tablet>().PickUp();
                            break;
                        case ObjectController.Objects.Key:
                            hit.collider.gameObject.GetComponent<Key>().PickUp();
                            break;
                        case ObjectController.Objects.BigDoor:
                            hit.collider.gameObject.GetComponent<BigDoor>().DoSomething();
                            break;
                        case ObjectController.Objects.Handle:
                            hit.collider.gameObject.GetComponent<Handle>().PickUp();
                            break;
                    }
                    raycastedObj.ShowExtraInfo();
                }
            }
        }
        else
        {

            raycastedObj.HideName();
            doOnce = true;
        }
    }
}