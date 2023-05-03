using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    Animator anim;
    GameObject player;
    NavMeshAgent nav;
    public CanSee c;

    bool doOnce = false;
    void Awake()
    {
        player = GameObject.Find("FirstPersonController");
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
    }



    void Update()
    {
        if (c.canMove)
        {
            doOnce = false;

            nav.speed = 1f;
            anim.speed = 2f;
            NavMeshPath navMeshPath = new NavMeshPath();
            if (nav.CalculatePath(player.transform.position, navMeshPath) && navMeshPath.status == NavMeshPathStatus.PathComplete)
            {
                nav.SetPath(navMeshPath);
            }
        }
        else
        {
            if (!doOnce)
            {

                StartCoroutine("DelayStop");

            }
        }
    }

    IEnumerator DelayStop()
    {
        doOnce = true;
        yield return new WaitForSeconds(0.35f);

        nav.speed = 0f;
        anim.speed = 0f;
    }
}