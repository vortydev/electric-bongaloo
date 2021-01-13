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
    public bool gameWon = false;                    // bool telling the game if we won
    [SerializeField] Image sanitybar;               // body of the sanity bar UI
    public float winWaitTime = 2.0f;                // delay before popping up the win screen

    [Header("Buttons")]
    [SerializeField] Button replayButton;           // resume button -> reloads the scene
    [SerializeField] Button mainMenuButton;         // main menu button -> loads the main menu scene
    public float buttonDelay = 5.0f;                // delay before the buttons appear

    [Header("Game Data Tracking")]
    //[SerializeField] DiscordController discord;
    public int puzzlesSolved = 0;
    public int timesDied = 0;

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

        gameDoots.PlayPlayerSound(1);   // plays death sound
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
        puzzlesSolved = 0;
        timesDied = 0;
        //UpdateDiscordActivity();

        SceneManager.LoadScene(1);
    }

    private IEnumerator ButtonsDelay()
    {
        yield return new WaitForSeconds(buttonDelay);
        replayButton.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
    }

    public void UpdatePuzzleCount(int puzzleCount)
    {
        puzzlesSolved = puzzleCount;
        //UpdateDiscordActivity();
    }

    //public void UpdateDiscordActivity()
    //{
    //    string detailsString = puzzlesSolved + " puzzles solved";
    //    if (puzzlesSolved == 1)
    //        detailsString = "1 puzzle solved";

    //    var activityManager = discord.discord.GetActivityManager();
    //    var activity = new Discord.Activity
    //    {
    //        State = "This is insane!",
    //        Details = detailsString,
    //        //Timestamps =
    //        //{
    //        //    Start = 5,
    //        //    End = 6,
    //        //},
    //        Assets =
    //        {
    //        	LargeImage = "wmubyg_bigmouth",
    //        	LargeText = "Big Mouth Shadow",
    //        },
    //        //Instance = true,
    //    };

    //    activityManager.UpdateActivity(activity, (res) =>
    //    {
    //        if (res == Discord.Result.Ok)
    //        {
    //            Debug.LogError("Everything is fine!");
    //        }
    //        else Debug.LogError("Frick.");
    //    });
    //}
}
