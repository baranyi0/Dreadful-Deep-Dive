using UnityEngine;

public class InteractableObjectController : MonoBehaviour
{
    public Color color;
    [SerializeField] Color desiredColor;

    void Update()
    {
        color = Color.Lerp(Color.black, desiredColor, Mathf.PingPong(Time.time, 1f));
    }
}