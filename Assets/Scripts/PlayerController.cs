using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator player;
    private Rigidbody2D rb;
    public float speed = 10;
    [SerializeField] GameObject safeZone;
    [SerializeField] Sanity sanity;


    private void Start()
    {
        //player = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void PlayerUse()
    {
        Debug.Log("button pressed");
        //not yet implemented
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
        player.SetBool("face_Right", true);
        player.SetBool("face_Left", !true);
        player.SetBool("face_Back", !true);
        player.SetBool("face_Front", !true);
    }

    void AnimLeft()
    {
        player.SetBool("face_Right", !true);
        player.SetBool("face_Left", true);
        player.SetBool("face_Back", !true);
        player.SetBool("face_Front", !true);
    }

    void AnimFront()
    {
        player.SetBool("face_Right", !true);
        player.SetBool("face_Left", !true);
        player.SetBool("face_Back", !true);
        player.SetBool("face_Front", true);
    }

    void AnimBack()
    {
        player.SetBool("face_Right", !true);
        player.SetBool("face_Left", !true);
        player.SetBool("face_Back", true);
        player.SetBool("face_Front", !true);
    }
    private void FixedUpdate()
    {
        if (!sanity.isDead)
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
    }

    //void Update()
    //{
    //    float horizontalInput = Input.GetAxis("Horizontal");
    //    float verticalInput = Input.GetAxis("Vertical");

    //    if (Input.GetButtonDown("Fire1")) 
    //    { 
    //        PlayerUse();
    //    }

    //    gameObject.transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * speed* Time.deltaTime);
        
    //}
}
