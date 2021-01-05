using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float sanity = 1;
    [SerializeField] GameObject safeZone;
    [SerializeField] Sanity sanityMeter;


    private void Start()
    {
    
    }

    public void PlayerUse()
    {
        Debug.Log("button pressed");
        //not yet implemented
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        Debug.Log(trigger.gameObject.tag);
        if (trigger.gameObject.tag == "Safe")
        {            
            sanityMeter.ToggleSafe();
        }
    }

    private void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Safe")
        {
            sanityMeter.ToggleSafe();
        }
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Fire1")) 
        { 
            PlayerUse();
        }

        gameObject.transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * moveSpeed* Time.deltaTime);
        
    }
}
