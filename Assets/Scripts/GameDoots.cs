using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDoots : MonoBehaviour
{
    private AudioController audioController;

    // music
    [SerializeField] AudioSource track1;

    // sfx
    [SerializeField] AudioSource pauseSound;

    void Start()
    {
        audioController = GetComponent<AudioController>();
    }

    public void PlayPauseSound()
    {
        pauseSound.volume = (audioController.sfx / 10) / 2;
        pauseSound.Play();
    }
}
