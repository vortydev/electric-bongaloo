using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Mouth : Roaming
{
    Roaming roaming;
    Animator animator;
    [SerializeField] GameObject coneHandler;


    void Start()
    {
        roaming = gameObject.GetComponent<Roaming>();
        animator = gameObject.GetComponent<Animator>();
        roaming.SetDestination(gameObject);
    }

    void AnimRight()
    {
        animator.SetBool("face_Right", true);
        animator.SetBool("face_Left", !true);
        animator.SetBool("face_Back", !true);
        animator.SetBool("face_Front", !true);
    }

    void AnimLeft()
    {
        animator.SetBool("face_Right", !true);
        animator.SetBool("face_Left", true);
        animator.SetBool("face_Back", !true);
        animator.SetBool("face_Front", !true);
    }

    void AnimFront()
    {
        animator.SetBool("face_Right", !true);
        animator.SetBool("face_Left", !true);
        animator.SetBool("face_Back", !true);
        animator.SetBool("face_Front", true);
    }

    void AnimBack()
    {
        animator.SetBool("face_Right", !true);
        animator.SetBool("face_Left", !true);
        animator.SetBool("face_Back", true);
        animator.SetBool("face_Front", !true);
    }
    void ChangeAnimDirection()
    {//x- faceRight, x+ faceLeft, y- faceBack, y+ faceFront
        float dirX = gameObject.transform.position.x - roaming.GetDestination().transform.position.x;
        float dirY = gameObject.transform.position.y - roaming.GetDestination().transform.position.y;

        if (Mathf.Abs(dirX) > Mathf.Abs(dirY))
        {
            if (dirX > 0)
            {
                AnimLeft();
            }
            else AnimRight();
        }
        else
        {
            if (dirY > 0)
            {
                AnimFront();
            }
            else AnimBack();
        }
    }
    void Update()
    {
        if (!GetIsWaiting())
        {
            coneHandler.SetActive(true);
            if (roaming.GetDestination() != gameObject)
            {
                ChangeAnimDirection();
                MoveToWaypoint(GetVector2());
            }
        }
        else coneHandler.SetActive(false);
    }
}
