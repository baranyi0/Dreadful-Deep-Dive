using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    

    [Header("Random Stuff")]
    [SerializeField] bool setupAutomaticly = false;
    [SerializeField] bool playOnStart = false;
    [SerializeField] bool playRandomly = false;
    [SerializeField] float chance = 0.2f; //%80 percent chance

    [Header ("Pitch Stuff")]
    [SerializeField] bool hasRandomPitch = false;
    [SerializeField] float pitchLowest = 0.7f;
    [SerializeField] float pitchHighest = 1.25f;

    private void Start()
    {
        if (playOnStart)
        {
            PlaySoundWithoutClip();
        }
        if (setupAutomaticly)
        {
            audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        }
    }

    public void PlaySoundVoid(AudioClip audioClip)
    {
        if (hasRandomPitch)
        {
            audioSource.pitch = Random.Range(pitchLowest, pitchHighest);
        }
        audioSource.PlayOneShot(audioClip);
    }

    public void PlaySoundVoidRandomPitch(AudioClip audioClip)
    {
            audioSource.pitch = Random.Range(pitchLowest, pitchHighest);
        audioSource.PlayOneShot(audioClip);
    }


    public void PlaySoundWithoutClip()
    {
        if (hasRandomPitch)
        {
            audioSource.pitch = Random.Range(pitchLowest, pitchHighest);
        }
        if(playRandomly && Random.value > chance)
        {
            audioSource.Play();
        }
        else if(!playRandomly)
        {
            audioSource.Play();
        }
    }
}