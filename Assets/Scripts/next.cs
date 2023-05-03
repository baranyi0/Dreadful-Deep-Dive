using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class next : MonoBehaviour
{
    [SerializeField] GameObject Firstpage;
    [SerializeField] GameObject Secondpage;

    public void nextpage()
    {
        Firstpage.SetActive(false);
        Secondpage.SetActive(true);
    }
    public void back()
    {
        Secondpage.SetActive(false);
        Firstpage.SetActive(true);
    }
}

