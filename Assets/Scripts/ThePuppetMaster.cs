using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ThePuppetMaster : MonoBehaviour
{
    public bool displayed = false;

    [SerializeField] PuzzleManager puzzleManager;
    [SerializeField] Image sanityBar;
    [SerializeField] GameObject player;
}
