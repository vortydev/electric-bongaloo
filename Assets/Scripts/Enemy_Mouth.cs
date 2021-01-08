using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Mouth : Enemy
{
    Animator mouth;

    void Start()
    {
        mouth = gameObject.GetComponent<Animator>();
    }

    void AnimRight()
    {
        mouth.SetBool("face_Right", true);
        mouth.SetBool("face_Left", !true);
        mouth.SetBool("face_Back", !true);
        mouth.SetBool("face_Front", !true);
    }

    void AnimLeft()
    {
        mouth.SetBool("face_Right", !true);
        mouth.SetBool("face_Left", true);
        mouth.SetBool("face_Back", !true);
        mouth.SetBool("face_Front", !true);
    }

    void AnimFront()
    {
        mouth.SetBool("face_Right", !true);
        mouth.SetBool("face_Left", !true);
        mouth.SetBool("face_Back", !true);
        mouth.SetBool("face_Front", true);
    }

    void AnimBack()
    {
        mouth.SetBool("face_Right", !true);
        mouth.SetBool("face_Left", !true);
        mouth.SetBool("face_Back", true);
        mouth.SetBool("face_Front", !true);
    }

}
