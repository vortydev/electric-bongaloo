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
    public float waitTime = 1.0f;

    [SerializeField] PuzzleManager puzzleManager;
    [SerializeField] GameDoots gameDoots;

    [SerializeField] Image sanitybar;
    [SerializeField] Sanity sanity;

    [SerializeField] GameObject player;
    [SerializeField] GameObject respawnPoint;

    private void Start()
    {
        winPopup = GetComponentInChildren<Image>();
        winPopup.gameObject.SetActive(false);
        displayed = false;
    }

    public void DeathSequence()
    {
        StartCoroutine(ToggleDeathBool());
        gameDoots.PlayPlayerDeathSound();   // plays death sound
        player.transform.position = respawnPoint.transform.position;
        puzzleManager.ScramblePuzzles();
        StopCoroutine(ToggleDeathBool());
    }

    IEnumerator ToggleDeathBool()
    {
        yield return new WaitForSeconds(waitTime);
        sanity.isDead = false;
    }

    // win handling
}
