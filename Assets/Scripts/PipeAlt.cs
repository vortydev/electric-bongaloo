using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeAlt : MonoBehaviour
{
    public int puzzle;      // puzzle the pipe belongs to
    public int id;          // id of the pipe

    public int initPos;     // initial pipe position
    public int curPos;      // current pipe position
    public int correctPos;  // correct position
    public bool isGucci;    // bool if the pipe is correctly placed

    private bool canRotate = false;

    void Start()
    {
        ShuffleInitPos();       // sets initial position
        curPos = initPos;       // sets current position
        UpdatePipeRotation();   // updates the gameobjects rotation
        CheckCorrectPos();      // checks if the initial position is correct
    }

    private void Update()
    {
        if (canRotate)
            if (Input.GetKeyDown("e"))
                RotatePipe();
    }

    public void ShuffleInitPos()
    {
        initPos = Random.Range(1, 3);
    }

    public void RotatePipe()
    {
        curPos++;   // increments the pipe's rotation

        if (curPos > 3) // reset to 1 the pipe's position
            curPos = 1;

        UpdatePipeRotation();   // updates the gameobject's rotation
        CheckCorrectPos();      // checks if the current postion is correct
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
        }
    }

    private void CheckCorrectPos()
    {
        if (curPos == correctPos)
            isGucci = true;
        else
            isGucci = false;
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