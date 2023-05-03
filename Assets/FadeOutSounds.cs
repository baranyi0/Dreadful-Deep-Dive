using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutSounds : MonoBehaviour
{
    [SerializeField] AudioSource[] audioSources;
    [SerializeField] float target = 0f;
    [SerializeField] float duration = 1f;
    private void Start()
    {
        
        foreach (var item in audioSources)
        {
            StartCoroutine(FadeOut(item, duration, item.volume));
        }
    }


    public IEnumerator FadeOut(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
