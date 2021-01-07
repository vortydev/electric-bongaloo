using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator animator;
    private Rigidbody2D rb;
    public float speed = 10;
    float waitTime = 5f;
    public bool isPaused = false;
    bool respawning = false;
    [SerializeField] Sanity sanity;
    [SerializeField] GameObject respawnPoint;
    [SerializeField] SpriteRenderer BigDarkSprite;
    [SerializeField] SpriteRenderer SmallDarkSprite;

    float bigDarkTransparent;
    float smallDarkTransparent;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void PlayerUse()
    {
        Debug.Log("button pressed");
        //not yet implemented
    }

    void StartRespawn()
    {
        
        if (respawning==false)
        {
            respawning = true;
            StartCoroutine(RespawnDelay(waitTime));            
        }
    }

    IEnumerator RespawnDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.transform.position = respawnPoint.transform.position;
        sanity.isDead = false;
        respawning = false;
    }

    void SetBigDSpriteTrans(float transparency)
    {
        BigDarkSprite.color = new Color (BigDarkSprite.color.r, BigDarkSprite.color.g, BigDarkSprite.color.b, transparency);
    }

    void SetSmallDSpriteTrans(float transparency)
    {
        SmallDarkSprite.color = new Color(SmallDarkSprite.color.r, SmallDarkSprite.color.g, SmallDarkSprite.color.b, transparency);
    }



    private void updateLighting()
    {
        float mySanity = sanity.SanityCheck();

        bigDarkTransparent = (135 - mySanity) * .01f;
        smallDarkTransparent = ((115 - mySanity) / 1.4f) * 0.01f;

        SetBigDSpriteTrans(bigDarkTransparent);
        SetSmallDSpriteTrans(smallDarkTransparent);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            sanity.LoseSanity(enemy.GetDmg());
            enemy.Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Safe")
        {            
            sanity.ToggleSafe();
        }
    }

    private void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Safe")
        {
            sanity.ToggleSafe();
        }
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

    private void Update()
    {
        updateLighting();

        if (!sanity.isDead && !isPaused)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                PlayerUse();
            }

            if (Input.GetKey("d") && Input.GetKey("w"))
            {
                rb.velocity = new Vector2(speed, speed).normalized * speed;
            }
            else if (Input.GetKey("d") && Input.GetKey("s"))
            {
                rb.velocity = new Vector2(speed, -speed).normalized * speed;
            }
            else if (Input.GetKey("a") && Input.GetKey("w"))
            {
                rb.velocity = new Vector2(-speed, speed).normalized * speed;
            }
            else if (Input.GetKey("a") && Input.GetKey("s"))
            {
                rb.velocity = new Vector2(-speed, -speed).normalized * speed;
            }
            else if (Input.GetKey("d"))
            {
                rb.velocity = new Vector2(speed, 0);
                AnimRight();
                //transform.localScale = new Vector2(1, 1);
            }
            else if (Input.GetKey("a"))
            {
                rb.velocity = new Vector2(-speed, 0);
                AnimLeft();
                //transform.localScale = new Vector2(-1, 1);
            }
            else if (Input.GetKey("w"))
            {
                rb.velocity = new Vector2(0, speed);
                AnimBack();
            }
            else if (Input.GetKey("s"))
            {
                rb.velocity = new Vector2(0, -speed);
                AnimFront();
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
            }
        }
        else
        {
            StartRespawn();
            rb.velocity = new Vector2(0, 0);
        }
    }
}
