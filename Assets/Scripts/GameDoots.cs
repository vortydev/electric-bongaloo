using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDoots : MonoBehaviour
{
    private AudioController audioController;
    [SerializeField] Sanity sanity;

    // music
    [SerializeField] AudioSource track1;
    [SerializeField] AudioSource track2;
    [SerializeField] AudioSource track3;

    // sfx
    [SerializeField] AudioSource pause;
    [SerializeField] AudioSource unpause;

    void Start()
    {
        audioController = GetComponent<AudioController>();
    }

    private void Update()
    {
        track1.volume = audioController.music / 10;
        track2.volume = (audioController.music / 10) * ((sanity.maxSanity - sanity.sanity) * 0.01f);
    }

    public void PlayPauseSound()
    {
        pause.volume = (audioController.sfx / 10) / 2;
        pause.Play();
    }


    public void PlayUnpauseSound() 
    {
        unpause.volume = (audioController.sfx / 10) / 2;
        unpause.Play();
    }
}
