using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public GameObject player;
    public bool canSeeYou = false;
    public GameObject point, enemy;
    public Vector3 playerRespawnLoc, enemyRespawnLoc;
    public Swimming sw;
    public FPSController f;
    public GameObject killScreen;
    public Proximity proxi;
    bool doOnce = false;
    public AudioSource breathing;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canSeeYou && !doOnce)
        {
            doOnce = true;
            StartCoroutine("Kill");
        }
    }
    void Update()
    {
        RaycastHit hit;

        if (Physics.Linecast(point.transform.position, player.transform.position, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                canSeeYou = true;
            }
            else
            {
                canSeeYou = false;
            }
        }
    }

    IEnumerator Kill()
    {
        breathing.enabled = false;
        killScreen.SetActive(true);
        proxi.enabled  = false;
        sw.enabled = false;
        f.enabled = false;

        player.transform.position = playerRespawnLoc;
        enemy.transform.position = enemyRespawnLoc;

        yield return new WaitForSeconds(5f);
        breathing.enabled = true;
        sw.enabled = true;
        f.enabled = true;
        killScreen.SetActive(false);
        proxi.enabled = true;
        doOnce = false;
    }
}
