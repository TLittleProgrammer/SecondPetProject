using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void StartAudioGetCoin(AudioClip clip)
    {
        _audio.clip = clip;
        _audio.Play();
    }
}
