using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] Puzzle puzzle;  // puzzle the pipe belongs to

    public int pipeType;    // type of pipe (1: corner and tee, 2: straight)

    public int correctPos;  // correct position
    public int initPos;     // initial pipe position
    public int curPos;      // current pipe position
    public bool isGucci;    // bool if the pipe is correctly placed

    private bool canRotate = false;

    void Start()
    {
        ShuffleInitPos();       // sets initial position
        curPos = initPos;       // sets current position
        UpdatePipeRotation();   // updates the gameobjects rotation
    }

    private void Update()
    {
        if (canRotate)
            if (Input.GetButtonDown("Fire1"))
                RotatePipe();
    }

    public void ShuffleInitPos()
    {
        switch (pipeType)
        {
            case 1:
                initPos = Random.Range(1, 5);
                break;

            case 2:
                initPos = Random.Range(1, 3);
                break;
        }
    }

    public void ShuffleCurPos()
    {
        switch (pipeType)
        {
            case 1:
                curPos = Random.Range(1, 5);
                break;

            case 2:
                curPos = Random.Range(1, 3);
                break;
        }

        UpdatePipeRotation();
    }

    public void RotatePipe()
    {
        curPos++;   // increments the pipe's rotation

        if (pipeType == 1 && curPos > 4) // reset to 1 the pipe's position
            curPos = 1;
        else if (pipeType == 2 && curPos > 2)
            curPos = 1;

        UpdatePipeRotation();   // updates the gameobject's rotation

        puzzle.PlayPipeFromManager();   // plays a random pipe sound
    }

    private void UpdatePipeRotation()
    {
        switch (curPos)
        {
            case 1:
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;

            case 2:
                transform.rotation = Quaternion.Euler(0, 0, 90);
                break;

            case 3:
                transform.rotation = Quaternion.Euler(0, 0, 180);
                break;

            case 4:
                transform.rotation = Quaternion.Euler(0, 0, 270);
                break;
        }

        CheckCorrectPos();      // checks if the current postion is correct
    }

    private void CheckCorrectPos()
    {
        if (curPos == correctPos)
            isGucci = true;
        else
            isGucci = false;

        puzzle.CheckPuzzleCompletion();
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.tag == "Player")
            canRotate = true;
    }

    private void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger.tag == "Player")
            canRotate = false;
    }
}