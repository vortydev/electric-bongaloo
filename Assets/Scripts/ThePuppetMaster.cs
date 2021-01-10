using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ThePuppetMaster : MonoBehaviour
{
    public bool displayed;                          // only used to disable pausing
    private Image winPopup;                         // component that holds the rest of the popup's elements
    
    [Header("Death Handling")]
    [SerializeField] GameDoots gameDoots;           // library of all the game's sounds
    [SerializeField] PuzzleManager puzzleManager;   // mother script controlling all the puzzle jazz
    [SerializeField] Sanity sanity;                 // script that handles the sanity mechanic
    [SerializeField] GameObject player;             // player gameobject
    [SerializeField] GameObject respawnPoint;       // respawning gameobject
    private PlayerController playerController;      // script taking care of the player's controls
    public float deathWaitTime = 1.0f;              // delay before you can move again after death

    [Header("Win Handling")]
    [SerializeField] Image sanitybar;               // body of the sanity bar UI
    public float winWaitTime = 2.0f;                // delay before popping up the win screen

    [Header("Buttons")]
    [SerializeField] Button replayButton;           // resume button -> reloads the scene
    [SerializeField] Button mainMenuButton;         // main menu button -> loads the main menu scene
    public float buttonDelay = 5.0f;                // delay before the buttons appear

    private void Start()
    {
        winPopup = GetComponentInChildren<Image>();
        winPopup.gameObject.SetActive(false);
        displayed = false;

        replayButton.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);

        playerController = player.GetComponent<PlayerController>();
    }

    public void DeathSequence()
    {
        StartCoroutine(ToggleDeathBool());
        gameDoots.PlayPlayerDeathSound();   // plays death sound
        player.transform.position = respawnPoint.transform.position;
        puzzleManager.ScramblePuzzles();
        StopCoroutine(ToggleDeathBool());
    }

    private IEnumerator ToggleDeathBool()
    {
        yield return new WaitForSeconds(deathWaitTime);
        sanity.isDead = false;
    }

    public void WinSequence()
    {
        StartCoroutine(WinWait());
    }

    private void WinPopup()
    {
        StartCoroutine(ButtonsDelay());
        StopCoroutine(WinWait());

        playerController.isPaused = true;
        sanitybar.gameObject.SetActive(false);
        displayed = true;
        winPopup.gameObject.SetActive(true);
    }

    private IEnumerator WinWait()
    {
        yield return new WaitForSeconds(winWaitTime);
        WinPopup();
    }

    public void ClickMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ClickReplay()
    {
        SceneManager.LoadScene(1);
    }

    private IEnumerator ButtonsDelay()
    {
        yield return new WaitForSeconds(buttonDelay);
        replayButton.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
    }
}
