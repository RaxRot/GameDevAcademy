using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource[] sfxToPlay;
    
    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
    }

    public void PlaySfx(int indexToPlay)
    {
        if (GameManager.Instance.IsGamePlaying)
        {
            sfxToPlay[indexToPlay].pitch = Random.Range(0.75f, 1.25f);
            sfxToPlay[indexToPlay].Stop();
            sfxToPlay[indexToPlay].Play();
        }
    }
}
