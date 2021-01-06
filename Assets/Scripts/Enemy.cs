using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float dmg;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void Die()
    {
        Destroy(gameObject, 0.1f);
    }

    public float GetDmg()
    {
        return dmg;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
