using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDoots : MonoBehaviour
{
    private AudioController audioController;

    // music
    [SerializeField] AudioSource track1;
    [SerializeField] AudioSource track2;

    public bool layer2 = false;
    public bool layer3 = false;

    // sfx
    [SerializeField] AudioSource pauseSound;

    void Start()
    {
        audioController = GetComponent<AudioController>();
    }

    private void Update()
    {
        track1.volume = audioController.music / 10;

        if (layer2)
            track2.volume = audioController.music / 10;
        else
            track2.volume = 0;
    }

    public void PlayPauseSound()
    {
        pauseSound.volume = (audioController.sfx / 10) / 2;
        pauseSound.Play();
    }
}
