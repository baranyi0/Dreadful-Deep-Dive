using UnityEngine;

public class Sway : MonoBehaviour
{
    [SerializeField] float amount;

    [SerializeField] float smoothAmount;

    private Vector3 pos;

    private void Start()
    {
        pos = transform.localPosition;
    }

    private void Update()
    {
        float movementX = Input.GetAxis("Mouse X") * amount;
        float movementY = Input.GetAxis("Mouse Y") * amount;

        Vector3 finalPos = new Vector3(movementX, movementY, 0);
        transform.localPosition = Vector3.Lerp(transform.localPosition, finalPos + pos, Time.deltaTime * smoothAmount);
    }
}