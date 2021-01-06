using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDoots : MonoBehaviour
{
    private AudioController audioController;

    // music
    [SerializeField] private AudioSource menuSoundtrack;

    // sfx
    [SerializeField] private AudioSource menuSelect;
    [SerializeField] private AudioSource menuChange;

    private void Start()
    {
        audioController = GetComponent<AudioController>();
    }

    private void Update()
    {
        menuSoundtrack.volume = audioController.music / 10;
    }

    public void PlayMenuSelect()
    {
        menuSelect.volume = (audioController.sfx / 10) / 2;
        menuSelect.Play();
    }

    public void PlayMenuBack()
    {
        menuChange.volume = (audioController.sfx / 10) / 2;
        menuChange.Play();
    }
}
