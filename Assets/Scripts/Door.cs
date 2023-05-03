using UnityEngine;
using UnityEngine.AI;

public class Door : MonoBehaviour
{
    Animator anim;

    public bool locked = false;

    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    public void OpenClose()
    {
        if (!locked)
        {
            anim.SetTrigger("OpenClose");
        }
    }
}
