using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ThePuppetMaster : MonoBehaviour
{
    public bool displayed;
    private Image winPopup;

    public float deathWaitTime = 1.0f;
    public float winWaitTime = 2.0f;

    [SerializeField] PuzzleManager puzzleManager;
    [SerializeField] GameDoots gameDoots;
    [SerializeField] GameObject respawnPoint;

    [SerializeField] Image sanitybar;
    [SerializeField] Sanity sanity;

    [SerializeField] GameObject player;
    private PlayerController playerController;

    private void Start()
    {
        winPopup = GetComponentInChildren<Image>();
        winPopup.gameObject.SetActive(false);
        displayed = false;

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
}
