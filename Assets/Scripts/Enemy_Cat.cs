using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Cat :Roaming
{
    Animator cat;
    [SerializeField] BoxCollider2D tall;
    [SerializeField] BoxCollider2D wide;

    // Start is called before the first frame update
    void Start()
    {
        cat = gameObject.GetComponent<Animator>();   
    }    

    void AnimRight()
    {
        cat.SetBool("face_Right", true);
        cat.SetBool("face_Left", !true);
        cat.SetBool("face_Back", !true);
        cat.SetBool("face_Front", !true);
        tall.enabled = false;
        wide.enabled = true;
    }

    void AnimLeft()
    {
        cat.SetBool("face_Right", !true);
        cat.SetBool("face_Left", true);
        cat.SetBool("face_Back", !true);
        cat.SetBool("face_Front", !true);
        tall.enabled = false;
        wide.enabled = true;
    }

    void AnimFront()
    {
        cat.SetBool("face_Right", !true);
        cat.SetBool("face_Left", !true);
        cat.SetBool("face_Back", !true);
        cat.SetBool("face_Front", true);
        tall.enabled = true;
        wide.enabled = false;
    }

    void AnimBack()
    {
        cat.SetBool("face_Right", !true);
        cat.SetBool("face_Left", !true);
        cat.SetBool("face_Back", true);
        cat.SetBool("face_Front", !true);
        tall.enabled = true;
        wide.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
