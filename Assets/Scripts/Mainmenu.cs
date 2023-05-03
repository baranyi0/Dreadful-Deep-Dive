using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    [SerializeField] Text answer;
    [SerializeField] Text txt;
    [SerializeField] InputField input;

    [SerializeField] PlaySound playsound;

    public bool startPhase, typing, end;

    private void Start()
    {
        if (end)
        {
            StartCoroutine(Type("Critical error: Cult activity detected!\n\n\n*Thanks for playing! Made by Norbert Baranyi (BEDTIME STORIES) and Bence Bubics*\n(type 'shutdown' to exit the game)"));
        }
        else
        {
            StartCoroutine(Type("type 'help' to display all of the available commands."));
        }
    }

    private void Update()
    {
        input.ActivateInputField();
    }

    public void Menu()
    {
        if (!typing)
        {
            StopAllCoroutines();
            string answ = answer.text;
            if (startPhase)
            {
                switch (answ)
                {
                    case "y":
                        input.enabled = false;
                        StartCoroutine(Type("good luck!"));
                        StartCoroutine(StartGame());
                        break;
                    case "Y":
                        input.enabled = false;
                        StartCoroutine(Type("good luck!"));
                        StartCoroutine(StartGame());
                        break;
                    case "yes":
                        input.enabled = false;
                        StartCoroutine(Type("good luck!"));
                        StartCoroutine(StartGame());
                        break;
                    case "YES":
                        input.enabled = false;
                        StartCoroutine(Type("good luck!"));
                        StartCoroutine(StartGame());
                        break;
                    case "n":
                        Return();
                        break;
                    case "N":
                        Return();
                        break;
                    case "no":
                        Return();
                        break;
                    case "NO":
                        Return();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (answ)
                {
                    case "start":
                        startPhase = true;
                        StartCoroutine(Type("In 1958, the HMS Neptune, a majestic cruise ship with hundreds of passengers aboard, mysteriously sank without a trace. Its submerged remains were not discovered until 30 years later, when a team of divers stumbled upon the wreckage. But the Neptune's secrets remained intact, as many divers were lost attempting to explore the sunken ship. You were sent down into the depths to retrieve the lost divers PDAs, which contain vital logs and information about their discoveries. As you venture into the depths of the ocean, you must navigate the treacherous waters and avoid the dangers lurking within, all in the hopes of uncovering the truth behind the HMS Neptune's tragic fate and the fate of those who were lost with her.\n \nDo you really want to embark? [Y/N]"));
                        break;
                    case "help":
                        StartCoroutine(Type("'start': Start the briefing.\n'howtoplay': Check how to play the game.\n'credits': See the masterminds behind this game.\n'shutdown': Shutdown the computer."));
                        break;
                    case "shutdown":
                        Application.Quit();
                        break;
                    case "howtoplay":
                        StartCoroutine(Type("WASD - move\nE - interact\nEsc - pause\nYou need to collect PDAs of deceased divers. Watch out for the beeping of the device in your hand, the closer you are to a diver's body, the more frequent the beeping will become."));
                        break;
                    case "credits":
                        StartCoroutine(Type("Game by Norbert Baranyi (BEDTIME STORIES) and Bence Bubics: \n\nUI Programming: Bence Bubics\nGameplay Programming: Bence Bubics, Norbert Baranyi\nEnvironment Design: Norbert Baranyi"));
                        break;
                    default:
                        Return();
                        break;
                }
            }
            input.text = string.Empty;
        }
    }

    void Return()
    {
        startPhase = false;

        StartCoroutine(Type("type 'help' to display all of the available commands."));
    }

    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Main");
    }

    public IEnumerator Type(string t)
    {
        typing = true;
        txt.text = "";
        foreach (char a in t)
        {
            txt.text += a;

            yield return new WaitForSeconds(0f);
        }

        playsound.PlaySoundWithoutClip();
        typing = false;
    }
}
