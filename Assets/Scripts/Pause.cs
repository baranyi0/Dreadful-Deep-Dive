using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pause;
    [SerializeField] FPSController controller;

    public bool canOpen = true;


    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canOpen)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
            controller.enabled = false;
            pause.SetActive(true);
        }

    }
    public void BackToGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pause.SetActive(false);
        controller.enabled = true;
    }
    public void BacktoMain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        controller.enabled = false;
        pause.SetActive(true);
    }
}
