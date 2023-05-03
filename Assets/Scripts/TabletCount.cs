using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabletCount : MonoBehaviour
{
    [SerializeField] Text pdaCount;

    int pdaAmount = 0;

    public void Add()
    {
        pdaAmount++;
        pdaCount.text = pdaAmount.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
