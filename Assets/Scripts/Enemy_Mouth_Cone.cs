using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Mouth_Cone : MonoBehaviour
{
    Roaming roaming;

    [SerializeField] float rotationSpeed = 0.3f;
    [SerializeField] GameDoots gameDoots;
    GameObject go;

    void Start()
    {
        go = gameObject;
        roaming = gameObject.transform.parent.gameObject.GetComponent<Roaming>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.name == ("Player"))
        {            
            roaming.SetDestination(collision.gameObject);
            gameDoots.PlayBigMouthTriggeredSound();
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if(!roaming.GetIsWaiting())
            go.transform.Rotate(0,0,rotationSpeed * Time.fixedDeltaTime);
    }
}
