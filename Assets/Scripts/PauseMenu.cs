using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    private Image pauseMenu;
    [SerializeField] PlayerController player;
    [SerializeField] Image sanityBar;

    [SerializeField] AudioController audioController;
    [SerializeField] GameDoots gameDoots;

    // setting sliders
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    // slider values
    [SerializeField] TextMeshProUGUI musicVal;
    [SerializeField] TextMeshProUGUI sfxVal;

    public void Start()
    {
        // load slider settings
        musicSlider.SetValueWithoutNotify(audioController.music);
        sfxSlider.SetValueWithoutNotify(audioController.sfx);

        pauseMenu = GetComponentInChildren<Image>();    // loads the component
        pauseMenu.gameObject.SetActive(false);          // sets the menu to inactive
    }

    public void Update()
    {
        // manages opening and closing the pause menu (press Esc)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.IsActive())
            {
                gameDoots.PlayPauseSound();

                player.isPaused = false;

                pauseMenu.gameObject.SetActive(false);
                sanityBar.gameObject.SetActive(true);
            }
            else
            {
                gameDoots.PlayPauseSound();

                player.isPaused = true;

                musicSlider.SetValueWithoutNotify(audioController.music);
                sfxSlider.SetValueWithoutNotify(audioController.sfx);

                pauseMenu.gameObject.SetActive(true);
                sanityBar.gameObject.SetActive(false);
            }
        }

        audioController.UpdateMusic(musicSlider.value);
        audioController.UpdateSfx(sfxSlider.value);

        // update sliders' values
        musicVal.text = musicSlider.value.ToString();
        sfxVal.text = sfxSlider.value.ToString();
    }

    // Loads scene #0, which is the main menu
    public void QuitToMainMenu()
    {
        audioController.SavePlayerPrefs();
        SceneManager.LoadScene(0);
    }

    public void TogglePauseMenu()
    {
        gameDoots.PlayPauseSound();

        pauseMenu.gameObject.SetActive(!pauseMenu.IsActive());

        player.isPaused = !player.isPaused;

        sanityBar.gameObject.SetActive(!sanityBar.IsActive());
    }
}
