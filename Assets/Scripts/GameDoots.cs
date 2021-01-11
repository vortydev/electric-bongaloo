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

    // menu sfx
    [SerializeField] AudioSource pause;
    [SerializeField] AudioSource unpause;

    // light sfx
    [SerializeField] AudioSource lightOn;
    [SerializeField] AudioSource lightOff;

    // pipe sfx
    [SerializeField] AudioSource pipe1;
    [SerializeField] AudioSource pipe2;
    [SerializeField] AudioSource pipe3;

    // door sfx
    [SerializeField] AudioSource doorOpen;
    [SerializeField] AudioSource doorClose;

    // player sfx
    [SerializeField] AudioSource playerHit;
    [SerializeField] AudioSource playerDeath;

    void Start()
    {
        audioController = GetComponent<AudioController>();
    }

    private void Update()
    {
        track1.volume = audioController.music / 10;
        track2.volume = (audioController.music / 10) * ((sanity.maxSanity - sanity.sanity) * 0.01f);
        track3.volume = (audioController.music / 10) * (((sanity.maxSanity - sanity.sanity) * 0.01f) - (1 - sanity.critThreshold));
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

    public void PlayLightOnSound()
    {
        lightOn.volume = (audioController.sfx / 10) / 2;
        lightOn.Play();
    }

    public void PlayLightOffSound()
    {
        lightOff.volume = (audioController.sfx / 10) / 2;
        lightOff.Play();
    }

    public void PlayPipeSound()
    {
        int rng = Random.Range(1, 4);

        switch (rng)
        {
            case 1:
                pipe1.volume = (audioController.sfx / 10) / 2;
                pipe1.Play();
                break;

            case 2:
                pipe2.volume = (audioController.sfx / 10) / 2;
                pipe2.Play();
                break;

            case 3:
                pipe3.volume = (audioController.sfx / 10) / 2;
                pipe3.Play();
                break;
        }
    }

    public void PlayDoorOpenSound()
    {
        doorOpen.volume = (audioController.sfx / 10) / 2;
        doorOpen.Play();
    }

    public void PlayDoorCloseSound()
    {
        doorClose.volume = (audioController.sfx / 10);
        doorClose.Play();
    }

    public void PlayPlayerHitSound()
    {
        playerHit.volume = (audioController.sfx / 10) / 2;
        playerHit.Play();
    }

    public void PlayPlayerDeathSound()
    {
        playerDeath.volume = (audioController.sfx / 10) / 2;
        playerDeath.Play();
    }
}
