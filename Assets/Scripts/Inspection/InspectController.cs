using UnityEngine;
using UnityEngine.UI;

public class InspectController : MonoBehaviour
{
    [SerializeField] private Text objectNameUI;
    [SerializeField] private float onScreenTime;
    [SerializeField] private Text info;
    [HideInInspector] public bool startTimer;
    private float timer;

    private void Update()
    {
        if (startTimer)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                HideInfo();
                timer = 0;
                startTimer = false;
            }
        }
    }
    public void ShowName(string objectName)
    {
        objectNameUI.text = objectName;
    }

    public void HideName()
    {
        objectNameUI.text = "";
    }

    public void ShowInfo(string newInfo)
    {
        timer = onScreenTime;
        startTimer = true;
        info.text = newInfo;
    }

    public void HideInfo()
    {
        info.text = "";
    }
}
