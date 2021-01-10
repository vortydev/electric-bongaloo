using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public bool gameWon = false;

    [SerializeField] Puzzle[] puzzles;      // array of the game's puzzles
    [SerializeField] GameObject[] walls;    // array of the walls

    [SerializeField] GameDoots gameDoots;

    public void CheckGameWon()
    {
        int puzzlesCompleted = 0;

        // goes through the puzzle array
        for (int i = 0; i < puzzles.Length; i++)
        {
            if (puzzles[i].completed == true)
                puzzlesCompleted++;
        }

        if (puzzlesCompleted == puzzles.Length)
            gameWon = true;
        else
            gameWon = false;
    }

    public void ScramblePuzzles()
    {
        for (int i = 0; i < puzzles.Length; i++)
        {
            if (!puzzles[i].completed)
            {
                puzzles[i].TurnLightBoxesOff();
                puzzles[i].ScramblePipes();
            }
        }
    }

    // method to remove walls 

    public void PlayLightOn()
    {
        gameDoots.PlayLightOnSound();
    }

    public void PlayLightOff()
    {
        gameDoots.PlayLightOffSound();
    }
}
