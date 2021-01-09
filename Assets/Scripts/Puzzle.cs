using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [SerializeField] PuzzleManager puzzleManager;

    public int puzzleId;
    public bool completed = false;

    [SerializeField] Pipe[] pipes;
    [SerializeField] LightBox[] lightBoxes;

    public void CheckPuzzleCompletion()
    {
        int correctPipes = 0;

        // goees through the array of pipes to check
        for (int i = 0; i < pipes.Length; i++)
        {
            if (pipes[i].isGucci)
                correctPipes++;
        }

        // sets if the puzzle has been completed
        if (correctPipes == pipes.Length)
            completed = true;
        else
            completed = false;

        puzzleManager.CheckGameWon();
    }

    public void ScramblePipes()
    {
        for (int i = 0; i < pipes.Length; i++)
        {
            pipes[i].ShuffleCurPos();
        }
    }

    // method(s) to handle the lights
}