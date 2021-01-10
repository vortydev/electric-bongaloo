using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public bool gameWon = false;            // bool telling the game if we won

    [SerializeField] GameDoots gameDoots;   // reference to the "library" of game sounds

    [SerializeField] Puzzle[] puzzles;      // array of the game's puzzles
    [SerializeField] GameObject[] walls;    // array of the walls
    private bool[] openedWalls = { false, false, false, false};

    public void CheckGameWon()
    {
        int puzzlesCompleted = 0;

        // goes through the puzzle array
        for (int i = 0; i < puzzles.Length; i++)
        {
            if (puzzles[i].completed == true)
            {
                puzzlesCompleted++;
                RemoveWall(i);
            }
            else {
                RaiseWall(i);
            }
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

    public void PlayLightOn()
    {
        gameDoots.PlayLightOnSound();
    }

    public void PlayLightOff()
    {
        gameDoots.PlayLightOffSound();
    }

    public void PlayPipe()
    {
        gameDoots.PlayPipeSound();
    }

    public void RemoveWall(int ind)
    {
        if (!openedWalls[ind] && ind <= 2)
        {
            gameDoots.PlayDoorOpenSound();
            walls[ind].SetActive(false);
            openedWalls[ind] = true;
        }
    }

    public void RaiseWall(int ind)
    {
        if (openedWalls[ind] && ind <= 2)
        {
            gameDoots.PlayDoorCloseSound();
            walls[ind].SetActive(true);
            openedWalls[ind] = false;
        }
    }
}
