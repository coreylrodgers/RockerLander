using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    AudioSource audio;

    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }

    public void PlaySFX()
    {
        if (!audio.isPlaying)
        {
            audio.Play();
        }
    }

    public void StopSFX()
    {
        if (audio.isPlaying)
        {
            audio.Stop();
        }
    }
}
