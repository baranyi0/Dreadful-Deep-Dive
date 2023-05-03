using UnityEngine;
using UnityEngine.Events;

public class ObjectController : MonoBehaviour
{
    public string objectName;
    public string extraInfo;
    [SerializeField] InspectController inspectController;
   
    
    public enum Objects
    {
        Nothing,
        Valuable,
        Door,
        PDA,
        Key,
        Handle, 
        BigDoor
    }

    public Objects theObject;


    public void ShowExtraInfo()
    {
        inspectController.ShowInfo(extraInfo);
    }

    public void ShowName()
    {
        inspectController.ShowName(objectName);
    }

    public void HideName()
    {
        inspectController.HideName();
    }

    private void Awake()
    {
        inspectController = GameObject.FindGameObjectWithTag("Scene").GetComponent<InspectController>();
    }
    
}
