using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] ThePuppetMaster gameData;
    [SerializeField] GameDoots gameDoots;   // reference to the "library" of game sounds
    [SerializeField] HubJank hubJank;

    [SerializeField] Puzzle[] puzzles;      // array of the game's puzzles
    [SerializeField] GameObject[] walls;    // array of the walls
    private bool[] openedWalls = { false, false, false, false };

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
                hubJank.TurnOnHubLight(i);
            }
            else {
                RaiseWall(i);
                hubJank.TurnOffHubLight(i);
            }
        }

        if (puzzlesCompleted == puzzles.Length)
            gameData.gameWon = true;
        else
            gameData.gameWon = false;

        if (puzzlesCompleted != gameData.puzzlesSolved)
            gameData.UpdatePuzzleCount(puzzlesCompleted);
    }

    public void ScramblePuzzles()
    {
        for (int i = 0; i < puzzles.Length - 1; i++)
        {
            if (!puzzles[i].completed)
            {
                puzzles[i].TurnLightBoxesOff();
                puzzles[i].ScramblePipes();
            }
        }

        puzzles[3].TurnLightBoxesOff();
        puzzles[3].ScramblePipes();
    }

    public void PlayLightOn()
    {
        gameDoots.PlayLightSound(0);
    }

    public void PlayLightOff()
    {
        gameDoots.PlayLightSound(1);
    }

    public void PlayPipe()
    {
        gameDoots.PlayPipeSound();
    }

    public void RemoveWall(int ind)
    {
        if (!openedWalls[ind] && ind <= 2)
        {
            gameDoots.PlayWallSound(0);
            walls[ind].SetActive(false);
            openedWalls[ind] = true;
        }
    }

    public void RaiseWall(int ind)
    {
        if (openedWalls[ind] && ind <= 2)
        {
            gameDoots.PlayWallSound(1);
            walls[ind].SetActive(true);
            openedWalls[ind] = false;
        }
    }
}
