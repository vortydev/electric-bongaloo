using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuDoots : MonoBehaviour
{
    private AudioController audioController;

    // audio settings
    public float music;
    public float sfx;

    // music
    [SerializeField] private AudioSource menuSoundtrack;

    // sfx
    [SerializeField] private AudioSource menuSelect;
    [SerializeField] private AudioSource menuChange;

    // setting sliders
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    // slider values
    [SerializeField] TextMeshProUGUI musicVal;
    [SerializeField] TextMeshProUGUI sfxVal;

    private void Start()
    {
        audioController = GetComponent<AudioController>();

        music = PlayerPrefs.GetFloat("music");
        sfx = PlayerPrefs.GetFloat("sfx");
    }

    private void Update()
    {
        // update music's volume
        audioController.UpdateMusic(musicSlider.value);
        audioController.UpdateSfx(sfxSlider.value);

        // update sliders' values
        musicVal.text = musicSlider.value.ToString();
        sfxVal.text = sfxSlider.value.ToString();

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
