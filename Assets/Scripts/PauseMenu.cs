using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    private Image pauseMenu;
    [SerializeField] AudioController audioController;

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    [SerializeField] private TextMeshProUGUI musicVal;
    [SerializeField] private TextMeshProUGUI sfxVal;

    public void Start()
    {
        // loads the image component
        pauseMenu = GetComponentInChildren<Image>();
        pauseMenu.gameObject.SetActive(false);

        // loads audio controller
        // audioController = GetComponent<AudioController>();

        // load sliders
        musicSlider.SetValueWithoutNotify(audioController.music);
        sfxSlider.SetValueWithoutNotify(audioController.sfx);
    }

    public void Update()
    {
        // manages opening and closing the pause menu (press Esc)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.IsActive())
            {
               pauseMenu.gameObject.SetActive(false);
            }
            else
            {
                musicSlider.SetValueWithoutNotify(audioController.music);
                sfxSlider.SetValueWithoutNotify(audioController.sfx);

                pauseMenu.gameObject.SetActive(true);
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
        SceneManager.LoadScene(0);
    }
}
