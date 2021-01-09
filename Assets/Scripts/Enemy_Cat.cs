using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Cat :Roaming
{
    Animator animator;
    Roaming roaming;
    [SerializeField] BoxCollider2D tall;
    [SerializeField] BoxCollider2D wide;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        roaming = gameObject.GetComponent<Roaming>();
        roaming.SetDestination(gameObject);
    }    

    void AnimRight()
    {
        animator.SetBool("face_Right", true);
        animator.SetBool("face_Left", !true);
        animator.SetBool("face_Back", !true);
        animator.SetBool("face_Front", !true);
        tall.enabled = false;
        wide.enabled = true;
    }

    void AnimLeft()
    {
        animator.SetBool("face_Right", !true);
        animator.SetBool("face_Left", true);
        animator.SetBool("face_Back", !true);
        animator.SetBool("face_Front", !true);
        tall.enabled = false;
        wide.enabled = true;
    }

    void AnimFront()
    {
        animator.SetBool("face_Right", !true);
        animator.SetBool("face_Left", !true);
        animator.SetBool("face_Back", !true);
        animator.SetBool("face_Front", true);
        tall.enabled = true;
        wide.enabled = false;
    }

    void AnimBack()
    {
        animator.SetBool("face_Right", !true);
        animator.SetBool("face_Left", !true);
        animator.SetBool("face_Back", true);
        animator.SetBool("face_Front", !true);
        tall.enabled = true;
        wide.enabled = false;
    }

    void ChangeAnimDirection()
    {//x- faceRight, x+ faceLeft, y- faceBack, y+ faceFront
        float dirX = gameObject.transform.position.x - roaming.GetDestination().transform.position.x;
        float dirY = gameObject.transform.position.y - roaming.GetDestination().transform.position.y;
        //Debug.Log("x value is " + dirX + ", y value is " + dirY);

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

    // Update is called once per frame
    void Update()
    {
        ChangeAnimDirection();
        roaming.MoveToWaypoint(GetVector2());
    }
}
